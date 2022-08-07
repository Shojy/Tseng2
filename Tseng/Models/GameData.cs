using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena.Items;
using Shojy.FF7.Elena.Materias;
using Shojy.FF7.Reno.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tseng.Models.Enums;

namespace Tseng.Models;

public class GameData : INotifyPropertyChanged
{
    private Accessory[] _accessories = Array.Empty<Accessory>();
    private Armor[] _armors = Array.Empty<Armor>();
    private BattleMap _battleMap;
    private GameState _gameState = GameState.Disconnected;
    private Item[] _items = Array.Empty<Item>();
    private Materia[] _materias = Array.Empty<Materia>();
    private SaveMap _saveMap;
    private Weapon[] _weapons = Array.Empty<Weapon>();

    public event PropertyChangedEventHandler? PropertyChanged;

    public Accessory[] Accessories => _accessories;
    public Armor[] Armors => _armors;

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

    public Weapon[] Weapons => _weapons;

    public void Init(Item[] items, Weapon[] weapons, Armor[] armors, Accessory[] accessories, Materia[] materias)
    {
        _items = items;
        _weapons = weapons;
        _armors = armors;
        _accessories = accessories;
        _materias = materias;
    }

    public void UpdateData(SaveMap saveMap, BattleMap battleMap)
    {
        SaveMap = saveMap;
        BattleMap = battleMap;
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
            < 256 => _weapons[item.ItemId - 128].Name,
            < 288 => _armors[item.ItemId - 256].Name,
            < 320 => _accessories[item.ItemId - 288].Name,
            _ => "???"
        };
        return name;
    }
}