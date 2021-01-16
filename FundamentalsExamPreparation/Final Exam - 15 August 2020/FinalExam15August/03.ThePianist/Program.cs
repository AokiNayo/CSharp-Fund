using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Pieces> listOfPieces = new Dictionary<string, Pieces>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string pieceName = input[0];
                string composerName = input[1];
                string key = input[2];

                listOfPieces.Add(pieceName, new Pieces() { Piece = pieceName, Composer = composerName, Key = key });
            }

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = cmd.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string cmdName = cmdArgs[0];

                switch (cmdName)
                {
                    case "Add":
                        Pieces.Add(listOfPieces, cmdArgs);
                        break;
                    case "Remove":
                        Pieces.Remove(listOfPieces, cmdArgs);
                        break;
                    case "ChangeKey":
                        Pieces.ChangeKey(listOfPieces, cmdArgs);
                        break;
                }
            }

            foreach (var kvp in listOfPieces.OrderBy(x => x.Key).ThenBy(x => x.Value.Composer).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.Composer}, Key: {kvp.Value.Key}");
            }
        }

        class Pieces
        {
            public string Piece { get; set; }
            public string Composer { get; set; }
            public string Key { get; set; }


            public static void Add(Dictionary<string, Pieces> listOfPieces, string[] cmdArgs)
            {
                string piece = cmdArgs[1];
                string composer = cmdArgs[2];
                string key = cmdArgs[3];

                if (listOfPieces.ContainsKey(piece))
                {
                    Console.WriteLine($"{piece} is already in the collection!");
                }
                else
                {
                    listOfPieces.Add(piece, new Pieces() { Piece = piece, Composer = composer, Key = key });
                    Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                }
            }
            public static void Remove(Dictionary<string, Pieces> listOfPieces, string[] cmdArgs)
            {
                string piece = cmdArgs[1];

                if (listOfPieces.ContainsKey(piece))
                {
                    listOfPieces.Remove(piece);
                    Console.WriteLine($"Successfully removed {piece}!");
                }
                else
                {
                    Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                }

            }
            public static void ChangeKey(Dictionary<string, Pieces> listOfPieces, string[] cmdArgs)
            {
                string piece = cmdArgs[1];
                string newKey = cmdArgs[2];

                if (listOfPieces.ContainsKey(piece))
                {
                    listOfPieces[piece].Key = newKey;
                    Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                }
                else
                {
                    Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                }
            }
        }
    }
}
