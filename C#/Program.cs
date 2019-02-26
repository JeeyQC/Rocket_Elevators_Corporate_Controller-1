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
    public Elevator Elevator{get;}
    public bool IsPressed{get; set;}
    public bool Light{get; set;}
    //      Constructor     //
    //Description: Initialize the inside buttons objects with default value, using id, floor and direction.
    public InsideButton(string id, int floor, Elevator elevator)
    {
        this.ID = id;
        this.Floor = floor;
        this.Elevator = elevator;
    }
}

/////////////////////////////////////////
//             Class: Battery          //
/////////////////////////////////////////
public class Battery
{
    //Class variables declaration
    //Description: Declare all the variables of the Battery Class.
    public string Name{get;}
    public List<Elevator> Elevators{get;}
    public List<Column> Columns{get;}
    public List<OutsideButton> OutsideButtons{get;}
    public List<InsideButton> InsideButtons{get;}
    public int MaxWeight{get; private set;}
    public string inputNbFloors{get;private set;}
    public string inputNbColumns{get;private set;}
    public string inputNbElevators{get; private set;}
    public string inputNbElevatorsByColumns{get;private set;}
    public int NbFloors{get; private set;}
    public int NbColumns{get; private set;}
    public int NbElevators{get; private set;}
    public int NbElevatorsByColumns{get; private set;}

    //      Constructor     //
    //Description: Initialization of the Battery.
    public Battery(string name)
    {
        this.Name = name;
        this.Elevators = new List<Elevator>();
        this.Columns = new List<Column>();
        this.OutsideButtons = new List<OutsideButton>();
        this.InsideButtons = new List<InsideButton>();
        this.MaxWeight = 4500;
    }

    //      Input Required      //
    //Description: Input required for the algorithm, you can change it as you see fit. 
    //Here we create lists, and classes used in the program. The algorithm should work 
    //in every situation, so we use the input to populate everything.
    public void Input()
    {
        Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>");
        Console.WriteLine("         Please enter the building informations\r");
        Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>\n");
        int value;
        //Number of floors
        Console.WriteLine("FLOORS:");
        Console.WriteLine("Enter the number of floors in the building (0 NOT included): ");
        inputNbFloors = Console.ReadLine();
        while (!Int32.TryParse(inputNbFloors, out value) || Int32.Parse(inputNbFloors) <= 0)
        {
            Console.WriteLine("The number of floors must be superior to 0: ");
            inputNbFloors = Console.ReadLine();
        }
        //Number of columns
        Console.WriteLine("\r");
        Console.WriteLine("COLUMNS:");
        Console.WriteLine("Enter the number of columns in the building: ");
        inputNbColumns = Console.ReadLine();
        while (!Int32.TryParse(inputNbColumns, out value) || Int32.Parse(inputNbColumns) <= 0)
        {
            Console.WriteLine("The number of floors must be superior to 0: ");
            inputNbColumns = Console.ReadLine();
        }
        //Number of elevators
        Console.WriteLine("\r");
        Console.WriteLine("ELEVATORS:");
        Console.WriteLine("Enter the number of elevators in the building: ");
        inputNbElevators = Console.ReadLine();
        while (!Int32.TryParse(inputNbElevators, out value) || Int32.Parse(inputNbElevators) <= 0)
        {
            Console.WriteLine("The number of floors must be superior to 0: ");
            inputNbElevators = Console.ReadLine();
        }
        //Number of elevators by columns
        Console.WriteLine("\r");
        Console.WriteLine("ELEVATORS BY COLUMNS:");
        Console.WriteLine("Enter the number of elevators by columns: ");
        inputNbElevatorsByColumns = Console.ReadLine();
        while (!Int32.TryParse(inputNbElevatorsByColumns, out value) || Int32.Parse(inputNbElevatorsByColumns) <= 0)
        {
            Console.WriteLine("The number of floors must be superior to 0: ");
            inputNbElevatorsByColumns = Console.ReadLine();
        }
        Console.WriteLine("\n");

        //Once this is done.
        NbFloors = Int32.Parse(inputNbFloors);
        NbElevators = Int32.Parse(inputNbElevators);
        NbColumns = Int32.Parse(inputNbColumns);
        NbElevatorsByColumns = Int32.Parse(inputNbElevatorsByColumns);
    }

