namespace AccessModifiersDemo
{
    public class Base
    {
        public string PublicInfo = "public";
        private string PrivateInfo = "private";
        protected string ProtectedInfo = "protected";
        internal string InternalInfo = "internal";
        protected internal string ProtectedInternalInfo = "protected internal";
        private protected string PrivateProtectedInfo = "private protected"; // derived + same assembly

        public string ReadPrivate() => PrivateInfo; // only Base can touch its private
        public string ReadAllForSelf() =>
            $"{PublicInfo}, {PrivateInfo}, {ProtectedInfo}, {InternalInfo}, {ProtectedInternalInfo}, {PrivateProtectedInfo}";
    }

    public class Derived : Base
    {
        public string ReadFromDerived()
        {
            // Allowed in derived (same assembly): public, protected, internal, protected internal, private protected
            return $"{PublicInfo}, {ProtectedInfo}, {InternalInfo}, {ProtectedInternalInfo}, {PrivateProtectedInfo}";
        }
    }

    public class Unrelated
    {
        public string ReadFromUnrelated()
        {
            var b = new Base();
            // Allowed from unrelated (same assembly): public, internal, protected internal
            return $"{b.PublicInfo}, {b.InternalInfo}, {b.ProtectedInternalInfo}";
        }
    }
}
