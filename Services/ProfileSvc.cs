using BoshaTuft.Entity;

namespace BoshaTuft.Services;

public sealed class ProfileSvc
{
    public Profile? _profile { get; set; } = null!;

    public ProfileSvc()
    { 
    }

    public void TestData()
    {
		_profile = new Profile
		{
			Name = "Min San Lang",
			About = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis",
			Pic = "pic/sample_1.jpg",
			Alt = "Min San Lang"
		};

		var sa1 = new Anchor { 
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

		var sa4 = new Anchor
		{
			Description = "spotify",
			LinkTo = "https://github.com/dnErf",
			Pic = "pic/ex_1.jpg"
		};

		_profile.SocialAnchors.Add(sa1);
		_profile.SocialAnchors.Add(sa2);
		_profile.SocialAnchors.Add(sa3);
		_profile.SocialAnchors.Add(sa4);

		var oa1 = new Anchor {
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

        _profile.OtherAnchors.Add(oa1);
		_profile.OtherAnchors.Add(oa2);
		_profile.OtherAnchors.Add(oa3);
	}
}
