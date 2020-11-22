using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArhiCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = ProcessCSV("Player.csv");

            foreach (var player in players)
            {
                Console.WriteLine(player.PlayerName + ' ' + player.ShootingHand);
            }

            Console.ReadLine();
        }

        private static List<Player> ProcessCSV(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(Player.ParseRow).ToList();
        }
    }

    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string PayerDOB { get; set; }
        public string ShootingHand { get; set; }
      

        internal static Player ParseRow(string row)
        {
            var columns = row.Split(',');
            return new Player()
            {
                Id = int.Parse(columns[0]),
                PlayerName = columns[1],
                PayerDOB = columns[2],
                ShootingHand = columns[3],
            };
        }
    }

}
