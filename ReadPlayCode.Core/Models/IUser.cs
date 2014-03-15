namespace ReadPlayCode.Models
{
    public interface IUser : IIdentifiable
    {
        string UserName { get; set; }

        string DisplayName { get; set; }

        string Email { get; set; }

        IRole Role {get;}
    }
}
