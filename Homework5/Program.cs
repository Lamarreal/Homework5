
namespace MyNamespace
{
    public enum FoodType
    {
        None = 0,
        Drink = 1,
        Food = 2,
        
    }
    public class Food
	{
		public string Name { get; set; }
		public int Cost { get; set; }
		public FoodType Type { get; set; }
		public Food(string name,int cost, FoodType type)
		{
			Name = name;
			Cost = cost;
			Type = type;
		}
      
	}

	class MyClass
	{
		enum Operators
		{
			None = 0,
			plus = '+',
            minus = '-',
            multiply = '*',
			divide = '/',
        }



		static void Main()
		{
			try
			{
				Console.Write("(1) calculator ,(2) pizza menu > ");
				int input = Convert.ToInt16(Console.ReadLine());
				if (input == 1)
				{
					Calculator();
				}
				else
				{
					PizzaMenu();
				}

				
			}
			catch (Exception)
			{

				throw;
			}
			

			
		}

		static void PizzaMenu()
		{
			Food[] Menu =
			{
				 new Food("Pepperoni",50,FoodType.Food),
                 new Food("Salami",65,FoodType.Food),
                 new Food("Margarita",65,FoodType.Food),
                 new Food("Cheese pizza",65,FoodType.Food),

                 new Food("Cola",2,FoodType.Drink),
                 new Food("Pepsi",3,FoodType.Drink),
                 new Food("Fanta",4,FoodType.Drink),
            };
			int I = 0;
			foreach (Food item in Menu)
			{
				if (item.Type == FoodType.Food)
				{
					Console.WriteLine("|({2}){0,-18} {1,10}$|", item.Name, item.Cost,I);
					I++;
				}                  
			}
			Console.WriteLine("|---------------------------------|");
            foreach (Food item in Menu)
            {
                if (item.Type == FoodType.Drink)
				{
					Console.WriteLine("|({2}){0,-18} {1,10}$|", item.Name, item.Cost,I);
					I++;
				}                    
            }

			List<Food> Order = new();

			while (true) 
			{
				try
				{
					Console.Write("(done to exit) Enter your order  >");
					string? inp = Console.ReadLine();

					if (inp?.ToLower() == "done")
						break;
					if (inp == null )
						continue;

					int id = Convert.ToInt32(inp);
					if (id < Menu.Length)
					{
						Food SelectedFood = Menu[id];

						Console.Write(SelectedFood.Name + "+ ");

						Console.Write("How much of {0} you want  >", SelectedFood.Name);
						string? inp2 = Console.ReadLine();
						int Count = Convert.ToInt32(inp2);
				
				
						for (int i = 0; i < Count; i++)
						{
							Order.Add(SelectedFood);
						}
					}
				}
				catch (Exception e)
				{

					Console.WriteLine(e.Message);
				}

				

                
			}


			float OverallCost = 0;
			int j = 0;
			int h = 0;
			foreach (Food item in Order)
			{
                
				j++;
				if (item.Type == FoodType.Food)
				{
					if (j == 5)
					{
						Console.WriteLine("|{0,-18} {1,10}$|", item.Name, "gift - 0");
						j = 0;
					}
					else
					{
						Console.WriteLine("|{0,-18} {1,10}$|", item.Name, item.Cost);
						OverallCost += item.Cost;
					}
				}
				else
				{
					h++;
					float cost = item.Cost;

					if (h > 3 & cost > 2)
						cost -= cost * 0.15f;

                    Console.WriteLine("|{0,-18} {1,10}$|", item.Name, cost);
                    OverallCost += cost;
					

                }

            }

			if (OverallCost > 50)
				OverallCost -= OverallCost * 0.2f;

            Console.WriteLine("|Overall cost:{0,4}$", OverallCost);

        }
		static void Calculator()
		{
			try
			{
				Console.Write("Enter two numbes >");

				string? input1 = Console.ReadLine();
				Console.Write(">");
				string? input2 = Console.ReadLine();

				int number1 = Convert.ToInt32(input1);
				int number2 = Convert.ToInt32(input2);

                Console.WriteLine("|{0,-5}|", (char)Operators.minus);
                Console.WriteLine("|{0,-5}|", (char)Operators.plus);
                Console.WriteLine("|{0,-5}|", (char)Operators.divide);
                Console.WriteLine("|{0,-5}|", (char)Operators.multiply);

                Console.Write("arithmetic action >");


				string? line = Console.ReadLine();
				if (line == null)
					line = "";
				Operators? input3 = (Operators)Convert.ToChar(line);

				if (input3 == null)
				{
					throw new Exception("Operator not given");
				}

				int Result = 0;

				switch (input3)
				{
					case Operators.multiply:
						Result = number1 * number2;
						break;
                    case Operators.divide:
                        Result = number1 / number2;
                        break;
                    case Operators.plus:
                        Result = number1 + number2;
                        break;
                    case Operators.minus:
                        Result = number1 - number2;
                        break;
                }
				Console.WriteLine(Result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
		}


		

	}
}

