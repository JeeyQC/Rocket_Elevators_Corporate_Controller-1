using System;
using System.Collections.Generic;
using System.Linq;

//This program will be used by Rocket Elevators for the Corporate controllers.
namespace CorporateElevatorSolution
{
/////////////////////////////////////////
//            Class: Elevator          //
/////////////////////////////////////////
    public class Elevator
    {
        //Class variables declaration
        //Description: Declare all the variables of the Elevator Class.
        public string ID{get; set;}
        public string Status{get; set;}
        public string Direction{get; set;}
        public string Motion{get; set;}
        public int Position{get; set;}
        public int Weight{get; set;}
        public List<int> RequestsUp{get; set;}
        public List<int> RequestsDown{get; set;}
        public string Door{get; set;}
        public bool DoorSensor{get; set;}

        //      Constructor     //
        //Description: Initialize the elevator object with default value, using id.
        public Elevator(string iD)
        { 
            this.ID = iD; 
            this.Status = "On";
            this.Direction = "Idle";
            this.Motion = "Idle";
            this.Position = 0;
            this.Weight = 0;
            this.RequestsUp = new List<int>();
            this.RequestsDown = new List<int>();
            this.Door = "Closed";
            this.DoorSensor = false;
        }

        //      AddRequest      //
        //Description: Function used to add a request on an elevator requests lists. 
        private void AddRequest(int FloorNumber, string ReqList)
        {
            switch (ReqList)
            {
                case "Up":
                    if (this.Direction == "Idle")
                    {
                        this.Direction = "Up";
                    }
                    this.RequestsUp.Add(FloorNumber);
                    //This is good on small list
                    //Linq is for huge list.
                    //this.RequestsUp.Sort();
                    this.RequestsDown.OrderBy(item => item).ToList();
                    Console.WriteLine(">>> Added request for floor: " + FloorNumber.ToString() + " to elevator: " + this.ID.ToString() + " on Request list Up.");
                    Console.WriteLine("\r");
                break;
                case "Down":
                    if (this.Direction == "Idle")
                    {
                        this.Direction = "Down";
                    }
                    this.RequestsDown.Add(FloorNumber);
                    //This is good on small list
                    //this.RequestsDown.Sort();
                    //this.RequestsDown.Reverse();
                    //The other one use linq
                    //Faster with huge amout of data.
                    this.RequestsDown.OrderByDescending(item => item).ToList();
                    Console.WriteLine(">>> Added request for floor: " + FloorNumber.ToString() + " to elevator: " + this.ID.ToString() + " on Request list Down.");
                break;
            }
        }

        //      WeightSensor    //
        //Description: Function used to to calculate and return the weight of the elevator.
        private void WeightSensor()
        {
        //We simulate that there's a balance
        int Weight = 200; //in pounds, You can change it. 
        this.Weight = Weight;
        }
    }

/////////////////////////////////////////
//            Class: Column            //
/////////////////////////////////////////
public class Column
{
    //Class variables declaration
    //Description: Declare all the variables of the Column Class.
    public string ID{get; set;}
    public List<object> ColElevator{get; set;}

    //      Constructor     //
    //Description: Initialize the column object with default value, using id.
    public Column(string id)
    {
        this.ID = id;
        this.ColElevator = new List<object>();
    }
}

/////////////////////////////////////////
//         Class: OutsideButton        //
/////////////////////////////////////////
public class OutsideButton
{
    //Class variables declaration
    //Description: Declare all the variables of the OutsideButton Class.
    public string ID{get;}
    public int Floor{get;}
    public string Direction{get;}
    public bool IsPressed{get; set;}
    public bool Light{get; set;}
    //      Constructor     //
    //Description: Initialize the outside button object with default value, using id, floor and direction.
    public OutsideButton(string id, int floor, string direction)
    {
        this.ID = id;
        this.Floor = floor;
        this.Direction = direction;
    }
}

/////////////////////////////////////////
//         Class: InsideButton         //
/////////////////////////////////////////
public class InsideButton
{
    //Class variables declaration
    //Description: Declare all the variables of the InsideButton Class.
    public string ID{get;}
    public int Floor{get;}
    public int Elevator{get;}
    public bool IsPressed{get; set;}
    public bool Light{get; set;}
    //      Constructor     //
    //Description: Initialize the inside buttons objects with default value, using id, floor and direction.
    public InsideButton(string id, int floor, int elevator)
    {
        this.ID = id;
        this.Floor = floor;
        this.Elevator = elevator;
    }
}

/////////////////////////////////////////
//             Class: Battery          //
/////////////////////////////////////////
public class Controller
{
    //Class variables declaration
    //Description: Declare all the variables of the Battery Class.
    public string Name{get;}
    public List<Elevator> Elevators{get;}
    public List<Column> Columns{get;}
    public List<OutsideButton> OutsideButtons{get;}
    public List<InsideButton> InsideButtons{get;}
    public int MaxWeight{get; set;}

    //      Constructor     //
    //Description: Initialization of the Battery.
    public Controller(string name)
    {
        this.Name = name;
        this.Elevators = new List<Elevator>();
        this.Columns = new List<Column>();
        this.OutsideButtons = new List<OutsideButton>();
        this.InsideButtons = new List<InsideButton>();
        this.MaxWeight = 4500;
    }

