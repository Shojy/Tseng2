using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Materias;
using Shojy.FF7.Reno.Models.Enums;
using Tseng.Components.Character;
using Tseng.Services;
using Tseng.Tests.Stubs;

namespace Tseng.Tests.UI.Components.Character
{
    public class CharacterProfileTests
    {
        private readonly TestContext _ctx;
        private readonly GameServiceStub _gameService;
        public CharacterProfileTests()
        {
            _ctx = new TestContext();
            _gameService = new GameServiceStub();
            _ctx.Services.AddSingleton<IGameService>(_ => _gameService);
        }

        [Fact]
        public void CharacterProfile_WithNoCharacter_ShowsEmptyBlock()
        {
            var cut = _ctx.RenderComponent<CharacterProfile>(param => param.Add(_ => _.HasData, false));

            cut.FindAll(".character")
                .Should()
                .ContainSingle("this should display exactly one character profile, even if empty.");

            // Semantic markup matching means that the class attribute doesn't need to be in order, just that it has the correct classes in
            cut.Find(".character")
                .MarkupMatches(@"<div class=""empty-character character""></div> ", "a non-empty character was found");
        }

        [Fact]
        public void CharacterProfile_WithFilledCharacter_ShowsCorrectStats()
        {
            var character = GetBaseCharacterObject() with { CurrentHP = 4000 };

            var cut = _ctx.RenderComponent<CharacterProfile>(
                builder => builder
                    .Add(_ => _.PartyMember, character)
                    .Add(_ => _.HasData, true));

            cut.FindAll(".character")
                .Should()
                .ContainSingle("this should display exactly one character profile, even if empty.");

            cut.FindAll(".stats")
                .Should()
                .ContainSingle("a filled character should display a stat block");

            cut.Find(".current-hp")
                .MarkupMatches(@"<span class:ignore>4000</span>");
        }

        [Fact]
        public void CharacterProfile_WithFilledCharacter_ShowsWhenLowHealth()
        {
            var character = GetBaseCharacterObject() with { CurrentHP = 500 };

            var cut = _ctx.RenderComponent<CharacterProfile>(param => param.Add(_ => _.PartyMember, character).Add(_ => _.HasData, true));

            cut.FindAll(".character")
                .Should()
                .ContainSingle("this should display exactly one character profile, even if empty.");

            cut.FindAll(".stats")
                .Should()
                .ContainSingle("a filled character should display a stat block");

            cut.Find(".character")
                .MarkupMatches(@"<div class=""character hp-low"" diff:ignoreChildren></div>");
        }

        private static Models.Active.Character GetBaseCharacterObject()
        {
            return new Models.Active.Character
            {
                Name = "Cloud",
                CurrentHP = 1000,
                CurrentMP = 100,
                MaxHP = 4000,
                MaxMP = 400,
                Level = 50,
                Weapon = new Weapon(),
                WeaponMateria = Array.Empty<Materia>(),
                Armor = new Armor(),
                ArmorMateria = Array.Empty<Materia>(),
                Accessory = null,
                Image = $"/images/character-cloud.png",
                Row = "back",
                Status = StatusEffects.None
            };
        }
    }
}