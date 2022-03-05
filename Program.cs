
using System.Text.RegularExpressions;

/*
Code is NOT production ready and is prodiced without any warranty, use it at your own risk.
Feel free to open a PR to enhance it, though

Credits to this project/page: https://sites.google.com/site/gdocs2direct/

Google drive provided link: https://drive.google.com/file/d/1aTmvp0aoJ0ZHZRn8gmtZDWmV-imRSHja/view
Final downloadable link: https://drive.google.com/uc?export=download&id=1aTmvp0aoJ0ZHZRn8gmtZDWmV-imRSHja
*/

var fileLink = "https://drive.google.com/file/d/1aTmvp0aoJ0ZHZRn8gmtZDWmV-imRSHja/view";
var fileId = Regex.Matches(fileLink, "/file/d/(.+)/(.+)").FirstOrDefault()?.Groups[1].Value;
var downloadLink = $"https://drive.google.com/uc?export=download&id={fileId}";

Console.WriteLine("Wayyyy, we've got ourselves another donwload link!!!");

using var httpClient = new HttpClient();
var httpResponse = await httpClient.GetAsync(downloadLink);
var downloadedStream = await httpResponse.Content.ReadAsStreamAsync();

using Stream memoryStream = new FileStream("cenas.jpg", FileMode.OpenOrCreate);
await downloadedStream.CopyToAsync(memoryStream);

Console.WriteLine("Way to go pops, yet another file downloaded!!!");