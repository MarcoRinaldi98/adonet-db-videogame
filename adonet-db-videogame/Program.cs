using adonet_db_videogame;

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
            
            break;

        case 2:
            

            break;

        case 3:
            

            break;

        case 4:

            break;

        case 5:

            break;

        default:
            Console.WriteLine("Non hai selezionato un opzione valida!");
            break;

    }
}
