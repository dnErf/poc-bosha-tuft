using BoshaTuft.Entity;
using Dapper;

namespace BoshaTuft.Internal;

public interface IProfileQueries
{
	Task<Profile> GetProfileAsync();
}

internal class ProfileQueries : IProfileQueries
{
	private readonly IDataContext _ctx;

	public ProfileQueries(IDataContext ctx)
	{
		_ctx = ctx;
	}

	public async Task<Profile> GetProfileAsync()
	{
		var profileQuery = """
			select Id, Name, About, Pic, Alt, DatedAt
			from profiles
		""";

		var socialQuery = """
			select Id, ProfileId, Description, LinkTo, Pic, Alt, DatedAt
			from anchors_social
			where ProfileId = @Id
		""";

		var othersQuery = """
			select Id, ProfileId, Description, LinkTo, Pic, Alt, DatedAt
			from anchors_other
		""";

		using var c = _ctx.CreateConnection();
		await c.OpenAsync();

		var profile = await c.QueryFirstOrDefaultAsync<Profile>(profileQuery);
		var social = await c.QueryAsync<Anchor>(socialQuery, new { profile!.Id });
		var others = await c.QueryAsync<Anchor>(othersQuery, new { profile!.Id });

		profile.SocialAnchors = social.ToList();
		profile.OtherAnchors = others.ToList();

		await c.CloseAsync();

		return profile;
	}
}
