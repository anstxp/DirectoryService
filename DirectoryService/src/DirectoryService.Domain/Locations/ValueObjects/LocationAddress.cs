using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations.ValueObjects;

public record LocationAddress
{
    private LocationAddress(
        string continent,
        string country,
        string city,
        string region,
        string street,
        int number,
        string zipCode)
    {
        Continent = continent;
        Country = country;
        City = city;
        Region = region;
        Street = street;
        Number = number;
        ZipCode = zipCode;
    }

    public string Continent {get ;}
    public string Country { get; }
    public string City { get; }
    public string Region { get; }
    public string Street { get; }
    public int Number { get; }
    public string? ZipCode { get; }

    public static Result<LocationAddress> Create(
        string continent,
        string country,
        string city,
        string region,
        string street,
        int number,
        string zipCode)
    {
        if (string.IsNullOrWhiteSpace(continent))
            return Result.Failure<LocationAddress>("Continent cannot be empty");
        if (string.IsNullOrWhiteSpace(country))
            return Result.Failure<LocationAddress>("Country cannot be empty");
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<LocationAddress>("City cannot be empty");
        if (string.IsNullOrWhiteSpace(region))
            return Result.Failure<LocationAddress>("Region cannot be empty");
        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<LocationAddress>("Street cannot be empty");
        if (number <= 0)
            return Result.Failure<LocationAddress>("Number cannot be negative");
        if (string.IsNullOrWhiteSpace(zipCode))
            return Result.Failure<LocationAddress>("Zip code cannot be empty");

        LocationAddress locationAddress = new LocationAddress(continent, country, city, region, street, number, zipCode);

        return locationAddress;
    }
}