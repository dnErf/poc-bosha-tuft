using BoshaTuft.Components;
using BoshaTuft.Entity;
using BoshaTuft.Internal;

var builder = WebApplication.CreateBuilder(args);

if (string.IsNullOrWhiteSpace(builder.Configuration.GetConnectionString("sqlite")))
{
	Environment.Exit(1);
}

builder.Services.AddScoped<IDataContext, DataContext>();
builder.Services.AddScoped<IProfileQueries, ProfileQueries>();
builder.Services.AddScoped<IProfileMutations, ProfileMutations>();

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
	var profileQueries = scope.ServiceProvider.GetRequiredService<IProfileQueries>();
	var result = await profileQueries.GetProfileAsync();
	Console.WriteLine(result.Id);
	Console.WriteLine("===");

	if (string.IsNullOrWhiteSpace(result.Id))
	{
		var dataCtx = scope.ServiceProvider.GetRequiredService<IDataContext>();
		await dataCtx.Init();

		var profile = new Profile
		{
			Name = "Min San Lang",
			About = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis",
			Pic = "pic/sample_1.jpg",
			Alt = "Min San Lang"
		};

		var sa1 = new Anchor
		{
			Description = "github",
			LinkTo = "https://github.com/dnErf",
			Pic = "pic/ex_1.jpg"
		};

		var sa2 = new Anchor
		{
			Description = "facebook",
			LinkTo = "https://github.com/dnErf",
			Pic = "pic/ex_1.jpg"
		};

		var sa3 = new Anchor
		{
			Description = "instagram",
			LinkTo = "https://github.com/dnErf",
			Pic = "pic/ex_1.jpg"
		};

		profile.SocialAnchors.Add(sa1);
		profile.SocialAnchors.Add(sa2);
		profile.SocialAnchors.Add(sa3);

		var sa4 = new Anchor
		{
			Description = "spotify",
			LinkTo = "https://github.com/dnErf",
			Pic = "pic/ex_1.jpg"
		};

		var oa1 = new Anchor
		{
			Description = "about us",
			LinkTo = "https://github.com/dnErf",
			Pic = "pic/sample_1.jpg"
		};

		var oa2 = new Anchor
		{
			Description = "about this",
			LinkTo = "https://github.com/dnErf",
			Pic = "pic/sample_1.jpg"
		};

		var oa3 = new Anchor
		{
			Description = "about that",
			LinkTo = "https://github.com/dnErf",
			Pic = "pic/sample_1.jpg"
		};

		profile.OtherAnchors.Add(oa1);
		profile.OtherAnchors.Add(oa2);
		profile.OtherAnchors.Add(oa3);

		var adminMutations = scope.ServiceProvider.GetRequiredService<IProfileMutations>();
		await adminMutations.SaveProfileAsync(profile);
	}
}

app.Run();
