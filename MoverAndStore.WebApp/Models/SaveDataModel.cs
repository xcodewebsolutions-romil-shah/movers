using System.Text.Json.Serialization;

namespace MoverAndStore.WebApp.Models
{
    public class SaveDataModel
    {

        //basic_info

        public string PID { get; set; }

        [JsonPropertyName("title")]

        public string Title { get; set; }
        public string Summary { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string Company { get; set; }

        public string Address_A { get; set; }
        public string Address_B { get; set; }
        public string Address_C { get; set; }
        public bool pv_1_bool { get; set; }
        public bool pv_2_bool { get; set; }
        public bool pv_3_bool { get; set; }

        //Lead

        public string Customer { get; set; }
        public string Contact_Person { get; set; }


        //public string Pv_Extra_Info { get; set; }

        //Additional Info
        public string Extra_Info_Lift { get; set; }
        public string Lift_Location_Enum { get; set; }
        public string Lift_Type_Enum { get; set; }
        public int Number_Of_Movers { get; set; }
        public int Number_Of_Movers_Update { get; set; }

        [JsonPropertyName("items_to_dismantle")]
        public string Items_To_Dismantle { get; set; }

        [JsonPropertyName("items_to_dismantle_update")]
        public string? Items_To_Dismantle_Update { get; set; }

        [JsonPropertyName("time_estimate")]
        public string Time_Estimate { get; set; }

        [JsonPropertyName("time_estimate_update")]
        public int Time_Estimate_Update { get; set; }

        [JsonPropertyName("voertuig_enum")]
        public string? Voertuig_Enum { get; set; }

        [JsonPropertyName("Hour_start_update")]
        public string Hour_start_update { get; set; }

        [JsonPropertyName("Hour_Stop_Update")]
        public string Hour_stop_update { get; set; }

        [JsonPropertyName("voertuig_type_enum")]
        public string? Voertuig_Type_Enum { get; set; }
        public bool Lift_bool { get; set; }

        [JsonPropertyName("additional_general_info")]
        public string Additional_General_Info { get; set; }

        [JsonPropertyName("additional_general_info_update")]
        public string Additional_General_Info_update { get; set; }

        [JsonPropertyName("dismantling_bool")]
        public bool Dismantling_Bool { get; set; }

        [JsonPropertyName("dismantling_bool_update")]
        public bool Dismantling_Bool_Update { get; set; }

        //Stocakge
        public string Date_In { get; set; }
        public DateOnly? Date_In_Update { get; set; }
        public string Date_Out { get; set; }
        public DateOnly? Date_Out_Update { get; set; }

        [JsonPropertyName("cubic_meters")]
        public int Cubic_Meters { get; set; }

        [JsonPropertyName("cubic_meters_update")]
        public int Cubic_Meters_Update { get; set; }

        [JsonPropertyName("storage")]
        public string Storage { get; set; }

        [JsonPropertyName("storage_update")]
        public string Storage_Update { get; set; }

        [JsonPropertyName("zone")]
        public string Zone { get; set; }

        [JsonPropertyName("zone_update")]
        public string Zone_Update { get; set; }

        [JsonPropertyName("exact_location")]
        public string Exact_Location { get; set; }

        [JsonPropertyName("exact_location_update")]
        public string? Exact_Location_Update { get; set; }

        [JsonPropertyName("options_enum")]
        public string? Options_Enum { get; set; }

        [JsonPropertyName("insured_value")]
        public string? Insured_Value { get; set; }
        //public bool? Contract { get; set; }

        [JsonPropertyName("general_extra_info")]
        public string general_extra_info { get; set; }

        public string id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("quantity")]
        public int quantity { get; set; }

        [JsonPropertyName("quantity_update")]
        public int quantity_update { get; set; }

        [JsonPropertyName("foreman_notes")]
        public string foreman_notes { get; set; }

        public string? moving_from_date { get; set; }

        public string? moving_to_date { get; set; }

        public string? client_arrival_time_update { get; set; }

        public string?  Contact_Person_Telephone { get; set; }
             
        public string? Foreman_name { get; set; }


    }

    public class Products
    {
        public string id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("quantity")]
        public int quantity { get; set; }

        [JsonPropertyName("quantity_update")]
        public int quantity_update { get; set; }
    }
}

