class program
{
    static void Main(string[] args)
    {
        //// Upcasting: Assigning a derived class object to a base class reference
        //Dog dog = new Dog();

        //Animal animal = dog;

        // Downcasting: Casting a base class reference back to a derived class reference
        //Animal animal = new Dog();

        //Dog dog = (Dog)animal;

        Animal animal = new Dog();

        if (animal is Dog dog)
        {
            animal.Eat();
        }



    }
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating");
        }
    }

    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("Barking");
        }
    }
}