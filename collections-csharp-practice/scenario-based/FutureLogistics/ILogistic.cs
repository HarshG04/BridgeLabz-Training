namespace FutureLogistics;

interface ILogistic
{
    void CreateNewTransport();
    GoodsTransport ParseDetails(string input);
    bool ValidateTransportId(string transportId);
    string FindObjectType(GoodsTransport goodsTransport);
}