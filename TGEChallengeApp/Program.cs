using TGEChallengeApp;
using TGEChallengeApp.DataAccess;
using TGEChallengeApp.Models;

Console.WriteLine(@"
 _______ _____            _   _  _____  _____ _      ____  ____          _      
 |__   __|  __ \     /\   | \ | |/ ____|/ ____| |    / __ \|  _ \   /\   | |     
    | |  | |__) |   /  \  |  \| | (___ | |  __| |   | |  | | |_) | /  \  | |     
    | |  |  _  /   / /\ \ | . ` |\___ \| | |_ | |   | |  | |  _ < / /\ \ | |     
    | |  | | \ \  / ____ \| |\  |____) | |__| | |___| |__| | |_) / ____ \| |____ 
    |_|  |_|  \_\/_/____\_\_|_\_|_____/_\_____|______\____/|____/_/    \_\______|
               |  ____\ \ / /  __ \|  __ \|  ____|/ ____/ ____|                  
  ______ ______| |__   \ V /| |__) | |__) | |__  | (___| (___ ______ ______      
 |______|______|  __|   > < |  ___/|  _  /|  __|  \___ \\___ \______|______|     
               | |____ / . \| |    | | \ \| |____ ____) |___) |                  
   _____ _    _|______/_/_\_\_| _  |_| _\_\______|_____/_____/___ ___  ____      
  / ____| |  | |   /\   | |    | |    |  ____| \ | |/ ____|  ____|__ \|___ \     
 | |    | |__| |  /  \  | |    | |    | |__  |  \| | |  __| |__     ) | __) |    
 | |    |  __  | / /\ \ | |    | |    |  __| | . ` | | |_ |  __|   / / |__ <     
 | |____| |  | |/ ____ \| |____| |____| |____| |\  | |__| | |____ / /_ ___) |    
  \_____|_|  |_/_/    \_\______|______|______|_| \_|\_____|______|____|____/ 
                                                                                 
                                                                                 
");

// Ideally would use dependency injection/settings file in larger project
string outputFolder = @"../../../../Output";
string outputFilename = "postcode_data.csv";
string fileHeadings = "Postcode,Postcode District,Count";
PostcodeManager postcodeManager = new PostcodeManager(new TGEChallengeApp.DataAccess.API.TGEChallengeAPIService());
PostcodeProcessor postcodeProcessor = new PostcodeProcessor();

while (true)
{
    if (!Directory.Exists(outputFolder))
    {
        Directory.CreateDirectory(outputFolder);
    }

    Console.WriteLine("retrieving postcodes");
    IEnumerable<string> postcodes = postcodeManager.GetAllPostcodes();

    IEnumerable<PostcodeDistrict> processedPostcodes = postcodeProcessor.Process(postcodes);
    using (StreamWriter outputFile = new StreamWriter(Path.Combine(outputFolder, outputFilename)))
    {
        outputFile.WriteLine(fileHeadings);

        foreach (PostcodeDistrict district in processedPostcodes)
        {
            foreach (Postcode postcode in district.Postcodes)
            {
                outputFile.WriteLine($"{postcode.Name},{district.Name},{district.Postcodes.Count}");
            }
        }
    }

    Console.WriteLine("Press x to exit or any key to run the program again");
    ConsoleKeyInfo key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.X)
    {
        Environment.Exit(0);
    }
}