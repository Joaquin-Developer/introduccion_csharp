using System;

namespace piedra_papel_tijera
{
    class Game
    {
        private double PtsUser { get; set; }
        private double PtsComputer { get; set; }
        private string Username { get; set; }
        private int RoundCounter { get; set; }
        private string[] Games = { "PIEDRA", "PAPEL", "TIJERA" };

        public void Start()
        {
            Console.WriteLine("Ingresar nombre de usuario");
            this.Username = Console.ReadLine();
            Console.WriteLine($"Nombre ingresado: { this.Username }");
            this.PlayController();
        }

        void PlayController()
        {
            Console.WriteLine("Ingresar cantidad de veces que quiere jugar: ");
            int option = int.Parse(Console.ReadLine());

            for (int i = 1; i <= option; i++)
            {
                this.RoundCounter = i;
                this.ValdateRound(this.GetUserPlay(), this.GetComputerPlay());
            }
            this.PrintWinnerOfGame();

        }

        void PrintWinnerOfGame()
        {
            // a ? b : (c ? d : e)
            Console.WriteLine("\n¡FINAL DEL JUEGO!\n");
            Console.WriteLine(
                this.PtsUser > this.PtsComputer ? $"GANA { this.Username }" : 
                (this.PtsUser == this.PtsComputer ? "¡EMPATE!" : "GANA LA COMPUTADORA")
            );
            Console.WriteLine($"\nPuntos de { this.Username }: { this.PtsUser }");
            Console.WriteLine($"Puntos de la Máquina: { this.PtsComputer }");
        }

        void PrintPlaysOfUserAndComputer(int userPlay, int computerPlay)
        {
            Console.Clear();
            Console.WriteLine($"Tu Jugada: { this.Games[userPlay - 1] }");
            Console.WriteLine($"Jugada de la Máquina: { this.Games[computerPlay - 1] }");
        }

        int GetUserPlay()
        {
            Console.WriteLine($"\nJUGADA N° { this.RoundCounter }");
            Console.WriteLine("Seleccionar una opción:");
            Console.WriteLine("1. Piedra");
            Console.WriteLine("2. Papel");
            Console.WriteLine("3. Tijera");
            int option = int.Parse(Console.ReadLine());
            return option;
        }

        void ValdateRound(int userPlay, int computerPlay)
        {
            this.PrintPlaysOfUserAndComputer(userPlay, computerPlay);

            if ((userPlay == 1 && computerPlay == 3) || 
                (userPlay == 2 && computerPlay == 1) || 
                (userPlay == 3 && computerPlay == 2))
            {
                this.PtsUser++;
                Console.WriteLine($"¡GANAS la ronda! { this.Username }");
            }

            if ((computerPlay == 1 && userPlay == 3) || 
               (computerPlay == 2 && userPlay == 1) || 
                (computerPlay == 3 && userPlay == 2))
            {
                this.PtsComputer++;
                Console.WriteLine("La Máquina GANA la ronda!");
            }

            if (userPlay == computerPlay) {
                this.PtsComputer++;
                this.PtsUser++;
                Console.WriteLine("Ronda EMPATADA!");
            }
        }

        int GetComputerPlay()
        {
            return new Random().Next(1, 4);
        }

        void Reset()
        {
            this.PtsComputer = 0;
            this.PtsUser = 0;
        }

    }

}
