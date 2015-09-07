namespace BattleShips.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    class BattleShipsMain
    {
        public static string AccessToken = string.Empty;

        static void Main()
        {
            while (true)
            {
                var commandLine = Console.ReadLine();
                if (string.IsNullOrEmpty(commandLine))
                {
                    break;
                }

                var commands = commandLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                switch (commands[1])
                {
                    case "register":
                        RegisterUserAsync(commands[2], commands[3], commands[4]);
                        break;
                    case "login":
                        LoginUserAsync(commands[2], commands[3]);
                        break;
                    case "create-game":
                        CreateGameAsync();
                        break;
                    case "join-game":
                        JoinGameAsync(commands[2]);
                        break;
                    case "play":
                        PlayAsync(commands[2], commands[3], commands[4]);
                        break;
                }
            }
        }

        private static async void PlayAsync(string gameId, string positionX, string positionY)
        {
            const string playGameEndPoint = "http://localhost:62858/api/games/play";
            var httpClient = new HttpClient();
            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + BattleShipsMain.AccessToken);
                var bodyData = new FormUrlEncodedContent(new []
                {
                    new KeyValuePair<string, string>("GameId", gameId),
                    new KeyValuePair<string, string>("PositionX", positionX),
                    new KeyValuePair<string, string>("PositionY", positionY), 
                });

                var response = await httpClient.PostAsync(playGameEndPoint, bodyData);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Successfully made move");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("{0} {1}", response.StatusCode, error);
                }
            }
        }

        private static async void JoinGameAsync(string gameId)
        {
            const string joinGameEndPoint = "http://localhost:62858/api/games/join";
            var httpClient = new HttpClient();
            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + BattleShipsMain.AccessToken);
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId) 
                });

                var response = await httpClient.PostAsync(joinGameEndPoint, bodyData);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Successfully joined game " + gameId);
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("{0} {1}", response.StatusCode, error);
                }
            }
        }

        private static async void CreateGameAsync()
        {
            const string createGameEndPoint = "http://localhost:62858/api/games/create";
            var httpClient = new HttpClient();
            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + BattleShipsMain.AccessToken);
                var response = await httpClient.PostAsync(createGameEndPoint, null);

                if (response.IsSuccessStatusCode)
                {
                    var gameId = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Successfully created game " + gameId);
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("{0} {1}", response.StatusCode, error);
                }
            }
        }

        private static async void LoginUserAsync(string username, string password)
        {
            const string loginEndPoint = "http://localhost:62858/Token";
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", username),
                    new KeyValuePair<string, string>("Password", password),
                    new KeyValuePair<string, string>("grant_type", "password") 
                });

                var response = await httpClient.PostAsync(loginEndPoint, bodyData);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsAsync<AccessToken>();
                    BattleShipsMain.AccessToken = token.Access_Token;
                    Console.WriteLine("Successfully logged in");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("{0} {1}", response.StatusCode, error);
                }
            }
        }

        private static async void RegisterUserAsync(string email, string password, string confirmPassword)
        {
            const string registerEndPoint = "http://localhost:62858/api/account/register";
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var bodyData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Email", email),
                    new KeyValuePair<string, string>("Password", password),
                    new KeyValuePair<string, string>("ConfirmPassword", confirmPassword) 
                });

                var response = await httpClient.PostAsync(registerEndPoint, bodyData);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(email + " successfully registered");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("{0} {1}", response.StatusCode, error);
                }
            }
        }
    }
}
