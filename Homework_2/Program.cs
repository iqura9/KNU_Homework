// .NET 6.0

using Homework_2;

Manager manager1 = new Manager("Mykola Lysenko");
Developer developer1 = new Developer("Ostap Hrush");
Manager manager2 = new Manager("Ogdan Lazurenko");
Manager manager3 = new Manager("Ogdan Lazurenko2");
Manager manager4 = new Manager("Ogdan Lazurenko3");

Team first_team = new Team("First team");
Team second_team = new Team("Second team");

first_team.AddNewCoworker(manager1);
first_team.AddNewCoworker(developer1);
first_team.AddNewCoworker(manager2);
first_team.AddNewCoworker(manager3);
first_team.AddNewCoworker(manager4);
first_team.ShowInfo();
first_team.ShowDetailedInfo();
second_team.ShowDetailedInfo();
