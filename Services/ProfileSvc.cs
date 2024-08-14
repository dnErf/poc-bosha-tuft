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
        var ancs = new Anchor { 
            Description = "github", 
            LinkTo = "https://github.com/dnErf" 
        };

        _profile = new Profile { 
            Name = "Min San Lang", 
            About = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis",
            Pic = "pic/sample_1.jpg",
            Alt = "Min San Lang"
        };
        _profile.Anchors.Add(ancs);

    }
}
