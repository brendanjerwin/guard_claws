using GuardClaws;
using Machine.Specifications;

namespace specs
{
    [Subject(typeof(Claws),"NotNull")]
    public class when_calling_NotNull_with_a_not_null_input
    {
        It should_do_nothing_if_the_input_is_not_null = ()=>
            {
                string test = string.Empty;
                Claws.NotNull(() => test);
            };
    }

    [Subject(typeof(Claws),"NotNull")]
    public class when_calling_NotNull_with_a_null_input : with_exception
    {
        Because of = () =>
            {
                string test = null;
                the_exception = Catch.Exception(() => Claws.NotNull(() => test)) as ValidationFailureException;
            };

        It should_throw_a_GuardClaws_VariableMayNotBeNullException_if_the_input_is_null = () =>
            {
                the_exception.ShouldBe(typeof (VariableMayNotBeNullException));
            };

        It should_put_the_variable_name_in_the_exception = () =>
            {
                the_exception.NameOfDelinquent.ShouldEqual("test");
            };

        It should_put_the_variable_name_in_the_message = () =>
            {
                the_exception.Message.ShouldContain("test");
            };
        
    }


}
