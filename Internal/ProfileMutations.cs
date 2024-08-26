using BoshaTuft.Entity;
using Dapper;

namespace BoshaTuft.Internal;

public interface IProfileMutations
{
	Task SaveProfileAsync(Profile profile);
	Task UpdateProfileInfo(Profile profile);
}

internal class ProfileMutations : IProfileMutations
{
	private readonly IDataContext _ctx;

	public ProfileMutations(IDataContext ctx)
	{
		_ctx = ctx;
	}

	public async Task UpdateProfileInfo(Profile profile)
	{
		var updateProfile = """
			update profiles
			set Name = @Name, About = @About, Pic = @Pic, Alt = @Alt, DatedAt = @DatedAt
			where Id = @Id
		""";

		var updateSocialLinks = """
			update anchors_social
			set Description = @Description, LinkTo = @LinkTo, Pic = @Pic, Alt = @Alt, DatedAt = @DatedAt
			where Id = @Id and ProfileId = @ProfileId
		""";

		var updateOtherLinks = """
			update anchors_other
			set Description = @Description, LinkTo = @LinkTo, Pic = @Pic, Alt = @Alt, DatedAt = @DatedAt
			where Id = @Id and ProfileId = @ProfileId
		""";

		using var c = _ctx.CreateConnection();
		await c.ExecuteAsync(updateProfile, profile);
		await c.ExecuteAsync(updateSocialLinks, profile.SocialAnchors);
		await c.ExecuteAsync(updateOtherLinks, profile.OtherAnchors);
		await c.CloseAsync();
	}

	public async Task SaveProfileAsync(Profile profile)
	{
		var insertProfile = """
			insert into profiles (Id, Name, About, Pic, Alt, DatedAt)
			values (@Id, @Name, @About, @Pic, @Alt, @DatedAt)
		""";

		var insertSocialLinks = """
			insert into anchors_social (Id, ProfileId, Description, LinkTo, Pic, Alt, DatedAt)
			values (@Id, @ProfileId, @Description, @LinkTo, @Pic, @Alt, @DatedAt)
		""";

		var insertOtherLinks = """
			insert into anchors_other (Id, ProfileId, Description, LinkTo, Pic, Alt, DatedAt)
			values (@Id, @ProfileId, @Description, @LinkTo, @Pic, @Alt, @DatedAt)
		""";

		using var c = _ctx.CreateConnection();
		await c.OpenAsync();

		await c.ExecuteAsync(insertProfile, profile);

		foreach (var social in profile.SocialAnchors)
		{
			social.ProfileId = profile.Id;
			await c.ExecuteAsync(insertSocialLinks, social);
		}

		foreach (var other in profile.OtherAnchors)
		{
			other.ProfileId = profile.Id;
			await c.ExecuteAsync(insertOtherLinks, other);
		}

		await c.CloseAsync();
	}
}
