using Dapper;
using Microsoft.Data.Sqlite;

namespace BoshaTuft.Internal;

public interface IDataContext
{
	SqliteConnection CreateConnection();
	Task Init();
}

public class DataContext : IDataContext
{
	private readonly IConfiguration _config;

	public DataContext(IConfiguration config)
	{
		_config = config;
	}

	public SqliteConnection CreateConnection()
	{
		return new SqliteConnection(_config.GetConnectionString("sqlite"));
	}

	public async Task Init()
	{
		using (var c = CreateConnection())
		{
			await c.OpenAsync();
			var profile = await InitProfile(c);
			var social = await InitSocialAnchor(c);
			var others = await InitOtherAnchor(c);
			await c.CloseAsync();
		};
	}

	private async Task<int> InitProfile(SqliteConnection c)
	{
		var q = """
			create table if not exists 
			profiles (
				Id TEXT,
				Name TEXT,
				About TEXT,
				Pic TEXT,
				Alt TEXT,
				DatedAt TEXT
			);
		""";

		return await c.ExecuteAsync(q);
	}

	private async Task<int> InitSocialAnchor(SqliteConnection c)
	{
		var q = """
			create table if not exists 
			anchors_social (
				Id TEXT,
				ProfileId TEXT,
				Description TEXT,
				LinkTo TEXT,
				Pic TEXT,
				Alt TEXT,
				DatedAt TEXT
			);
		""";

		return await c.ExecuteAsync(q);
	}

	private async Task<int> InitOtherAnchor(SqliteConnection c)
	{
		var q = """
			create table if not exists 
			anchors_other (
				Id TEXT,
				ProfileId TEXT,
				Description TEXT,
				LinkTo TEXT,
				Pic TEXT,
				Alt TEXT,
				DatedAt TEXT
			);
		""";

		return await c.ExecuteAsync(q);
	}
}
