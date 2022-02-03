using Elpris;

string? json = JsonCache.Get();
if (json == null)
{
    json = await PriceDownloader.GetTodaysPricesJsonAsync();
    JsonCache.Put(json);
}

PriceParser parser = new(json);

DateTime now = DateTime.Now;
TimeOnly time = new(now.Hour, 00);
DateTime thisHour = DateOnly.FromDateTime(now).ToDateTime(time);

var price = parser.GetWestPrice(thisHour);
Console.WriteLine($"Den aktuelle pris er {price} per kWh");