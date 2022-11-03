using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class AccountType : ObjectType<Account>
{
    // TODO: finish Account
    protected override void Configure(IObjectTypeDescriptor<Account> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(x => x.Id);
    }
}
