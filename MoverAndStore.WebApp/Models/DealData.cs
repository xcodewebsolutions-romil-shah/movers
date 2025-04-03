using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MoverAndStore.WebApp.Models
{
    public class DealData
    {
        [JsonPropertyName("basic_information")]
        public BasicInformation Basic_Information { get; set; }

        [JsonPropertyName("CRM_info")]
        public CrmInfo Crminfo { get; set; }

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }

        [JsonPropertyName("notes_group")]
        public Notes Notes { get; set; }

        [JsonPropertyName("user_dashboard")]
        public Userashboard user_dashboard { get; set; }


    }

    public class BasicInformation
    {
        public string id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("company")]
        public string? Company { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }
        //public string Address_Group { get; set; }

        [JsonPropertyName("lead")]
        public Lead Lead { get; set; }

        [JsonPropertyName("moving_date")]
        public DateTime? Moving_Date { get; set; }

        [JsonPropertyName("addresses_group")]
        public AddressGroup AddressGroup { get; set; }

        [JsonPropertyName("material_group")]
        public MaterialGroup MaterialGroup { get; set; }

        [JsonPropertyName("prefered_dates_group")]
        public PreferedDatesGroup PreferedDatesGroup { get; set; }

        [JsonPropertyName("Extra_info_group")]
        public Extra_info_group Extra_Info_Group { get; set; }

        [JsonPropertyName("activities_group")]
        public Activitiesgroup Activitiesgroup { get; set; }

        [JsonPropertyName("content_group")]
        public ContentGroup ContentGroup { get; set;  }

    }

    public class MaterialGroup
    {
        public string boxes { get; set; }
        public string boxes_update { get; set; }
        public string wardrobe_boxes { get; set; }
        public string wardrobe_boxes_update { get; set; }
        public string folie { get; set; }
        public string folie_update { get; set; }
    }

    public class PreferedDatesGroup
    {
        [JsonPropertyName("option_1")]
        public DateTime? option1 { get; set; }

        [JsonPropertyName("option_2")]
        public DateTime? option2 { get; set; }

        [JsonPropertyName("option_3")]
        public DateTime? option3 { get; set; }
    }

    public class Extra_info_group
    {
        public string extra_info { get; set; }
        public string estimated_movers { get; set; }
        public string estimated_movers_update { get; set; }
        public string type_moving_wagen { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
    }

    
    //public class AdditionalInfo
    //{
    //    [JsonPropertyName("extra_info_lift")]

    //    public string Extra_Info_Lift { get; set; }

    //    [JsonPropertyName("lift_bool")]
    //    public bool Lift_bool { get; set; }

    //    [JsonPropertyName("lift_location_enum")]
    //    public string Lift_Location_Enum { get; set; }

    //    [JsonPropertyName("lift_type_enum")]
    //    public string Lift_Type_Enum { get; set; }

    //    [JsonPropertyName("voertuig_enum")]
    //    public string Voertuig_Enum { get; set; }

    //    [JsonPropertyName("Hour_start_update")]       
    //    public string Hour_start_update { get; set; }

    //    [JsonPropertyName("Hour_Stop_Update")]
    // public string Hour_stop_update { get; set; }

    //    [JsonPropertyName("voertuig_type_enum")]
    //    public string Voertuig_Type_Enum { get; set; }

    //    [JsonPropertyName("number_of_movers")]
    //    public string Number_Of_Movers { get; set; }

    //    [JsonPropertyName("number_of_movers_update")]
    //    public string Number_Of_Movers_Update { get; set; }

    //    [JsonPropertyName("dismantling_bool")]
    //    public bool Dismantling_Bool { get; set; }

    //    [JsonPropertyName("dismantling_bool_update")] 
    //    public bool Dismantling_Bool_Update { get; set; } = false;

    //    [JsonPropertyName("time_estimate")]
    //    public string Time_Estimate { get; set; }

    //    [JsonPropertyName("time_estimate_update")]
    //    public string Time_Estimate_Update { get; set; }

    //    [JsonPropertyName("items_to_dismantle")]
    //    public string Items_To_Dismantle { get; set; }

    //    [JsonPropertyName("items_to_dismantle_update")]
    //    public string Items_To_Dismantle_Update { get; set; }

    //    [JsonPropertyName("additional_general_info")]
    //    public string Additional_General_Info { get; set; }

    //    [JsonPropertyName("additional_general_info_update")]
    //    public string Additional_General_Info_update { get; set; }
    //}

    //public class MovingDate
    //{
    //    public DateTime? moving_from_date { get; set; }

    //    public DateTime? moving_to_date { get; set; }

    //    public DateTime? client_arrival_time_update { get; set; }
    //}

    //public class Stockage
    //{
    //    [JsonPropertyName("date_in")]
    //    public DateTime? Date_In { get; set; }

    //    [JsonPropertyName("date_in_update")]
    //    public string? Date_In_Update { get; set; }

    //    [JsonPropertyName("date_out")]
    //    public DateTime? Date_Out { get; set; }

    //    [JsonPropertyName("date_out_update")]
    //    public string Date_Out_Update { get; set; }

    //    [JsonPropertyName("cubic_meters")]
    //    public string  Cubic_Meters { get; set; }

    //    [JsonPropertyName("cubic_meters_update")]
    //    public string Cubic_Meters_Update { get; set; }

    //    [JsonPropertyName("storage")]
    //    public string Storage { get; set; }

    //    [JsonPropertyName("storage_update")]
    //    public string Storage_Update { get; set; }

    //    [JsonPropertyName("zone")]
    //    public string Zone { get; set; }

    //    [JsonPropertyName("zone_update")]
    //    public string Zone_Update { get; set; }

    //    [JsonPropertyName("exact_location")]
    //    public string Exact_Location { get; set; }

    //    [JsonPropertyName("exact_location_update")]
    //    public string Exact_Location_Update { get; set; }

    //    [JsonPropertyName("options_enum")]
    //    public string Options_Enum { get; set; }

    //    [JsonPropertyName("insured_value")]
    //    public string Insured_Value { get; set; }

    //    [JsonPropertyName("contract")]
    //    public bool Contract { get; set; }
    //}

    public class Lead
    {
        [JsonPropertyName("contact_person")]
        public string Contact_Person { get; set; }

        [JsonPropertyName("customer")]
        public string Customer { get; set; }

        [JsonPropertyName("contact_person_telephone")]
        public string Contact_Person_Telephone { get; set; }

        [JsonPropertyName("company_name")]

        public string Company_Name { get; set; }


    }

    public class Activitiesgroup
    {
        [JsonPropertyName("furniture_assembly_bool")]
        public bool Furniture_Assembly_Bool { get; set; }

        [JsonPropertyName("items_to_assemble")]
        public string Items_To_Assemble { get; set; }

        [JsonPropertyName("box_packing_service_bool")]
        public bool Box_Packing_Service_Bool { get; set; }

    }

    public class AddressGroup
    {
        [JsonPropertyName("address_1")]
        public string Address_1 { get; set; }

        [JsonPropertyName("Parking_1_bool")]
        public bool Parking_1_bool { get; set; }

        [JsonPropertyName("Parking_2_bool")]
        public bool Parking_2_bool { get; set; }

        [JsonPropertyName("Parking_3_bool")]
        public bool Parking_3_bool { get; set; }

        [JsonPropertyName("type_1_living")]
        public string Type_1_Living { get; set; }

        [JsonPropertyName("living_1_levels")]
        public string Living_1_Levels { get; set; }

        [JsonPropertyName("address_3")]
        public string Address_3 { get; set; }

        [JsonPropertyName("address_2")]
        public string Address_2 { get; set; }

        [JsonPropertyName("living_1_layers")]
        public string Living_1_Layers { get; set; }

        [JsonPropertyName("lift_1_bool")]
        public bool Lift_1_Bool { get; set; }

        [JsonPropertyName("lift_1_distance_door")]
        public string Lift_1_Distance_Door { get; set; }

        [JsonPropertyName("lift_1_type")]
        public string Lift_1_Type { get; set; }

        [JsonPropertyName("type_2_living")]
        public string Type_2_Living { get; set; }

        [JsonPropertyName("living_2_levels")]
        public string Living_2_Levels { get; set; }

        [JsonPropertyName("living_2_layers")] 
        public string Living_2_Layers { get; set; }

        [JsonPropertyName("lift_2_bool")]
        public bool Lift_2_Bool { get; set; }

        [JsonPropertyName("lift_2_distance_door")]
        public string Lift_2_Distance_Door { get; set; }

        [JsonPropertyName("lift_2_type")]
        public string Lift_2_Type { get; set; }

        [JsonPropertyName("type_3_living")]
        public string Type_3_Living { get; set; }

        [JsonPropertyName("living_3_levels")]
        public string Living_3_Levels { get; set; }

        [JsonPropertyName("living_3_layers")]
        public string Living_3_Layers { get; set; }

        [JsonPropertyName("lift_3_bool")]
        public bool Lift_3_Bool { get; set; }

        [JsonPropertyName("lift_3_distance_door")]
        public string Lift_3_Distance_Door { get; set; }

        [JsonPropertyName("lift_3_type")]
        public string Lift_3_Type { get; set; }

    }


    public class CrmInfo
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("client")]
        public string Client { get; set; }
        [JsonPropertyName("responsible")]
        public string Responsible { get; set; }
        [JsonPropertyName("pipeline")]
        public string Pipeline { get; set; }
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("success_percentage")]
        public string Success_percentage { get; set; }

    }

    public class ContentGroup
    {
        [JsonPropertyName("content_1")]
        public string Content_1 { get; set; }
        
        [JsonPropertyName("content_2")]
        public string Content_2 {get; set;}
      
    }

    public class Product
    {
        [JsonPropertyName("id")]

        public string id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("quantity")]
        public int quantity { get; set; }

        [JsonPropertyName("quantity_update")]
        public int quantity_update { get; set; }

    }

    public class Notes
    {
        [JsonPropertyName("foreman_notes")]
        public string foreman_notes { get; set; }
    }

    public class Userashboard
    {
        [JsonPropertyName("foreman_name")]
        public string Foremanname { get; set; }

    }
}
