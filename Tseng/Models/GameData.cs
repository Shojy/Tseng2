using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Items;
using Shojy.FF7.Elena.Materias;
using Shojy.FF7.Reno.Models;
using Shojy.FF7.Reno.Models.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tseng.Models.Active;
using Tseng.Models.Enums;

namespace Tseng.Models;

public class GameData : INotifyPropertyChanged
{
    private BattleMap _battleMap;
    private GameState _gameState = GameState.Disconnected;
    private Item[] _items = Array.Empty<Item>();
    private Materia[] _materias = Array.Empty<Materia>();
    private SaveMap _saveMap;
    private WindowColor _windowColor;
    private bool _isBattle;
    private ActiveGameData _activeData;

    public ActiveGameData ActiveData
    {
        get => _activeData;
        private set
        {
            if (value == _activeData) return;

            _activeData = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public Accessory[] Accessories { get; private set; } = Array.Empty<Accessory>();

    public Armor[] Armors { get; private set; } = Array.Empty<Armor>();

    public BattleMap BattleMap
    {
        get => _battleMap;
        private set
        {
            if (value == _battleMap) return;

            _battleMap = value;
            OnPropertyChanged();
        }
    }

    public GameState GameState
    {
        get => _gameState;
        private set
        {
            if (value == _gameState) return;
            _gameState = value;
            OnPropertyChanged();
        }
    }

    public IReadOnlyList<InventoryItem> Inventory
    {
        get
        {
            var items = new List<InventoryItem>();
            foreach (var item in _saveMap.Items)
            {
                if (item.Quantity == 127)
                {
                    items.Add(new InventoryItem(0, string.Empty));
                    continue;
                }

                var name = GetItemName(item);

                items.Add(new InventoryItem(item.Quantity, name));
            }

            return items;
        }
    }

    public IReadOnlyList<MateriaItem> Materia
    {
        get
        {
            var materias = new List<MateriaItem>();

            foreach (var materia in SaveMap.MateriaInventory.Select(materia => materia.Id))
            {
                if (materia == 255)
                {
                    continue;
                }
                var m = _materias[materia];
                materias.Add(new MateriaItem(materia, m.Name, m.MateriaType));
            }

            return materias;
        }
    }

    public SaveMap SaveMap
    {
        get => _saveMap;
        private set
        {
            if (value == _saveMap) return;

            _saveMap = value;
            OnPropertyChanged();
        }
    }

    public WindowColor WindowColor
    {
        get => _windowColor;
        private set
        {
            if(value == _windowColor) return;

            _windowColor = value;
            OnPropertyChanged();
        }
    }

    public bool IsBattle
    {
        get => _isBattle;
        private set
        {
            if (value == _isBattle) return;

            _isBattle = value;
            OnPropertyChanged();
        }
    }

    public Weapon[] Weapons { get; private set; } = Array.Empty<Weapon>();

    public void Init(Item[] items, Weapon[] weapons, Armor[] armors, Accessory[] accessories, Materia[] materias)
    {
        _items = items;
        Weapons = weapons;
        Armors = armors;
        Accessories = accessories;
        _materias = materias;
    }

    public void UpdateData(SaveMap saveMap, BattleMap battleMap, WindowColor windowColor, bool isBattle)
    {
        SaveMap = saveMap;
        BattleMap = battleMap;
        WindowColor = windowColor;
        IsBattle = isBattle;

        UpdateActiveData();
    }

    private void UpdateActiveData()
    {
        if (IsBattle)
        {
            UpdateActiveDataFromBattle();
        }
        else
        {
            UpdateActiveDataFromField();
        }
    }

    private void UpdateActiveDataFromField()
    {
        var party1 = CreateFieldCharacterObject(SaveMap.PartyMember1);
        var party2 = CreateFieldCharacterObject(SaveMap.PartyMember2);
        var party3 = CreateFieldCharacterObject(SaveMap.PartyMember3);

        ActiveData = new ActiveGameData(party1, party2, party3, IsBattle, WindowColor);
    }

    private void UpdateActiveDataFromBattle()
    {

        var party1 = CreateBattleCharacterObject(SaveMap.PartyMember1, BattleMap.Party1);
        var party2 = CreateBattleCharacterObject(SaveMap.PartyMember2, BattleMap.Party2);
        var party3 = CreateBattleCharacterObject(SaveMap.PartyMember3, BattleMap.Party3);


        ActiveData = new ActiveGameData(party1, party2, party3, IsBattle, WindowColor);
    }

    private Character CreateFieldCharacterObject(PartyMember member)
    {
        var record = GetCharacter(member);

        return new Character
        {
            Name = record.Name.Name,
            CurrentHP = record.CurrentHp,
            CurrentMP = record.CurrentMp,
            MaxHP = record.MaxHp,
            MaxMP = record.MaxMp,
            Level = record.Level,
            Weapon = Weapons[record.Weapon],
            Armor = Armors[record.Armor],
            Accessory = record.Accessory < 255 ? Accessories[record.Accessory] : null,
            Image = $"/images/character-{member.ToString().ToLower()}.png",
            Row = (record.Row & 0x1) == 0x1 ? "front" : "back"
        };
    }

    private Character CreateBattleCharacterObject(PartyMember member, BattleActor actor)
    {
        var record = GetCharacter(member);

        return new Character
        {
            Name = record.Name.Name,
            CurrentHP = (ushort)actor.CurrentHp,
            CurrentMP = actor.CurrentMp,
            MaxHP = (ushort)actor.MaxHp,
            MaxMP = actor.MaxMp,
            Level = actor.Level,
            Weapon = Weapons[record.Weapon],
            Armor = Armors[record.Armor],
            Accessory = record.Accessory < 255 ? Accessories[record.Accessory] : null,
            Image = $"/images/character-{member.ToString().ToLower()}.png",
            Row = actor.IsBackRow ? "back" : "front"
        };
    }

    private CharacterRecord GetCharacter(PartyMember member)
    {
        return member switch
        {
            PartyMember.Cloud => SaveMap.Cloud,
            PartyMember.Barret => SaveMap.Barret,
            PartyMember.Tifa => SaveMap.Tifa,
            PartyMember.Aeris => SaveMap.Aeris,
            PartyMember.RedXIII => SaveMap.RedXIII,
            PartyMember.Yuffie => SaveMap.Yuffie,
            PartyMember.CaitSith => SaveMap.CaitSith,
            PartyMember.Vincent => SaveMap.Vincent,
            PartyMember.Cid => SaveMap.Cid,
            PartyMember.YoungCloud => SaveMap.YoungCloud,
            PartyMember.Sephiroth => SaveMap.Sephiroth,
            _ => default
        };
    }

    public void UpdateGameState(GameState state)
    {
        GameState = state;
    }

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string GetItemName(ItemRecord item)
    {
        var name = item.ItemId switch
        {
            < 128 => _items[item.ItemId].Name,
            < 256 => Weapons[item.ItemId - 128].Name,
            < 288 => Armors[item.ItemId - 256].Name,
            < 320 => Accessories[item.ItemId - 288].Name,
            _ => "???"
        };
        return name;
    }
}