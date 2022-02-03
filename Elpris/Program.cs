using Elpris;

string? json = JsonCache.Get();
if (json == null)
{
    json = await PriceDownloader.GetTodaysPricesJsonAsync();
    JsonCache.Put(json);
}

PriceParser parser = new(json);
TimeOnly time = new(18, 00);
DateTime now = DateOnly.FromDateTime(DateTime.Now).ToDateTime(time);
var price = parser.GetWestPrice(now);
Console.WriteLine($"Den aktuelle pris er {price} per kWh");