
class Humano
{
    public string Nombre { get; set; }
    public int Fuerza { get; set; }
    public int Inteligencia { get; set; }
    public int Destreza { get; set; }
    public int Salud { get; set; }

    public Humano(string nombre, int fuerza, int inteligencia, int destreza, int salud)
    {
        Nombre = nombre;
        Fuerza = fuerza;
        Inteligencia = inteligencia;
        Destreza = destreza;
        Salud = salud;
    }

    public virtual int Atacar(Humano objetivo)
    {
        int dmg = Fuerza * 3;
        objetivo.Salud -= dmg;
        Console.WriteLine($"{Nombre} atacó a {objetivo.Nombre} por {dmg} de daño!");
        return objetivo.Salud;
    }
}

class Mago : Humano
{
    public Mago(string nombre, int fuerza, int inteligencia, int destreza, int salud)
        : base(nombre, fuerza, inteligencia, destreza, salud)
    {
        Salud = 50;
        Inteligencia = 25;
    }

    public override int Atacar(Humano objetivo)
    {
        int dmg = Inteligencia * 3;
        objetivo.Salud -= dmg;
        Console.WriteLine($"{Nombre} atacó a {objetivo.Nombre} por {dmg} de daño!");
        Salud += dmg;
        Console.WriteLine($"{Nombre} se curó por {dmg} de HP!");
        return objetivo.Salud;
    }

    public void Curar(Humano objetivo)
    {
        int cantidadCura = Inteligencia * 3;
        objetivo.Salud += cantidadCura;
        Console.WriteLine($"{Nombre} curó a {objetivo.Nombre} por {cantidadCura} de HP!");
    }
}

class Ninja : Humano
{
    public Ninja(string nombre, int fuerza, int inteligencia, int destreza, int salud)
        : base(nombre, fuerza, inteligencia, destreza, salud)
    {
        Destreza = 75;
    }

    public override int Atacar(Humano objetivo)
    {
        int dmg = Destreza;
        Random rand = new Random();
        if (rand.Next(1, 6) == 1) // 20% de probabilidad de daño extra
        {
            dmg += 10;
        }
        objetivo.Salud -= dmg;
        Console.WriteLine($"{Nombre} atacó a {objetivo.Nombre} por {dmg} de daño!");
        return objetivo.Salud;
    }

    public void Robar(Humano objetivo)
    {
        objetivo.Salud -= 5;
        Salud += 5;
        Console.WriteLine($"{Nombre} robó 5 HP de {objetivo.Nombre}!");
    }
}

class Samurai : Humano
{
    public Samurai(string nombre, int fuerza, int inteligencia, int destreza, int salud)
        : base(nombre, fuerza, inteligencia, destreza, salud)
    {
        Salud = 200;
    }

    public override int Atacar(Humano objetivo)
    {
        base.Atacar(objetivo);
        if (objetivo.Salud < 50)
        {
            objetivo.Salud = 0;
            Console.WriteLine($"{objetivo.Nombre} fue rematado por {Nombre}!");
        }
        return objetivo.Salud;
    }

    public void Meditar()
    {
        Salud = 200;
        Console.WriteLine($"{Nombre} meditó y se restauró a salud completa!");
    }
}

class Program
{
    static void Main()
    {
        // Crear instancias de las clases
        Mago merlin = new Mago("Merlín", 10, 0, 5, 0);
        Ninja rikimaru = new Ninja("Rikimaru", 5, 0, 20, 0);
        Samurai jin = new Samurai("Jin", 15, 0, 10, 0);

        // Realizar acciones
        merlin.Atacar(rikimaru); // Mago ataca a Ninja
        rikimaru.Robar(jin); // Ninja roba salud a Samurai
        jin.Meditar(); // Samurai medita y se restaura

        // Mostrar información
        Console.WriteLine($"{merlin.Nombre}: Salud = {merlin.Salud}");
        Console.WriteLine($"{rikimaru.Nombre}: Salud = {rikimaru.Salud}");
        Console.WriteLine($"{jin.Nombre}: Salud = {jin.Salud}");
    }
}