    //      Show Elevators      //
    //Description: Function used to show all the elevator in the Elevators list.
    public void ShowElevators()
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
    public void ShowColumns()
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
    public void ShowOutsideButtons()
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
    public void ShowInsideButtons()
    {
        Console.WriteLine("Inside Buttons:");
        int i = 0;
        foreach (InsideButton element in InsideButtons)
        {
            Console.WriteLine("ID: " + InsideButtons[i].ID + ", Floor: " + string.Join(',',InsideButtons[i].Floor) + ", Elevator: " + string.Join(',',InsideButtons[i].Elevator) + ", IsPressed: " + string.Join(',',InsideButtons[i].IsPressed) + ", Light: " + string.Join(',',InsideButtons[i].Light));
            i++;
        }
    }

    //      AddRequest      //
    //Description: Function used to add a request on an elevator requests lists. 
    public void AddRequest(Elevator elevator, int FloorNumber, string ReqList)
    {
        switch (ReqList)
        {
            case "Up":
                if (elevator.Direction == "Idle")
                {
                    elevator.Direction = "Up";
                }
                elevator.RequestsUp.Add(FloorNumber);
                //This is good on small list
                //Linq is for huge list.
                //this.RequestsUp.Sort();
                elevator.RequestsDown.OrderBy(item => item).ToList();
                Console.WriteLine(">>> Added request for floor: " + FloorNumber.ToString() + " to elevator: " + elevator.ID.ToString() + " on Request list Up.");
                Console.WriteLine("\r");
            break;
            case "Down":
                if (elevator.Direction == "Idle")
                {
                    elevator.Direction = "Down";
                }
                elevator.RequestsDown.Add(FloorNumber);
                //This is good on small list
                //this.RequestsDown.Sort();
                //this.RequestsDown.Reverse();
                //The other one use linq
                //Faster with huge amout of data.
                elevator.RequestsDown.OrderByDescending(item => item).ToList();
                Console.WriteLine(">>> Added request for floor: " + FloorNumber.ToString() + " to elevator: " + elevator.ID.ToString() + " on Request list Down.");
            break;
        }
    }

    //      WeightSensor    //
    //Description: Function used to to calculate and return the weight of the elevator.
    public void WeightSensor(Elevator elevator)
    {
    //We simulate that there's a balance
    int Weight = 200; //in pounds, You can change it. 
    elevator.Weight = Weight;
    }

    //      MoveUp      //
    //Description: Function used to move the elevator up, it represent the motor that goes up. 
    public int MoveUp(Elevator elevator)
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
    public int MoveDown(Elevator elevator)
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

    //      Doors       //
    //Description: Function used to open an elevators door when it is stopped.
    public void Doors(Elevator elevator)
    {
        //Simulate the door openning
        if (elevator.Motion == "Stop"){
            elevator.Door = "Open";
            Console.WriteLine("\r");
            Console.WriteLine(">>> Elevator: " + elevator.ID.ToString() + ", Doors: " + elevator.Door.ToString());
        }

        //We call the weight sensor
        WeightSensor(elevator);
        while (elevator.Door == "Open"){
            if (elevator.Weight >= this.MaxWeight){
                Console.WriteLine(">>> Alert! The elevator Max Weight has been reached! Please get out!");
            }
            else if (elevator.DoorSensor){
                Console.WriteLine(">>> Alert! Door sensor detected!");
            }
            else{
                elevator.Door = "Closed";
                Console.WriteLine(">>> Elevator: " + elevator.ID.ToString()+ ", Doors: " + elevator.Door.ToString());
                Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>\r");
                Console.WriteLine("\r");
            }
        }
    }

