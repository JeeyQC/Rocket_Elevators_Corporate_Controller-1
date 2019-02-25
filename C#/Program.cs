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

    //      AddRequest      //
    //Description: Function used to add a request on an elevator requests lists. 
    private void AddRequest(Elevator elevator, int FloorNumber, string ReqList)
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
    private void WeightSensor(Elevator elevator)
    {
    //We simulate that there's a balance
    int Weight = 200; //in pounds, You can change it. 
    elevator.Weight = Weight;
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

    //      Doors       //
    //Description: Function used to open an elevators door when it is stopped.
    private void Doors(Elevator elevator)
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
    private void ServesCalls()
    {
        int i = 0;
        foreach (Elevator element in Elevators)
        {
            switch (Elevators[i].Direction)
            {
                case "Up":
                    //Case Direction UP
                    if (Elevators[i].RequestsUp.Any() && Elevators[i].Motion != "Stop"){
                        //The next request is on the elevator way.
                        if (Elevators[i].Position < Elevators[i].RequestsUp[0]){
                            if (Elevators[i].Motion != "Up"){
                                Console.WriteLine("> Elevator: " + Elevators[i].ID.ToString() + ", Started engine to go Up");
                            }
                            if (MoveUp(Elevators[i]) == Elevators[i].RequestsUp[0]){
                                Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsUp[0].ToString());
                                Elevators[i].RequestsUp.RemoveAt(0); //We can delete the floor from the list since we arrived there.
                                Elevators[i].Motion = "Stop";   //Stop means people are getting In/Out.
                                Doors(Elevators[i]);
                            }
                        }    
                        //Elevator must go pick someone and must go in the opposite direction as the calls it does.
                        else if (Elevators[i].Position > Elevators[i].RequestsUp[0]){
                            if (Elevators[i].Motion != "Down"){
                                Console.WriteLine("> Elevator: " + Elevators[i].ID + ", Started engine to go Down");
                            }
                            if (MoveDown(Elevators[i]) == Elevators[i].RequestsUp[0]){
                                Console.WriteLine(">> Elevator: " + Elevators[i] + ", Has arrived at destination on floor: " + Elevators[i].RequestsUp[0].ToString());
                                Elevators[i].RequestsUp.RemoveAt(0);
                                Elevators[i].Motion = "Stop"; 
                                Doors(Elevators[i]); //Open the doors
                            }
                        }
                    }
                    //Elevator is stopped but still has call to serve on this requests list.
                    else if (Elevators[i].RequestsUp.Any() && Elevators[i].Motion == "Stop"){
                        if (Elevators[i].Door == "Closed"){
                            if (MoveUp(Elevators[i]) == Elevators[i].RequestsUp[0]){
                                Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsUp[0].ToString());
                                Elevators[i].RequestsUp.RemoveAt(0);
                                Elevators[i].Motion = "Stop";
                                Doors(Elevators[i]);
                            }
                        }
                    }
                    //Switch direction if current request list is empty. 
                    else if (!Elevators[i].RequestsUp.Any() && Elevators[i].Motion == "Stop"){
                        if (Elevators[i].Door == "Closed"){
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
                    if (Elevators[i].RequestsDown.Any() && Elevators[i].Motion != "Stop"){
                        //The next request is on the elevator way.
                        if (Elevators[i].Position > Elevators[i].RequestsDown[0]){
                            if (Elevators[i].Motion != "Down"){
                                Console.WriteLine("> Elevator: " + Elevators[i].ID + ", Started engine to go Down");
                            }
                            if (MoveDown(Elevators[i]) == Elevators[i].RequestsDown[0]){
                                Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsDown[0].ToString());
                                Elevators[i].RequestsDown.RemoveAt(0);
                                Elevators[i].Motion = "Stop";
                                Doors(Elevators[i]);
                            }
                        }
        
                        //Elevator must go pick someone and must go in the opposite direction as the calls it does.
                        else if (Elevators[i].Position < Elevators[i].RequestsDown[0]){
                            if (Elevators[i].Motion != "Up"){
                                Console.WriteLine("> Elevator: " + Elevators[i].ID + ", Started engine to go Up");    
                            }
                            if (MoveUp(Elevators[i]) == Elevators[i].RequestsDown[0]){
                                Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsDown[0].ToString());
                                Elevators[i].RequestsDown.RemoveAt(0);
                                Elevators[i].Motion = "Stop";
                                Doors(Elevators[i]);
                            }
                        }
                    
                        //Elevator is stopped but still has call to serve on this requests list.
                        else if (Elevators[i].RequestsDown.Any() && Elevators[i].Motion == "Stop"){
                            if (Elevators[i].Door == "Closed"){
                                if (MoveDown(Elevators[i]) == Elevators[i].RequestsDown[0]){
                                    Console.WriteLine(">> Elevator: " + Elevators[i].ID + ", Has arrived at destination on floor: " + Elevators[i].RequestsDown[0].ToString());
                                    Elevators[i].RequestsDown.RemoveAt(0);
                                    Elevators[i].Motion = "Stop";
                                    Doors(Elevators[i]);
                                }
                            }
                        }
                    }
                    //Switch direction if current request list is empty.
                    else if (!Elevators[i].RequestsDown.Any() && Elevators[i].Motion == "Stop"){
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
    private void RequestElevator(int FloorNumber, string Direction){
        /** Function used to return the best elevator for that call.*/
        Console.WriteLine("> Outside Panel, Request Detected: Floor: " + String(FloorNumber) + ", Direction: " + String(Direction));
        var AvailableElevators = [];

        // STEP 1: If the elevator can receive calls, add it to Available Elevator List. 
        for (var i = 0; i < this.Elevators.length; i++){
            if (this.Elevators[i].Status == "On"){
                AvailableElevators.push(this.Elevators[i]);
            }
        }

        // STEP 2: We check if the list contain more than one elements, if yes, we check if the request is already in the good request list.
        // if the request is in one, then no need to treat the request.
        switch (true){
        case AvailableElevators.length > 1:
            for (var i = 0; i < AvailableElevators.length; i++){
                switch (true){
                    case Direction = "Up" && AvailableElevators[i].Direction == "Up":
                        if (AvailableElevators[i].RequestsUp.includes(FloorNumber)){
                            Console.WriteLine(">> Outside Panel Floor: " + String(FloorNumber) + " Direction: " + String(Direction) + ", Elevator already in requests list. Request aborted.");
                            Console.WriteLine("\n");
                            return;
                        }
                        break; //Might not need the break because we already called a return.
                    case Direction = "Down" && AvailableElevators[i].Direction == "Down":
                        if (AvailableElevators[i].RequestsDown.includes(FloorNumber)){
                            Console.WriteLine(">> Outside Panel Floor: " + String(FloorNumber) + " Direction: " + String(Direction) + ", Elevator already in requests list. Request aborted.");
                            Console.WriteLine("\n");
                            return;
                        }
                        break;
                    case Direction = "Down" && AvailableElevators[i].Direction == "Up":
                        if (AvailableElevators[i].RequestsDown.includes(FloorNumber)){
                            Console.WriteLine(">> Outside Panel Floor: " + String(FloorNumber) + " Direction: " + String(Direction) + ", Elevator already in requests list. Request aborted.");
                            Console.WriteLine("\n");
                            return;
                        }
                        break;
                    case Direction = "Up" && AvailableElevators[i].Direction == "Down":
                        if (AvailableElevators[i].RequestsUp.includes(FloorNumber)){
                            Console.WriteLine(">> Outside Panel Floor: " + String(FloorNumber) + " Direction: " + String(Direction) + ", Elevator already in requests list. Request aborted.");
                            Console.WriteLine("\n");
                            return;
                        }
                        break;
                }
            }

        // STEP 3: We check there is on element in the list that meet those requirements: If it goes in the same direction as the call 
        // AND if it has not already passed that floor.
        var OnTheWay_U = false
        var OnTheWay_D = false
        for (var i = 0; i < AvailableElevators.length; i++){
            if (AvailableElevators[i].Direction == Direction){
                var eleDif = AvailableElevators[i].Position - FloorNumber;
                switch (Direction){
                    case "Up":
                        if (eleDif < 0){
                            OnTheWay_U = true;
                        }
                    case "Down":
                        if (eleDif > 0){
                            OnTheWay_D = true;
                        }
                }
            }
        }

        //If one of the previous checks ended up True, there's no need to keep the others who doesn't meet those requirements.
        if (OnTheWay_U){
            for (var i = 0; i < AvailableElevators.length; i++){
                if (AvailableElevators[i].Direction == "Down"){
                    AvailableElevators.splice(i, 1);
                }
            }
        }
        else if (OnTheWay_D){
            for (var i = 0; i < AvailableElevators.length; i++){
                if (AvailableElevators[i].Direction == "Up"){
                    AvailableElevators.splice(i, 1);
                }
            }
        }

        // STEP 4: Once the list only contains what we are sure is the Available Elevators, we find the lowest difference between 
        // floor and elevator position, then look for the lowest number of requests.
        var minDif = 9999;
        var minReqs = 9999;
        for (var i = 0; i < AvailableElevators.length; i++){
                var eleDif = Math.abs(AvailableElevators[i].Position - FloorNumber);
                if (eleDif <= minDif){
                    minDif = eleDif;
                }
            }
        for (var i = 0; i < AvailableElevators.length; i++){
            var eleDif = Math.abs(AvailableElevators[i].Position - FloorNumber);
            var eleReqs = AvailableElevators[i].RequestsUp.length + AvailableElevators[i].RequestsDown.length;
            if (eleDif == minDif){
                if (eleReqs <= minReqs){
                    minReqs = eleReqs;
                }
            }
        }

        // STEP 5: Once we have the value of the lowest, we search it in the Available Elevators List and call the function AddRequest which add
        // the request on the elevator good list. 
        for (var i = 0; i < AvailableElevators.length; i++){
            var eleDif = Math.abs(AvailableElevators[i].Position - FloorNumber);
            var eleReqs = AvailableElevators[i].RequestsUp.length + AvailableElevators[i].RequestsDown.length;
            if (eleDif == minDif && eleReqs == minReqs){
                //Check in which Request List to add the requests.
                switch (Direction){
                    case "Up":
                        Console.WriteLine(">> Request processed, elevator found: " + String(AvailableElevators[i].ID));
                        AvailableElevators[i].AddRequest(FloorNumber, "Up");
                        break;
                    case "Down":
                        Console.WriteLine(">> Request processed, elevator found: " + String(AvailableElevators[i].ID));
                        AvailableElevators[i].AddRequest(FloorNumber, "Down");
                        break;
                }
            }
        }
        break;
    case AvailableElevators.length = 1:
         //If there is only one available elevator, send the call.
        //Check in which Request List to add the requests.
        switch (Direction){
            case "Up":
                Console.WriteLine(">> Request processed, elevator found: " + String(AvailableElevators[0].ID));
                AvailableElevators[0].AddRequest(FloorNumber, "Up");
                break;
            case "Down":
                Console.WriteLine(">> Request processed, elevator found: " + String(AvailableElevators[0].ID));
                AvailableElevators[0].AddRequest(FloorNumber, "Down");
                break;
        }
        break;
    case AvailableElevators.length = 0:
        //If nothing is added in the list, this can only mean 1: all the elevators are Off. 2: all the elevators are OutOfOrder
        //In this case the call is forgotten, light on button is turn Off and isPressed is turned back False
        for (i = 0; i < this.OutsideButtons.length; i++){
            if (this.OutsideButtons[i].Floor == FloorNumber && this.OutsideButtons[i].Direction == Direction){
                this.OutsideButtons[i].Light = "Off";
                this.OutsideButtons[i].isPressed = false;
                Console.WriteLine(">> Request processed: No elevators can receive calls at the moment, sorry. - Forget");
                Console.WriteLine("\n");
                break;
            }
        }
        break;
    }
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
