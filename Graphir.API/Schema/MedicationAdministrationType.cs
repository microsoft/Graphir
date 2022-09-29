using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Graphir.API.MedicationAdministrations;

using Hl7.Fhir.Model;

using HotChocolate;
using HotChocolate.Types;

namespace Graphir.API.Schema;

public class MedicationAdministrationType : ObjectType<MedicationAdministration>
{
    protected override void Configure(IObjectTypeDescriptor<MedicationAdministration> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Id).Type<NonNullType<IdType>>();
        descriptor.Field(x => x.Meta).Type<MetaType>();
        descriptor.Field(x => x.Status).Type<StringType>();
        descriptor.Field(x => x.StatusReason).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.ReasonCode).Type<ListType<CodeableConceptType>>();
        descriptor.Field(x => x.Category).Type<CodeableConceptType>();
        descriptor.Field(x => x.Dosage).Type<DosageType>();
        descriptor.Field(x => x.Effective)
            .Type<PeriodType>().Name("effectivePeriod");
        descriptor.Field(x => x.Note).Type<StringType>();
        descriptor.Field(x => x.Performer).Type<ListType<PerformerComponentType>>();

        //#TODO: Resolvers for below fields
        // descriptor.Field(x => x.Medication)
        //     .Type<CodeableConceptType>().Name("medicationCodeableConcept");
         descriptor.Field(x => x.Subject).
             ResolveWith<MedicationAdministrationResolvers>(
                 c=>c
                     .GetRequestAsync(default!, default!, default!));
        // descriptor.Field(x => x.Request).Type<MedicationRequestType>();
        // descriptor.Field(x => x.Device).Type<ResourceReferenceType>();
        // descriptor.Field(x => x.EventHistory).Type<ListType<ResourceReferenceType>>();
    }

    protected sealed class MedicationAdministrationResolvers
    {
        public async Task<Patient> GetRequestAsync(
            [Parent] MedicationAdministration medicationAdministration,
            MedicationSubjectDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            var refs = medicationAdministration
                .Subject
                .Reference.Split('/').LastOrDefault();
            
            var result = await dataLoader.LoadAsync(refs!, cancellationToken);
            return result;
        }
    }
}



public class PerformerComponentType : ObjectType<MedicationAdministration.PerformerComponent>
{
    protected override void Configure(IObjectTypeDescriptor<MedicationAdministration.PerformerComponent> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(x => x.Actor)
            .ResolveWith<PerformerComponentResolver>
                (c => c.GetActorAsync(default!, default!, default));
        descriptor.Field(x => x.TypeName).Type<CodeableConceptType>();
        descriptor.Field(x => x.Function).Type<CodeableConceptType>();
        descriptor.Field(x => x.Extension).Type<ListType<ExtensionType>>();
    }

    protected sealed class PerformerComponentResolver
    {
        public async Task<Practitioner> GetActorAsync(
            [Parent] MedicationAdministration.PerformerComponent performerComponent,
            PerformerComponentPractitionerDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            var refs = performerComponent.Actor.Reference.Split('/').LastOrDefault();
            var result = await dataLoader.LoadAsync(refs!, cancellationToken);
            return result;
        }
    }
}