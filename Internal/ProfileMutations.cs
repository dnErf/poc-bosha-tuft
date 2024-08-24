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

	public Task UpdateProfileInfo(Profile profile)
	{
		var q = """

			""";

		using var c = _ctx.CreateConnection();

		return Task.CompletedTask;
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
