#r "Newtonsoft.Json"

using System.Collections.Generic;
using Newtonsoft.Json;

public class SystemMessage
{
    public string Type {get; set;}
    public string Module {get; set;}
    public string Code {get; set;}
    public string Text {get; set;}
}

public class BaseInfo
{
    public string id {get; set;}
    public string name {get; set;}
    public string type {get; set;} 
}

public class Parent
{
    public string id {get; set;}
    public string name {get; set;}
    public string type {get; set;}
    public BaseInfo parent {get; set;}
}

public class Download
{
    public string type {get; set;}
    public string url {get; set;}
}

public class Properties
{
    public List<Download> downloads {get; set;}
    public string WheelchairAccess {get; set;}
} 

public class Stop
{
    public bool isGlobalId {get; set;}
    public string id {get; set;}
    public string name {get; set;}
    public string type {get; set;}
    public List<float> coord {get; set;}
    public Parent parent {get; set;}
    public string departureTimePlanned {get; set;}
    public string departureTimeEstimated {get; set;}
    public Properties properties {get; set;}
}

public class Product
{
    [JsonProperty("class")]
    public int _class {get; set;} 
    public string name {get; set;}
    public int iconId {get; set;}
}

public class Operator
{
    public string id {get; set;}
    public string name {get; set;}
}

public class Destination
{
    public string name {get; set;}
    public string type {get; set;}
}

public class TransportationProperties
{
    public bool isTTB {get; set;}
    public int tripCode {get; set;}
    public string mtSubcode {get; set;}
    public string RealtimeTripId {get; set;}
}

public class Transportation
{
    public string id {get; set;}
    public string name {get; set;}
    public string disassembledName {get; set;}
    public string number {get; set;}
    public int iconId {get; set;}
    public string description {get; set;}
    public Product product {get; set;}
    [JsonProperty("operator")]
    public Operator _operator {get; set;}
    public Destination destination {get; set;}
    public TransportationProperties properties {get; set;}
}

public class Loc
{
    public string id {get; set;}
    public string type {get; set;}
    public List<float> coord {get; set;}    
}

public class GeoLoc
{
    public Loc location {get; set;}
    public int area {get; set;}
    public int platform {get; set;}
    public string georef {get; set;}
}

public class FootPathElem 
{
    public string description {get; set;}
    public string type {get; set;}
    public int levelFrom {get; set;}
    public int levelTo {get; set;}
    public string level {get; set;}
    public GeoLoc origin {get; set;}
    public GeoLoc destination {get; set;}
}

public class FootPathInfo
{
    public string position {get; set;}
    public int duration {get; set;}
    public List<FootPathElem> footPathElem {get; set;}
}

public class Interchange 
{
    public string desc {get; set;}
    public int type {get; set;}
    public List<List<float>> coords {get; set;}
    
}

public class Properties
{
    public string PlanLowFloorVehicle {get; set;}
    public string PlanWheelChairAccess {get; set;}
}

public class Leg
{
    public int duration {get; set;}
    public Stop origin {get; set;}
    public Stop destination {get; set;}
    public Transportation transportation {get; set;}
    public List<Stop> stopSequence {get; set;}
    public List<FootPathInfo> footPathInfo {get; set;}
    public List<object> infos {get; set;}
    public List<List<float>> coords {get; set;}
    public Interchange interchange {get; set;}
    public Properties properties {get; set;}
}

public class TicketProperties
{
    public string riderCategoryName {get; set;}
    public string priceStationAccessFee {get; set;}
    public string priceTotalFare {get; set;}
}

public class Ticket
{
    public string id {get; set;}
    public string name {get; set;}
    public string comment {get; set;}
    public string URL {get; set;}
    public string currency {get; set;}
    public string priceLevel {get; set;}
    public float priceBrutto {get; set;}
    public int priceNetto {get; set;}
    public int taxPercent {get; set;}
    public int fromLeg {get; set;}
    public int toLeg {get; set;}
    public string net {get; set;}
    public string person {get; set;}
    public string travellerClass {get; set;}
    public string timeValidity {get; set;}
    public int validMinutes {get; set;}
    public string isShortHaul {get; set;}
    public string returnsAllowed {get; set;}
    public string validForOneJourneyOnly {get; set;}
    public string validForOneOperatorOnly {get; set;}
    public int numberOfChanges {get; set;}
    public string nameValidityArea {get; set;}
    public string relationID {get; set;}
    public string relationCode {get; set;}
    public string relationName {get; set;}
    public TicketProperties properties {get; set;}
}

public class Zone
{
    public string net {get; set;}
    public int toLeg {get; set;}
    public int fromLeg {get; set;}
    public string neutralZone {get; set;}
    public List<Zone> zones {get; set;}
}

public class Fare
{
    public List<Ticket> tickets {get; set;}
    public List<Zone> zones {get; set;}
}

public class Journey
{
    public int rating {get; set;}
    public bool isAdditional {get; set;}
    public int interchanges {get; set;}
    public List<Leg> legs {get; set;}
    public Fare fare {get; set;}
}

public class TripInfo
{
    public string version {get; set;}
    public object systemMessages {get; set;}
    public object journeys {get; set;}
}

