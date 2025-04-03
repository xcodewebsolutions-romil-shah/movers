using System.Text.Json.Serialization;

namespace MoverAndStore.WebApp.Models
{
    public class SaveDataModel
    {

        //basic_info

        public string PID { get; set; }

        public string Title { get; set; }       
       
        public string Living_1_Levels { get; set; }
        public string option1 { get; set; }

        public string option2 { get; set; }

        public string option3 { get; set; }

        public string Contact_Person { get; set; }
        public string wardrobe_boxes { get; set; }
        public string folieboxes { get; set; }
        public string extra_info { get; set; }
        public string estimated_movers { get; set; }
        public string type_moving_wagen { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }

        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string Address_3 { get; set; }

        public bool Parking_1_bool { get; set; }

        public bool Parking_2_bool { get; set; }

        public bool Parking_3_bool { get; set; }

        public string Type_1_Living { get; set; }
        public string Living_1_Layers { get; set; }

        public string Moving_Date { get; set; }
        public bool lift_1_bool { get; set; }
        public string lift_1_distance_door { get; set; }
        public string boxes_update { get; set; }
        public string boxes { get; set; }
        public string wardrobe_boxes_update { get; set; }
        public string folie_update { get; set; }       
        public string Type_2_Living { get; set; }
        public string estimated_movers_update { get; set; }
        public string Living_2_Levels { get; set; }
        public string Living_2_Layers { get; set; }
        public bool Lift_2_Bool { get; set; }
        public string Lift_2_Distance_Door { get; set; }
        public string Type_3_Living { get; set; }
        public string Living_3_Levels { get; set; }
        public string Living_3_Layers { get; set; }
        public bool Lift_3_Bool { get; set; }
        public string Lift_3_Distance_Door { get; set; }
        public bool Furniture_Assembly_Bool { get; set; }
        public string Items_To_Assemble { get; set; }
        public bool Box_Packing_Service_Bool { get; set; }
        public string Content_1 { get; set; }
        public string Content_2 { get; set; }
    }

}

