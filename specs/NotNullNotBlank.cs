using GuardClaws;
using Machine.Specifications;

namespace specs
{
    [Subject(typeof (Claws), "NotNullNotBlank")]
    public class when_called_with_a_valid_input
    {
        It should_do_nothing = () =>
            {
                var test = "valid value";
                Claws.NotNullNotBlank(()=>test);
            };
    }

    [Subject(typeof (Claws), "NotNullNotBlank")]
    public class when_called_with_a_null_input : with_exception
    {
        
    }
}    