    ///////////////////////////
    //     Serves Calls      //
    ///////////////////////////
    //Description: Function that is always processing the requests list of every elevators, if the elevators have a requests it serve it. 
    public void ServesCalls()
    {
        int i = 0;
        foreach (Elevator element in Elevators)
        {
            switch (Elevators[i].Direction)
            {
                case "Up":
                    //Case Direction UP
                    if (Elevators[i].RequestsUp.Any() && Elevators[i].Motion != "Stop")
                    {
                        //The next request is on the elevator way.
                        if (Elevators[i].Position < Elevators[i].RequestsUp[0])
                        {
                            if (Elevators[i].Motion != "Up")
                            {
                                Console.WriteLine("> Elevator: " + Elevators[i].ID.ToString() + ", Started engine to go Up");
                            }
                            if (MoveUp(Elevators[i]) == Elevators[i].RequestsUp[0])
                            {
                                Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsUp[0].ToString());
                                Elevators[i].RequestsUp.RemoveAt(0); //We can delete the floor from the list since we arrived there.
                                Elevators[i].Motion = "Stop";   //Stop means people are getting In/Out.
                                Doors(Elevators[i]);
                            }
                        }    
                        //Elevator must go pick someone and must go in the opposite direction as the calls it does.
                        else if (Elevators[i].Position > Elevators[i].RequestsUp[0])
                        {
                            if (Elevators[i].Motion != "Down")
                            {
                                Console.WriteLine("> Elevator: " + Elevators[i].ID + ", Started engine to go Down");
                            }
                            if (MoveDown(Elevators[i]) == Elevators[i].RequestsUp[0])
                            {
                                Console.WriteLine(">> Elevator: " + Elevators[i] + ", Has arrived at destination on floor: " + Elevators[i].RequestsUp[0].ToString());
                                Elevators[i].RequestsUp.RemoveAt(0);
                                Elevators[i].Motion = "Stop"; 
                                Doors(Elevators[i]); //Open the doors
                            }
                        }
                    }
                    //Elevator is stopped but still has call to serve on this requests list.
                    else if (Elevators[i].RequestsUp.Any() && Elevators[i].Motion == "Stop")
                    {
                        if (Elevators[i].Door == "Closed"
                        ){
                            if (MoveUp(Elevators[i]) == Elevators[i].RequestsUp[0])
                            {
                                Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsUp[0].ToString());
                                Elevators[i].RequestsUp.RemoveAt(0);
                                Elevators[i].Motion = "Stop";
                                Doors(Elevators[i]);
                            }
                        }
                    }
                    //Switch direction if current request list is empty. 
                    else if (!Elevators[i].RequestsUp.Any() && Elevators[i].Motion == "Stop")
                    {
                        if (Elevators[i].Door == "Closed")
                        {
                            if (Elevators[i].RequestsDown.Any())
                            {
                                Elevators[i].Direction = "Down"; //It will be treated in the next iteration of the loop. We want to treat it in the Down section now. 
                            }
                            else if (!Elevators[i].RequestsDown.Any())
                            {
                                Elevators[i].Direction = "Idle";
                                Elevators[i].Motion = "Idle";
                                Console.WriteLine(">>>> Elevator: " + Elevators[i].ID + " is now Idle");
                            }
                        }
                    }
                    break;
                case "Down":
                    //Case Direction = Down
                    if (Elevators[i].RequestsDown.Any() && Elevators[i].Motion != "Stop")
                    {
                        //The next request is on the elevator way.
                        if (Elevators[i].Position > Elevators[i].RequestsDown[0])
                        {
                            if (Elevators[i].Motion != "Down")
                            {
                                Console.WriteLine("> Elevator: " + Elevators[i].ID + ", Started engine to go Down");
                            }
                            if (MoveDown(Elevators[i]) == Elevators[i].RequestsDown[0])
                            {
                                Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsDown[0].ToString());
                                Elevators[i].RequestsDown.RemoveAt(0);
                                Elevators[i].Motion = "Stop";
                                Doors(Elevators[i]);
                            }
                        }
        
                        //Elevator must go pick someone and must go in the opposite direction as the calls it does.
                        else if (Elevators[i].Position < Elevators[i].RequestsDown[0])
                        {
                            if (Elevators[i].Motion != "Up")
                            {
                                Console.WriteLine("> Elevator: " + Elevators[i].ID + ", Started engine to go Up");    
                            }
                            if (MoveUp(Elevators[i]) == Elevators[i].RequestsDown[0])
                            {
                                Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsDown[0].ToString());
                                Elevators[i].RequestsDown.RemoveAt(0);
                                Elevators[i].Motion = "Stop";
                                Doors(Elevators[i]);
                            }
                        }
                    
