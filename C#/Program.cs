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
    public List<Elevator> ColElevator{get; set;}
    public List<int> Serve{get; set;}

    //      Constructor     //
    //Description: Initialize the column object with default value, using id.
    public Column(string id)
    {
        this.ID = id;
        this.ColElevator = new List<Elevator>();
        this.Serve = new List<int>();
    }
}

/////////////////////////////////////////
//         Class: OutsideButton        //
/////////////////////////////////////////
public class GroundFloorButton
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
    public GroundFloorButton(string id, int floor, string direction)
    {
        this.ID = id;
        this.Floor = floor;
        this.Direction = direction;
    }
}

/////////////////////////////////////////
//         Class: FloorButton         //
/////////////////////////////////////////
public class FloorButton
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
    public FloorButton(string id, int floor, Elevator elevator)
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
    public List<GroundFloorButton> GroundFloorButtons{get;}
    public List<FloorButton> FloorButtons{get;}
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
        this.GroundFloorButtons = new List<GroundFloorButton>();
        this.FloorButtons = new List<FloorButton>();
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
        Console.WriteLine("ELEVATORS");
        int i = 0;
        foreach (Elevator elevator in Elevators)
        {
            if (elevator.RequestsUp.Any() && elevator.RequestsDown.Any()){
                Console.WriteLine("ID: " + elevator.ID + ", Status: " + elevator.Status + ", Direction: " + elevator.Direction + ", Motion: " + elevator.Motion + ", Positon: " + elevator.Position + ", Door: " + elevator.Door + ", Requests Up: [" + string.Join(',', elevator.RequestsUp) + "], Requests Down: [" + string.Join(',', elevator.RequestsDown) + "]");
            }
            else if (elevator.RequestsUp.Any() && !elevator.RequestsDown.Any()){
                Console.WriteLine("ID: " + elevator.ID + ", Status: " + elevator.Status + ", Direction: " + elevator.Direction + ", Motion: " + elevator.Motion + ", Positon: " + elevator.Position.ToString() + ", Door: " + elevator.Door.ToString() + ", Requests Up: [" + string.Join(',', elevator.RequestsUp) + "], Requests Down: []");
            }
            else if (!elevator.RequestsUp.Any() && elevator.RequestsDown.Any()){
                Console.WriteLine("ID: " + elevator.ID + ", Status: " + elevator.Status + ", Direction: " + elevator.Direction + ", Motion: " + elevator.Motion + ", Positon: " + elevator.Position.ToString() + ", Door: " + elevator.Door.ToString() + ", Requests Up: [], Requests Down: [" + string.Join(',', elevator.RequestsDown) + "]");
            }
            else if (!elevator.RequestsUp.Any() && !elevator.RequestsDown.Any()){
                Console.WriteLine("ID: " + elevator.ID + ", Status: " + elevator.Status + ", Direction: " + elevator.Direction + ", Motion: " + elevator.Motion + ", Positon: " + elevator.Position.ToString() + ", Door: " + elevator.Door.ToString() + ", Requests Up: [], Requests Down: []");
            }
            i++;
        }
        Console.WriteLine("\r");
    }

    //      Show Columns    //
    //Description: Function used to show all the column in the Columns list.
    public void ShowColumns()
    {
        Console.WriteLine("COLUMNS");
        int i = 0;
        int n = 0;
        foreach (Column column in Columns)
        {
            List<string> EleID = new List<string>();
            n = 0;
            foreach (Elevator e in column.ColElevator)
            {
                EleID.Add(e.ID);
                n++;
            }
            Console.WriteLine("ID: " + column.ID + ", Elevators: [" + string.Join(',', EleID) + "]");
            i++;
        }
       Console.WriteLine("\r");
    }

    //      Show GroundFloorButtons     //
    //Description: Function used to show all the outside buttons in the OutsideButtons list.
    public void ShowGroundFloorButtons()
    {
        Console.WriteLine("Ground Floor Buttons:");
        int i = 0;
        foreach (GroundFloorButton GfBtn in GroundFloorButtons)
        {
            Console.WriteLine("ID: " + GfBtn.ID + ", Floor: " + GfBtn.Floor.ToString() + ", Direction: " + string.Join(',',GfBtn.Direction) + ", IsPressed: " + string.Join(',',GfBtn.IsPressed) + ", Light: " + string.Join(',',GfBtn.Light));
            i++;
        }
    }

    //      Show Floor Buttons     //
    //Description: Function used to show all the inside buttons in the InsideButtons list.
    public void ShowFloorButtons()
    {
        Console.WriteLine("Floor Buttons:");
        int i = 0;
        foreach (FloorButton fBtn in FloorButtons)
        {
            Console.WriteLine("ID: " + fBtn.ID + ", Floor: " + string.Join(',',fBtn.Floor) + ", Elevator: " + string.Join(',',fBtn.Elevator) + ", IsPressed: " + string.Join(',',fBtn.IsPressed) + ", Light: " + string.Join(',',fBtn.Light));
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
            if (elevator.Weight >= MaxWeight){
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
        foreach (Elevator elevator in Elevators)
        {
            switch (elevator.Direction)
            {
                case "Up":
                    //Case Direction UP
                    if (elevator.RequestsUp.Any() && elevator.Motion != "Stop")
                    {
                        //The next request is on the elevator way.
                        if (elevator.Position < elevator.RequestsUp[0])
                        {
                            if (elevator.Motion != "Up")
                            {
                                Console.WriteLine("> Elevator: " + elevator.ID.ToString() + ", Started engine to go Up");
                            }
                            if (MoveUp(elevator) == elevator.RequestsUp[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.RequestsUp[0].ToString());
                                elevator.RequestsUp.RemoveAt(0); //We can delete the floor from the list since we arrived there.
                                elevator.Motion = "Stop";   //Stop means people are getting In/Out.
                                Doors(elevator);
                            }
                        }    
                        //Elevator must go pick someone and must go in the opposite direction as the calls it does.
                        else if (elevator.Position > elevator.RequestsUp[0])
                        {
                            if (elevator.Motion != "Down")
                            {
                                Console.WriteLine("> Elevator: " + elevator.ID + ", Started engine to go Down");
                            }
                            if (MoveDown(elevator) == elevator.RequestsUp[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.RequestsUp[0].ToString());
                                elevator.RequestsUp.RemoveAt(0);
                                elevator.Motion = "Stop"; 
                                Doors(elevator); //Open the doors
                            }
                        }
                    }
                    //Elevator is stopped but still has call to serve on this requests list.
                    else if (elevator.RequestsUp.Any() && elevator.Motion == "Stop")
                    {
                        if (elevator.Door == "Closed"
                        ){
                            if (MoveUp(elevator) == elevator.RequestsUp[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.RequestsUp[0].ToString());
                                elevator.RequestsUp.RemoveAt(0);
                                elevator.Motion = "Stop";
                                Doors(elevator);
                            }
                        }
                    }
                    //Switch direction if current request list is empty. 
                    else if (!elevator.RequestsUp.Any() && elevator.Motion == "Stop")
                    {
                        if (elevator.Door == "Closed")
                        {
                            if (elevator.RequestsDown.Any())
                            {
                                elevator.Direction = "Down"; //It will be treated in the next iteration of the loop. We want to treat it in the Down section now. 
                            }
                            else if (!elevator.RequestsDown.Any())
                            {
                                elevator.Direction = "Idle";
                                elevator.Motion = "Idle";
                                Console.WriteLine(">>>> Elevator: " + elevator.ID + " is now Idle");
                            }
                        }
                    }
                    break;
                case "Down":
                    //Case Direction = Down
                    if (elevator.RequestsDown.Any() && elevator.Motion != "Stop")
                    {
                        //The next request is on the elevator way.
                        if (elevator.Position > elevator.RequestsDown[0])
                        {
                            if (elevator.Motion != "Down")
                            {
                                Console.WriteLine("> Elevator: " + elevator.ID + ", Started engine to go Down");
                            }
                            if (MoveDown(elevator) == elevator.RequestsDown[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.RequestsDown[0].ToString());
                                elevator.RequestsDown.RemoveAt(0);
                                elevator.Motion = "Stop";
                                Doors(elevator);
                            }
                        }
        
                        //Elevator must go pick someone and must go in the opposite direction as the calls it does.
                        else if (elevator.Position < elevator.RequestsDown[0])
                        {
                            if (elevator.Motion != "Up")
                            {
                                Console.WriteLine("> Elevator: " + elevator.ID + ", Started engine to go Up");    
                            }
                            if (MoveUp(elevator) == elevator.RequestsDown[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.RequestsDown[0].ToString());
                                elevator.RequestsDown.RemoveAt(0);
                                elevator.Motion = "Stop";
                                Doors(elevator);
                            }
                        }
                    
                        //Elevator is stopped but still has call to serve on this requests list.
                        else if (elevator.RequestsDown.Any() && elevator.Motion == "Stop")
                        {
                            if (elevator.Door == "Closed")
                            {
                                if (MoveDown(elevator) == elevator.RequestsDown[0])
                                {
                                    Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.RequestsDown[0].ToString());
                                    elevator.RequestsDown.RemoveAt(0);
                                    elevator.Motion = "Stop";
                                    Doors(elevator);
                                }
                            }
                        }
                    }
                    //Switch direction if current request list is empty.
                    else if (!elevator.RequestsDown.Any() && elevator.Motion == "Stop")
                    {
                        if (elevator.Door == "Closed")
                        {
                            if (elevator.RequestsUp.Any())
                            {
                                elevator.Direction = "Up"; //It will be treated in the next iteration of the loop. We want to treat it in the Up section now.
                            }
                            else if (!elevator.RequestsUp.Any())
                            {
                                elevator.Direction = "Idle";
                                elevator.Motion = "Idle";
                                Console.WriteLine(">>>> Elevator: " + elevator.ID + " is now Idle");
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
        foreach (Elevator elevator in Elevators)
        {
            if (elevator.Status == "On")
            {
                AvailableElevators.Add(elevator);
            }
        }

        if (AvailableElevators.Count() > 1)
        {
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                switch (Direction)
                {
                    case "Up":
                        if (AvailableElevator.Direction == "Up")
                        {
                            if (AvailableElevator.RequestsUp.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " Direction: " + Direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                        else if (AvailableElevator.Direction == "Down")
                        {
                            if (AvailableElevator.RequestsUp.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " Direction: " + Direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                    break;
                    case "Down":
                        if (AvailableElevator.Direction == "Down")
                        {
                            if (AvailableElevator.RequestsDown.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " Direction: " + Direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                        else if (AvailableElevator.Direction == "Up")
                        {
                            if (AvailableElevator.RequestsDown.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " Direction: " + Direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                    break;
                }
            }
                
            // STEP 3: We check there is on element in the list that meet those requirements: If it goes in the same direction as the call 
            // AND if it has not already passed that floor.
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                if (AvailableElevator.Direction == Direction)
                {
                    eleDif = AvailableElevator.Position - FloorNumber;
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
            }

            //If one of the previous checks ended up True, there's no need to keep the others who doesn't meet those requirements.
            if (OnTheWay_U)
            {
                i = 0;
                foreach (Elevator AvailableElevator in AvailableElevators)
                {
                    if (AvailableElevator.Direction == "Down")
                    {
                        AvailableElevators.RemoveAt(i);
                    }
                    i++;
                }
            }
            else if (OnTheWay_D)
            {   
                i = 0;
                foreach (Elevator AvailableElevator in AvailableElevators)
                {
                    if (AvailableElevator.Direction == "Up")
                    {
                        AvailableElevators.RemoveAt(i);
                    }
                    i++;
                }
            }

            // STEP 4: Once the list only contains what we are sure is the Available Elevators, we find the lowest difference between 
            // floor and elevator position, then look for the lowest number of requests.
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                eleDif = Math.Abs(AvailableElevator.Position - FloorNumber);
                if (eleDif <= minDif)
                {
                    minDif = eleDif;
                }
            }
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                eleDif = Math.Abs(AvailableElevator.Position - FloorNumber);
                eleReqs = AvailableElevator.RequestsUp.Count() + AvailableElevator.RequestsDown.Count();
                if (eleDif == minDif)
                {
                    if (eleReqs <= minReqs)
                    {
                        minReqs = eleReqs;
                    }
                }
            }

            // STEP 5: Once we have the value of the lowest, we search it in the Available Elevators List and call the function AddRequest which add
            // the request on the elevator good list. 
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                eleDif = Math.Abs(AvailableElevator.Position - FloorNumber);
                eleReqs = AvailableElevator.RequestsUp.Count() + AvailableElevator.RequestsDown.Count();
                if (eleDif == minDif && eleReqs == minReqs)
                {
                    //Check in which Request List to add the requests.
                    switch (Direction)
                    {
                        case "Up":
                            Console.WriteLine(">> Request processed, elevator found: " + AvailableElevator.ID);
                            AddRequest(AvailableElevator, FloorNumber, "Up");
                            break;
                        case "Down":
                            Console.WriteLine(">> Request processed, elevator found: " + AvailableElevator.ID);
                            AddRequest(AvailableElevator, FloorNumber, "Down");
                            break;
                    }
                }
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
            foreach (GroundFloorButton GfBtn in GroundFloorButtons)
            {
                if (GfBtn.Floor == FloorNumber && GfBtn.Direction == Direction)
                {
                    GfBtn.Light = false;
                    GfBtn.IsPressed = false;
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
        foreach (GroundFloorButton GfBtn in GroundFloorButtons)
        {
            if (GfBtn.IsPressed == true)
            {
                GfBtn.Light = true;
                floor = GfBtn.Floor;
                direction = GfBtn.Direction;
                GfBtn.IsPressed = false;
                RequestElevator(floor, direction);
            }
        }
    }

    //  Listen Floor Panel  //
    //Description: Function used to determine which buttons is pressed 
    //inside an elevator and call the function RequestFloor.
    public void ListenFloorPanel()
    {
        Elevator elevator;
        int floor;
        foreach (FloorButton fBtn in FloorButtons)
        {
            if (fBtn.IsPressed == true)
            {
                fBtn.Light = true;
                elevator = fBtn.Elevator;
                floor = fBtn.Floor;
                fBtn.IsPressed = false;
                RequestFloor(elevator, floor);
                //Now we have all to call the requestFloor, once its done, button is not pressed anymore.
            }
        }
    }

    // System Initialization //                     
    public void SystemInit()
    {
        //Variables declaration
        int i = 1;
        int a = 1;
        int n = 1;
        double b = Math.Floor((double)NbFloors/(double)NbColumns);       //To lower value cause no overlap so 16 in this case
        int z = (int)b;
        int tempZ;
        int tempA;

        Console.WriteLine("                    System Initialization                   ");
        Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>");
        //    Populate All Lists  //
        //Elevators List
        i = 1;
        while (i <= NbElevators)
        {
            string ID = "ele" + i.ToString();
            Elevator e = new Elevator(ID);
            Elevators.Add(e);
            i++;;
        }
        
        //Columns List
        i = 1;
        while (i <= NbColumns)
        {
            string ID = "col" + i.ToString();
            Column column = new Column(ID);
            Columns.Add(column);
            i++;;
        }
        
        //GroundFloorButtons List
        i = 2;
        while (i <= NbFloors)
        {
            string ID_Up = "GfBtn_Floor" + i.ToString();
            GroundFloorButton btn = new GroundFloorButton(ID_Up, i, "UP");
            GroundFloorButtons.Add(btn);
            i++;;
        }
        
        //FloorButtons List
        i = 2;
        while (i <= NbElevators)
        {
            string ID = "iBtn" + i.ToString();
            FloorButton iB = new FloorButton(ID, i, Elevators[i-1]);
            FloorButtons.Add(iB);
            i++;
        }
        
        //Column attribute ColElevator in Columns List
        i = 0;
        foreach (Column column in Columns)
        {
            n = 1;
            while (n <= NbElevatorsByColumns)
            {
                if (Elevators.ElementAtOrDefault(i) != null)
                {
                    column.ColElevator.Add(Elevators[i]);
                    i++;
                    n++;
                }
                else
                {
                    break;
                }
            }
        }

        //Add the range of floors to column
        i = 1;
        while (i <= NbFloors)
        {
            foreach (Column column in Columns)
            {
                tempZ = a + z;
                column.Serve.Add(a);
                column.Serve.Add(tempZ);
                tempA = tempZ + 1;
                a = tempA;
                i = tempZ;
            }
            i++;
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
            Console.WriteLine("Enter the building informations:");
            b.Input();
            b.SystemInit();
            Console.WriteLine("> Listening to outside panels");
            Console.WriteLine("> Listening to inside panels");
            Console.WriteLine("> Listening to elevators\n");
            Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>");
            Console.WriteLine("                     System Serves Calls                    \r");
            Console.WriteLine("<<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>><<>>\r");
            //b.ShowElevators();
            //b.ShowColumns();
            b.ShowGroundFloorButtons();
            b.ShowFloorButtons();
            while (System)
            {
                //b.ListenOutsidePanel();
                //b.ListenFloorPanel();
                b.ServesCalls();
            }
        }
    }
}
