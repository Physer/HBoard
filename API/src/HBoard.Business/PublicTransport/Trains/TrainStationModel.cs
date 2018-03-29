namespace HBoard.Business.PublicTransport.Trains
{
    public class TrainStationModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string StationId { get; set; }
        public string StationType { get; set; }
        public TrainStationPlace Place { get; set; }
        public TrainStationGeo LatLong { get; set; }
    }
}
