﻿using Graphir.API.DataLoaders;
using Hl7.Fhir.Model;
using HotChocolate.Types;

namespace Graphir.API.Schema
{
    public class CoverageType : ObjectType<Coverage>
    {
        protected override void Configure(IObjectTypeDescriptor<Coverage> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Id);
            descriptor.Field(c => c.Meta);
            descriptor.Field(c => c.Language);
            descriptor.Field(c => c.Text);
            descriptor.Field(c => c.Identifier);
            descriptor.Field(c => c.Status);
            descriptor.Field(c => c.Type);
            descriptor.Field(c => c.PolicyHolder).Type<ResourceReferenceType<CoveragePolicyHolderReferenceType>>();
            descriptor.Field(c => c.Subscriber).Type<ResourceReferenceType<CoverageSubscriberReferenceType>>();
            descriptor.Field(c => c.Beneficiary).Type<ResourceReferenceType<CoverageBeneficiaryReferenceType>>();
            descriptor.Field(c => c.Dependent);
            descriptor.Field(c => c.Relationship);
            descriptor.Field(c => c.Period);
            descriptor.Field(c => c.Payor).Type<ListType<ResourceReferenceType<CoveragePayorReferenceType>>>();
            descriptor.Field(c => c.Class).Type<ListType<CoverageClassType>>();
            descriptor.Field(c => c.Order);
            descriptor.Field(c => c.Network);
            descriptor.Field(c => c.CostToBeneficiary).Type<ListType<CoverageCostToBeneficiaryType>>();
        }
    }

    public class CoverageClassType : ObjectType<Coverage.ClassComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Coverage.ClassComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Value);
        }
    }

    public class CoverageCostToBeneficiaryType : ObjectType<Coverage.CostToBeneficiaryComponent>
    {
        protected override void Configure(IObjectTypeDescriptor<Coverage.CostToBeneficiaryComponent> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(c => c.Type);
            descriptor.Field("valueQuantity").Type<QuantityType>()
                .Resolve(r =>
                {
                    var parent = r.Parent<Coverage.CostToBeneficiaryComponent>();
                    return (parent.Value is not null && parent.Value.TypeName == "SimpleQuantity")
                        ? (Quantity)parent.Value
                        : null;
                });
            descriptor.Field("valueMoney").Type<MoneyType>()
                .Resolve(r =>
                {
                    var parent = r.Parent<Coverage.CostToBeneficiaryComponent>();
                    return (parent.Value is not null && parent.Value.TypeName == "Money")
                        ? (Money)parent.Value
                        : null;
                });
        }
    }

    public class CoveragePolicyHolderReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("CoveragePolicyHolderReference");
            descriptor.Description("Reference(Patient | RelatedPerson)");
            descriptor.Type<PatientType>();
            //descriptor.Type<RelatedPersonType>();
            descriptor.Type<OrganizationType>();
        }
    }

    public class CoverageSubscriberReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("CoverageSubscriberReference");
            descriptor.Type<PatientType>();
            //descriptor.Type<RelatedPersonType>();
        }
    }

    public class CoverageBeneficiaryReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("CoverageBeneficiaryReference");
            descriptor.Type<PatientType>();
        }
    }

    public class CoveragePayorReferenceType : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("CoveragePayorReference");
            descriptor.Description("Reference(Organization | Patient | RelatedPerson)");
            descriptor.Type<OrganizationType>();
            descriptor.Type<PatientType>();
            //descriptor.Type<RelatedPersonType>();

        }
    }

    #region QueryExtensions
    public class CoverageQuery : ObjectTypeExtension<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field("Coverage")
                .Type<CoverageType>()
                .Argument("id", a => a.Type<NonNullType<StringType>>())
                .ResolveWith<ResourceResolvers<Coverage>>(r => r.GetResource(default!, default!));

            descriptor.Field("CoverageList")
                .Type<ListType<CoverageType>>()
                .ResolveWith<ResourceResolvers<Coverage>>(r => r.GetResources(default!));
        }
    }
    #endregion
}