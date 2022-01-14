namespace LinqToSqlShared.DbmlObjectModel
{
	using System;
	using Resources = SqlMetal.Resources;

	internal static class Strings
    {
        internal static string Bug(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.Bug, new object[] { p0 });
        }

        internal static string DatabaseNodeNotFound(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.DatabaseNodeNotFound, new object[] { p0 });
        }

        internal static string ElementMoreThanOnceViolation(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.ElementMoreThanOnceViolation, new object[] { p0 });
        }

        internal static string InvalidBooleanAttributeValueViolation(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.InvalidBooleanAttributeValueViolation, new object[] { p0 });
        }

        internal static string InvalidEnumAttributeValueViolation(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.InvalidEnumAttributeValueViolation, new object[] { p0 });
        }

        internal static string RequiredAttributeMissingViolation(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.RequiredAttributeMissingViolation, new object[] { p0 });
        }

        internal static string RequiredElementMissingViolation(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.RequiredElementMissingViolation, new object[] { p0 });
        }

        internal static string SchemaDuplicateIdViolation(object p0, object p1)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.SchemaDuplicateIdViolation, new object[] { p0, p1 });
        }

        internal static string SchemaExpectedEmptyElement(object p0, object p1, object p2)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.SchemaExpectedEmptyElement, new object[] { p0, p1, p2 });
        }

        internal static string SchemaInvalidIdRefToNonexistentId(object p0, object p1, object p2)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.SchemaInvalidIdRefToNonexistentId, new object[] { p0, p1, p2 });
        }

        internal static string SchemaOrRequirementViolation(object p0, object p1, object p2)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.SchemaOrRequirementViolation, new object[] { p0, p1, p2 });
        }

        internal static string SchemaRecursiveTypeReference(object p0, object p1)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.SchemaRecursiveTypeReference, new object[] { p0, p1 });
        }

        internal static string SchemaRequirementViolation(object p0, object p1)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.SchemaRequirementViolation, new object[] { p0, p1 });
        }

        internal static string SchemaUnexpectedAdditionalAttributeViolation(object p0, object p1)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.SchemaUnexpectedAdditionalAttributeViolation, new object[] { p0, p1 });
        }

        internal static string SchemaUnexpectedElementViolation(object p0, object p1)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.SchemaUnexpectedElementViolation, new object[] { p0, p1 });
        }

        internal static string SchemaUnrecognizedAttribute(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.SchemaUnrecognizedAttribute, new object[] { p0 });
        }

        internal static string TypeNameNotUnique(object p0)
        {
            return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.TypeNameNotUnique, new object[] { p0 });
        }

        internal static string OwningTeam
        {
            get
            {
                return SR.GetString(Resources.LinqToSqlShared_DbmlObjectModel.OwningTeam);
            }
        }
    }
}

