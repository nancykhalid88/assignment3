namespace assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Part01
            #region Q1
            //Q1 : Identify the type of relationship in each scenario below (Inheritance, Association, Aggregation, Composition, or Dependency):

            //a) A University has Departments. If the university is closed, the departments no longer exist.
            //Composition

            //b) A Driver uses a Car.The driver does not own the car.
            //Association

            //c) A Dog is an Animal.
            //Inheritance

            //d) A Team has Players. If the team is deleted, the players still exist.
            //Aggregation

            //e) A method receives a Logger as a parameter and calls it inside the method only.
            //Dependency 
            #endregion
            #region Q2
            //Q2: Answer the following questions about access modifiers and sealed:
            //a) A parent class has a protected field.Can a child class in a different assembly access it? What about through an object instance from outside?
            //Yes,No



            //b) What is the difference between protected internal and private protected?
            //accessible anywhere in the same assembly or in the derived class in other assemblies while private protected
            //means accessible in the parent class or the derived class in the same assembly




            //c) What does the sealed keyword do when applied to a class? What about when applied to a method?
            //Doesnt allow inheritance,doesnt let any deriving class change the method behavior




            //d) Can you create an object from a sealed class using new? Why or why not? 
            //yes because sealed has to do with inheritance not creating new objects
            #endregion

        }
    }
}
