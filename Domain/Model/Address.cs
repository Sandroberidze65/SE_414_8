using Domain.Base;

namespace Domain.Model;

public class Address : Base<int>
{
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
}
