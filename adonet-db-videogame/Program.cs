﻿using adonet_db_videogame;

Console.WriteLine("Benvenuto nel nostro sistema di gestione videogiochi!");

while (true)
{
    Console.WriteLine(@"
- 1: Inserire un nuovo videogioco;
- 2: Ricercare un videogioco per id;
- 3: Ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input;
- 4: Cancellare un videogioco;
- 5: Chiudere il programma;
");

    Console.Write("Seleziona l'opzione desiderata: ");

    int selectedOption = int.Parse(Console.ReadLine());

    switch (selectedOption)
    {
        case 1:
            Console.WriteLine("Inserisci i dati del videogioco: ");
            Console.Write("Inserisci il nome del videogioco: ");
            string name = Console.ReadLine();

            Console.Write("Inserisci la descrizione del videogioco: ");
            string description = Console.ReadLine();

            Console.Write("Inserisci la data di rilascio del videogioco (dd/mm/yyyy): ");
            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Inserisci l'ID della Software House del videogioco: ");
            long softwareHouseId = long.Parse(Console.ReadLine());

            Videogame newVideogame = new Videogame(0, name, description, releaseDate, softwareHouseId);
            bool inserted = VideogameManager.InsertVideogame(newVideogame);

            if (inserted)
            {
                Console.WriteLine("Il nuovo videogioco è stato aggiunto!");
            }
            else
            {
                Console.WriteLine("Videogioco non inserito!");
            }
            break;

        case 2:
            Console.Write("Inserisci l'id del videogioco da cercare: ");
            long idToSearch = long.Parse(Console.ReadLine());

            Videogame videogameSerched = VideogameManager.GetVideogameById(idToSearch);

            if(videogameSerched == null)
            {
                Console.WriteLine($"Il videogioco con ID {idToSearch} non esiste!");
            } else
            {
                Console.WriteLine($"Il videogioco con ID {idToSearch} è: ");
                Console.WriteLine($"- {videogameSerched}");
            }
            Console.WriteLine();
            break;

        case 3:
            Console.Write("Inserisci la stringa: ");
            string stringToSearch = Console.ReadLine();

            List<Videogame> videogames = VideogameManager.GetVideogamesWithString(stringToSearch);

            if (videogames.Count > 0)
            {
                Console.WriteLine($"Ecco la lista dei videogiochi che contengono \"{stringToSearch}\" nel nome:");
                for (int i = 0; i < videogames.Count; i++)
                {
                    Console.WriteLine($"- {i + 1}");
                    Console.WriteLine($"{videogames[i]}");
                }
            } else
            {
                Console.WriteLine($"Non ci sono videogiochi che contengono \"{stringToSearch}\" nel nome!");
            }          
            Console.WriteLine();
            break;

        case 4:
            Console.Write("Inserisci l'id del videogioco che vuoi eliminare: ");
            long idVideogameToDelete = long.Parse(Console.ReadLine());

            bool deleted = VideogameManager.DeleteVideogame(idVideogameToDelete);

            if (deleted)
            {
                Console.WriteLine($"Il videogioco con ID {idVideogameToDelete} è stato eliminato correttamente!");
            }
            else
            {
                Console.WriteLine("Il videogioco non è stato eliminato!");
            }
            break;

        case 5:
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("Non hai selezionato un opzione valida!");
            break;

    }
}
