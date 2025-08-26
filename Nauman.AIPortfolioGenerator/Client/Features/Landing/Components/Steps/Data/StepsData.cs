using Client.Features.Landing.Components.Steps.Models;

namespace Client.Features.Landing.Components.Steps.Data
{
    public static class StepsData
    {
        public static List<StepItem> StepsList { get; } = new()
    {
        new StepItem(
            Number: 1,
            Description: "Start by signing up or logging in using your social media accounts for a seamless experience.",
            Icon: "/assets/step1.svg",
            Height: "11rem",
            PaddingLeft: "0"
        ),
        new StepItem(
            Number: 2,
            Description: "Choose the field that best represents your expertise or interest. Browse through a selection of templates tailored to your chosen field and pick the one that suits you best.",
            Icon: "/assets/step2.svg",
            Height: "11rem",
            PaddingLeft: "0"
        ),
        new StepItem(
            Number: 3,
            Description: "Personalize your chosen template by adjusting the colors, sizes, and design elements to match your style and preferences.",
            Icon: "/assets/step3.svg",
            Height: "14rem",
            PaddingLeft: "0"
        ),
        new StepItem(
            Number: 4,
            Description: "Explore the pricing options and choose a plan that fits your needs. Once satisfied with your customization, publish your portfolio to showcase your work to the world.",
            Icon: "/assets/step4.svg",
            Height: "14rem",
            PaddingLeft: "0"
        )
    };
    }
}
