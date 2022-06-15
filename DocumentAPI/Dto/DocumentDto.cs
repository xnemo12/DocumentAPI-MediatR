using DocumentAPI.Models;

namespace DocumentAPI.Dto
{
    public record DocumentDto(Guid Id, string Data, Status Status, DateTime CreatedDate, DateTime ModifedDate);
    public record DocumentForEditDto (string Data);
}