    //      Show Elevators      //
    //Description: Function used to show all the elevator in the Elevators list.
    private void ShowElevators()
    {
        Console.WriteLine("Elevators:");
        int i = 0;
        foreach (Elevator element in Elevators)
        {
            if (Elevators[i].RequestsUp.Any() && Elevators[i].RequestsDown.Any()){
                Console.WriteLine("ID: " + Elevators[i].ID + ", Status: " + Elevators[i].Status + ", Direction: " + Elevators[i].Direction + ", Motion: " + Elevators[i].Motion + ", Positon: " + Elevators[i].Position + ", Door: " + Elevators[i].Door + ", Requests Up: [" + string.Join(',', Elevators[i].RequestsUp) + "], Requests Down: [" + string.Join(',', Elevators[i].RequestsDown) + "]");
            }
            else if (Elevators[i].RequestsUp.Any() && !Elevators[i].RequestsDown.Any()){
                Console.WriteLine("ID: " + Elevators[i].ID + ", Status: " + Elevators[i].Status + ", Direction: " + Elevators[i].Direction + ", Motion: " + Elevators[i].Motion + ", Positon: " + Elevators[i].Position.ToString() + ", Door: " + Elevators[i].Door.ToString() + ", Requests Up: [" + string.Join(',', Elevators[i].RequestsUp) + "], Requests Down: []");
            }
            else if (!Elevators[i].RequestsUp.Any() && Elevators[i].RequestsDown.Any()){
                Console.WriteLine("ID: " + Elevators[i].ID + ", Status: " + Elevators[i].Status + ", Direction: " + Elevators[i].Direction + ", Motion: " + Elevators[i].Motion + ", Positon: " + Elevators[i].Position.ToString() + ", Door: " + Elevators[i].Door.ToString() + ", Requests Up: [], Requests Down: [" + string.Join(',', Elevators[i].RequestsDown) + "]");
            }
            else if (!Elevators[i].RequestsUp.Any() && !Elevators[i].RequestsDown.Any()){
                Console.WriteLine("ID: " + Elevators[i].ID + ", Status: " + Elevators[i].Status + ", Direction: " + Elevators[i].Direction + ", Motion: " + Elevators[i].Motion + ", Positon: " + Elevators[i].Position.ToString() + ", Door: " + Elevators[i].Door.ToString() + ", Requests Up: [], Requests Down: []");
            }
            i++;
        }
        
    }

    //      Show Columns    //
    //Description: Function used to show all the column in the Columns list.
    private void ShowColumns()
    {
        Console.WriteLine("Columns:");
        int i = 0;
        foreach (Column element in Columns)
        {
            Console.WriteLine("ID: " + Columns[i].ID + ", Elevators: [" + string.Join(',', Columns[i].ColElevator) + "]");
            i++;
        }
       Console.WriteLine("\r");
    }

    //      Show OutsideButtons     //
    //Description: Function used to show all the outside buttons in the OutsideButtons list.
    private void ShowOutsideButtons()
    {
        Console.WriteLine("Outside Buttons:");
        int i = 0;
        foreach (OutsideButton element in OutsideButtons)
        {
            Console.WriteLine("ID: " + OutsideButtons[i].ID + ", Floor: " + string.Join(',',OutsideButtons[i].Floor) + ", Direction: " + string.Join(',',OutsideButtons[i].Direction) + ", IsPressed: " + string.Join(',',OutsideButtons[i].IsPressed) + ", Light: " + string.Join(',',OutsideButtons[i].Light));
            i++;
        }
    }

    //      Show InsideButtons     //
    //Description: Function used to show all the inside buttons in the InsideButtons list.
    private void ShowInsideButtons()
    {
        Console.WriteLine("Inside Buttons:");
        int i = 0;
        foreach (InsideButton element in InsideButtons)
        {
            Console.WriteLine("ID: " + InsideButtons[i].ID + ", Floor: " + string.Join(',',InsideButtons[i].Floor) + ", Elevator: " + string.Join(',',InsideButtons[i].Elevator) + ", IsPressed: " + string.Join(',',InsideButtons[i].IsPressed) + ", Light: " + string.Join(',',InsideButtons[i].Light));
            i++;
        }
    }

    //      MoveUp      //
    //Description: Function used to move the elevator up, it represent the motor that goes up. 
    private int MoveUp(Elevator elevator)
    {
        if (elevator.Motion == "Stop")
        {
            Console.WriteLine("> Elevator: " + elevator.ID.ToString() + ", Started engine to go Up");
        }
        elevator.Motion = "Up"; //Engine is going Up!
        //DYNAMIC !!! Changes to Requests List can still be made, and ServeCalls test it live.
        //We simulate that the motor start to go in the right direction and that the sensor tell it which position it is. 
        elevator.Position +=1;
        return elevator.Position;
        // TODO 5.0 Finish MoveUp function. <OD, 2019-2-21, d:2019-2-21, 23:59, p:3>
    }

    //      MoveDown      //
    //Description: Function used to move the elevator down, it represent the motor that goes down.
    private int MoveDown(Elevator elevator)
    {
       if (elevator.Motion == "Stop"){
        Console.WriteLine("> Elevator: " + elevator.ID.ToString() + ", Started engine to go Down");
       }
       elevator.Motion = "Down"; //Engine is going Down!
       //DYNAMIC !!! Changes to Requests List can still be made, and ServeCalls test it live.
       //We simulate that the motor start to go in the right direction and that the sensor tell it which position it is. 
       elevator.Position -=1;
       return elevator.Position;
       // TODO 6.0 Finish MoveDown function. <OD, 2019-2-21, d:2019-2-21, 23:59, p:3>
       // TODO 7.0 Check for removing the FloorNumber and doing that process in ServeCalls. <OD, 2019-2-21, d:2019-2-21, p:3>
    }
}
    static class Program
    {
        static void Main(string[] args)
        {
            Elevator elevator = new Elevator("ele1");
            Console.WriteLine(elevator.ID.ToString());
        }
    }
}
