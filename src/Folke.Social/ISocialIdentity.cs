namespace Folke.Social
{
    public interface ISocialIdentity
    {
        string FirstName { get; }
        string LastName { get; }
        string Nickname { get; }
        string Id { get; }
    }
}