                        //Elevator is stopped but still has call to serve on this requests list.
                        else if (Elevators[i].RequestsDown.Any() && Elevators[i].Motion == "Stop")
                        {
                            if (Elevators[i].Door == "Closed")
                            {
                                if (MoveDown(Elevators[i]) == Elevators[i].RequestsDown[0])
                                {
                                    Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsDown[0].ToString());
                                    Elevators[i].RequestsDown.RemoveAt(0);
                                    Elevators[i].Motion = "Stop";
                                    Doors(Elevators[i]);
                                }
                            }
                        }
                    }
                    //Switch direction if current request list is empty.
                    else if (!Elevators[i].RequestsDown.Any() && Elevators[i].Motion == "Stop")
                    {
                        if (Elevators[i].Door == "Closed")
                        {
                            if (Elevators[i].RequestsUp.Any())
                            {
                                Elevators[i].Direction = "Up"; //It will be treated in the next iteration of the loop. We want to treat it in the Up section now.
                            }
                            else if (!Elevators[i].RequestsUp.Any())
                            {
                                Elevators[i].Direction = "Idle";
                                Elevators[i].Motion = "Idle";
                                Console.WriteLine(">>>> Elevator: " + Elevators[i].ID + " is now Idle");
                            }
                        }
                    }
                break;
            }
            i++;
        }
    }

    //    Request Elevator   //
    //Description: Function used to return the best elevator for that call.
    private void RequestElevator(int FloorNumber, string Direction)
    {
        //Variable declaration
        List<Elevator> AvailableElevators = new List<Elevator>();
        bool OnTheWay_U = false;
        bool OnTheWay_D = false;
        int i = 0;
        int minDif = 9999;
        int minReqs = 9999;
        int eleDif;
        int eleReqs;

        // STEP 1: If the elevator can receive calls, add it to Available Elevator List.
        Console.WriteLine("> Outside Panel, Request Detected: Floor: " + FloorNumber.ToString() + ", Direction: " + Direction);
        foreach (Elevator element in Elevators)
        {
            if (Elevators[i].Status == "On")
            {
                AvailableElevators.Add(Elevators[i]);
            }
            i++;
        }

        if (AvailableElevators.Count() > 1)
        {
            i = 0;
            foreach (Elevator element in AvailableElevators)
            {
                switch (Direction)
                {
                    case "Up":
                        if (AvailableElevators[i].Direction == "Up")
                        {
                            if (AvailableElevators[i].RequestsUp.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " Direction: " + Direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                        else if (AvailableElevators[i].Direction == "Down")
                        {
                            if (AvailableElevators[i].RequestsUp.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " Direction: " + Direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                    break;
                    case "Down":
                        if (AvailableElevators[i].Direction == "Down")
                        {
                            if (AvailableElevators[i].RequestsDown.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " Direction: " + Direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                        else if (AvailableElevators[i].Direction == "Up")
                        {
                            if (AvailableElevators[i].RequestsDown.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " Direction: " + Direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                    break;
                }
                i++;
            }
                
            // STEP 3: We check there is on element in the list that meet those requirements: If it goes in the same direction as the call 
            // AND if it has not already passed that floor.
            i = 0;
            foreach (Elevator element in AvailableElevators)
            {
                if (AvailableElevators[i].Direction == Direction)
                {
                    eleDif = AvailableElevators[i].Position - FloorNumber;
                    switch (Direction)
                    {
                        case "Up":
                            if (eleDif < 0)
                            {
                                OnTheWay_U = true;
                            }
                            break;
                        case "Down":
                            if (eleDif > 0)
                            {
                                OnTheWay_D = true;
                            }
                            break;
                    }
                }
                i++;
            }

            //If one of the previous checks ended up True, there's no need to keep the others who doesn't meet those requirements.
            if (OnTheWay_U)
            {
                i = 0;
                foreach (Elevator element in AvailableElevators)
                {
                    if (AvailableElevators[i].Direction == "Down")
                    {
                        AvailableElevators.RemoveAt(i);
                    }
                }
            }
            else if (OnTheWay_D)
            {   
                i = 0;
                foreach (Elevator element in AvailableElevators)
                {
                    if (AvailableElevators[i].Direction == "Up")
                    {
                        AvailableElevators.RemoveAt(i);
                    }
                }
            }

            // STEP 4: Once the list only contains what we are sure is the Available Elevators, we find the lowest difference between 
            // floor and elevator position, then look for the lowest number of requests.
            i = 0;
            foreach (Elevator element in AvailableElevators)
            {
                eleDif = Math.Abs(AvailableElevators[i].Position - FloorNumber);
                if (eleDif <= minDif)
                {
                    minDif = eleDif;
                }
                i++;
            }
            i = 0;
            foreach (Elevator element in AvailableElevators)
            {
                eleDif = Math.Abs(AvailableElevators[i].Position - FloorNumber);
                eleReqs = AvailableElevators[i].RequestsUp.Count() + AvailableElevators[i].RequestsDown.Count();
                if (eleDif == minDif)
                {
                    if (eleReqs <= minReqs)
                    {
                        minReqs = eleReqs;
                    }
                }
                i++;
            }

            // STEP 5: Once we have the value of the lowest, we search it in the Available Elevators List and call the function AddRequest which add
            // the request on the elevator good list. 
            i = 0;
            foreach (Elevator element in AvailableElevators)
            {
                eleDif = Math.Abs(AvailableElevators[i].Position - FloorNumber);
                eleReqs = AvailableElevators[i].RequestsUp.Count() + AvailableElevators[i].RequestsDown.Count();
                if (eleDif == minDif && eleReqs == minReqs)
                {
                    //Check in which Request List to add the requests.
                    switch (Direction)
                    {
                        case "Up":
                            Console.WriteLine(">> Request processed, elevator found: " + AvailableElevators[i].ID);
                            AddRequest(AvailableElevators[i], FloorNumber, "Up");
                            break;
                        case "Down":
                            Console.WriteLine(">> Request processed, elevator found: " + AvailableElevators[i].ID);
                            AddRequest(AvailableElevators[i], FloorNumber, "Down");
                            break;
                    }
                }
                i++;
            }
        }
        else if (AvailableElevators.Count() == 1)
        {
            //If there is only one available elevator, send the call.
            //Check in which Request List to add the requests.
            switch (Direction)
            {
                case "Up":
                    Console.WriteLine(">> Request processed, elevator found: " + AvailableElevators[0].ID);
                    AddRequest(AvailableElevators[0], FloorNumber, "Up");
                    break;
                case "Down":
                    Console.WriteLine(">> Request processed, elevator found: " + AvailableElevators[0].ID);
                    AddRequest(AvailableElevators[0], FloorNumber, "Down");
                    break;
            }
        }
        else if (AvailableElevators.Count() == 0)
        {
            //If nothing is added in the list, this can only mean 1: all the elevators are Off. 2: all the elevators are OutOfOrder
            //In this case the call is forgotten, light on button is turn Off and isPressed is turned back False
            i = 0;
            foreach (OutsideButton element in OutsideButtons)
            {
                if (OutsideButtons[i].Floor == FloorNumber && OutsideButtons[i].Direction == Direction)
                {
                    OutsideButtons[i].Light = false;
                    OutsideButtons[i].IsPressed = false;
                    Console.WriteLine(">> Request processed: No elevators can receive calls at the moment, sorry.");
                    Console.WriteLine("\n");
                    break;
                }
            }
        }
    }

    ///////////////////////////
    //     Request Floor     //
    ///////////////////////////
    //Description: Function that add the floor on the right Request List of an elevator.
    public void RequestFloor(Elevator elevator, int RequestedFloor)
    {
        Console.WriteLine("> Inside Panel, Request Detected: Elevator: " + elevator.ID + ", Floor: " + RequestedFloor.ToString());
        Console.WriteLine(">> ...");
        //Check to be sure you add to a working elevator
        if (elevator.Status == "On")
        {
            var Dif = elevator.Position - RequestedFloor; //We don't use absolute here, because we want the negative...
            switch (elevator.Direction)
            {
                case "Up":
                    if (Dif < 0 && elevator.RequestsUp.Contains(RequestedFloor))
                    {
                        Console.WriteLine(">> Inside Panel Elevator: " + elevator.ID + " Elevator already in requests list. Request aborted.");
                        Console.WriteLine("\n");
                        return;
                    }
                    else 
                    {
                        AddRequest(elevator, RequestedFloor, "Up");
                        return;
                    }
                case "Down":
                    if (Dif > 0 && elevator.RequestsDown.Contains(RequestedFloor))
                    {
                        Console.WriteLine(">> Inside Panel Elevator: " + elevator.ID + " Elevator already in requests list. Request aborted.");
                        Console.WriteLine("\n");
                        return;
                    }
                    else 
                    {
                        AddRequest(elevator, RequestedFloor, "Down");
                        return;
                    }
                case "Idle":
                    if (Dif < 0)
                    {
                        elevator.Direction = "Up";
                        AddRequest(elevator,RequestedFloor,"Up");
                        Console.WriteLine(">> Inside Panel Elevator: " + elevator.ID + " Elevator already in requests list. Request aborted.");
                        Console.WriteLine("\n");
                        return;
                    }
                    else if (Dif > 0)
                    {
                        elevator.Direction = "Down";
                        AddRequest(elevator,RequestedFloor,"Down");
                        return;
                    }
                    break;
            }
        }
        else 
        {
            Console.WriteLine(">> Inside Panel Elevator: Your request was denied because the elevator can't receive calls at the moment.");
            Console.WriteLine("\n");
        }
    }

    // Listen Outside Panel  //
    //Description: Function used to determine which buttons is pressed 
    //on the ouside panel then call the RequestElevator function
    public void ListenOutsidePanel()
    {
        int floor;
        string direction;
        int i = 0;
        foreach (OutsideButton element in OutsideButtons)
        {
            if (OutsideButtons[i].IsPressed == true)
            {
                OutsideButtons[i].Light = true;
                floor = OutsideButtons[i].Floor;
                direction = OutsideButtons[i].Direction;
                OutsideButtons[i].IsPressed = false;
                RequestElevator(floor, direction);
            }
            i++;
        }
    }

    //  Listen Inside Panel  //
    //Description: Function used to determine which buttons is pressed 
    //inside an elevator and call the function RequestFloor.
    public void ListenInsidePanel()
    {
        Elevator elevator;
        int floor;
        int i = 0;
        foreach (InsideButton element in InsideButtons)
        {
            if (InsideButtons[i].IsPressed == true)
            {
                InsideButtons[i].Light = true;
                elevator = InsideButtons[i].Elevator;
                floor = InsideButtons[i].Floor;
                InsideButtons[i].IsPressed = false;
                RequestFloor(elevator, floor);
                //Now we have all to call the requestFloor, once its done, button is not pressed anymore.
            }
        }
    }

    // System Initialization //                     
    public void SystemInit()
    {
        Console.WriteLine("                    System Initialization                   ");
        Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>");
        //    Populate All Lists  //
        //Elevators List
        var i = 1;
        while (i <= NbElevators)
        {
            string ID = "ele" + i.ToString();
            Elevator e = new Elevator(ID);
            Elevators.Add(e);
            i += 1;
        }
        
        //Columns List
        i = 1;
        while (i <= NbColumns)
        {
            string ID = "col" + i.ToString();
            Column c = new Column(ID);
            Columns.Add(c);
            i += 1;
        }
        
        //OutsideButtons List
        i = 1;
        while (i <= NbFloors)
        {
            string ID_Up = "oBtn" + i.ToString() + "_U";
            string ID_Down = "oBtn" + i.ToString() + "_D";
            OutsideButton bUp = new OutsideButton(ID_Up, i, "UP");
            OutsideButton bDown = new OutsideButton(ID_Down, i, "DOWN");
            OutsideButtons.Add(bUp);
            OutsideButtons.Add(bDown);
            i += 1;
        }
        
        //InsideButtons List
        i = 1;
        while (i <= NbElevators)
        {
            string ID = "iBtn" + i.ToString();
            InsideButton iB = new InsideButton(ID, i, Elevators[i-1]);
            InsideButtons.Add(iB);
            i += 1;
        }
        
        //Column attribute ColElevator in Columns List
        i = 0;
        foreach (Column element in Columns)
        {
            var n = 0;
            while (n <= NbElevatorsByColumns)
            {
                Columns[i].ColElevator.Add(Elevators[n-1]);
                n += 1;
            }
        }
      Console.WriteLine("- LISTS CREATED");
      Console.WriteLine("- ELEVATORS READY");
      Console.WriteLine("> SYSTEM READY");
      Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>\n");
   }
}

/////////////////////////////////////////////////////////////////
//                 RESIDENTIAL ELEVATORS SYSTEM                //
/////////////////////////////////////////////////////////////////
//Description: This is the main function were the elevators listen for calls.
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  ______________________________________________________");
            Console.WriteLine(" (__   ____________________________________________   __)");
            Console.WriteLine("    | |                                            | |");
            Console.WriteLine("    | |              ROCKET ELEVATORS              | |");
            Console.WriteLine("    | |       Elevate Safety, Speed and Style      | |");
            Console.WriteLine("    | |                      -                     | |");
            Console.WriteLine("    | |             CORPORATE SOLUTION             | |");
            Console.WriteLine("    | |                 CSHARP, C#                 | |");
            Console.WriteLine("  __| |____________________________________________| |__");
            Console.WriteLine(" (______________________________________________________)\n");
            bool System = true;
            Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>\r");
            Console.WriteLine("                Residential Elevators System                \r");
            Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>\r");
            /// Start controller ///
            Battery b = new Battery("Battery1");
            Console.WriteLine("- " + b.Name + " added...\n");
            b.SystemInit();
            Console.WriteLine("> Listening to outside panels");
            Console.WriteLine("> Listening to inside panels");
            Console.WriteLine("> Listening to elevators\n");
            Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>");
            Console.WriteLine("                     System Serves Calls                    \r");
            Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>\r");
            while (System)
            {
                //b.ListenOutsidePanel();
                //b.ListenInsidePanel();
                b.ServesCalls();
            }
        }
    }
}
