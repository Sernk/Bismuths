using Bismuth.Content.Buffs;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Placeable;
using Bismuth.Content.Items.Tools;
using Bismuth.Content.Items.Weapons.Assassin;
using Bismuth.Content.Items.Weapons.Magical;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Content.Items.Weapons.Ranged;
using Bismuth.Content.Items.Weapons.Throwing;
using Bismuth.Content.NPCs;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth
{
    // if anybody will read this: take care of your psyche.
    // Big thanks to Rockos and his mod. Sources of it were very usefull.
    // Also thanks to Compozius and Zerokk. Their help in coding was essential.
    public class Quests : ModPlayer, ILocalizedModType
    {
        public string LocalizationCategory => "QuestsSystem";
        #region quest variables
        public int EquipmentQuest = 0;
        public int LuceatQuest = 0;
        public int BookOfSecretsQuest = 0;     
        public int ElessarQuest = 0;
        public int GlamdringQuest = 0;    
        public int MinotaurHornQuest = 0;     
        public int ArmorPlateQuest = 0;      
        public int TombstoneQuest = 0;     
        public int FoodQuest = 0;    
        public int SoulScytheQuest = 0;       
        public int PotionQuest = 0;     
        public int NewPriestQuest = 0;     
        public int PhilosopherStoneQuest = 0;   
        public int PhilosopherStoneCharging = 0;     
        public int SunriseQuest = 0;    
        public int ReportQuest = 0;

        #endregion
        // Номера квестов:
        // 1 - стартовое обмундирование
        // 2 - книга секретов
        // 3 - эллесар
        // 4 - луцеат
        // 5 - гламдринг
        // 6 - рог минотавра
        // 7 - броня гномов
        // 8 - могила
        // 9 - новый священник
        // 10 - зелья
        // 11 - филосовский камень
        // 12 - еда для бедняка 
        // 13 - картина    
        // 14 - важное донесение
        public IList<int> activequests = new List<int>();
        public IList<int> completedquests = new List<int>();
        public IList<string> descs = new List<string>();
        public IList<string> shorts = new List<string>();
        public IList<string> descscompl = new List<string>();
        public IList<string> shortscompl = new List<string>();
        public static Vector2 bookcoord = new Vector2(Main.screenWidth / 2 - 237, 200);       
        public Texture2D ActualPanel;
        int selectedquest = -1;
        int selectedquest2 = -1;
        string desc1 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest1Name");
        string desc2 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest2Name");
        string desc3 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest3Name");
        string desc4 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest4Name");
        string desc5 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest5Name");
        string desc6 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest6Name");
        string desc7 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest7Name");
        string desc8 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest8Name");
        string desc9 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest9Name");
        string desc10 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest10Name");
        string desc11 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest11Name");
        string desc12 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest12Name");
        string desc13 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest13Name");
        string desc14 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest14Name");
        string short1 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest1Short");
        string short2 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest2Short");
        string short3 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest3Short");
        string short4 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest4Short");
        string short5 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest5Short");
        string short6 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest6Short");
        string short7 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest7Short");
        string short8 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest8Short");
        string short9 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest9Short");
        string short10 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest10Short");
        string short11 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest11Short");
        string short12 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest12Short");
        string short13 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest13Short");
        string short14 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest14Short");
        public static Vector2 treecoord = new Vector2(bookcoord.X, bookcoord.Y);
        public override void Load()
        {
            _ = this.GetLocalization("Quests.Quest1Name").Value; // Ru: Начало приключения En: The beginning of an adventure 
            _ = this.GetLocalization("Quests.Quest2Name").Value; // Ru: В поисках секретов En: Searching the secrets
            _ = this.GetLocalization("Quests.Quest3Name").Value; // Ru: Тайна болота En: Mystery of swamp
            _ = this.GetLocalization("Quests.Quest4Name").Value; // Ru: Сокровище лабиринта En: Maze treasure
            _ = this.GetLocalization("Quests.Quest5Name").Value; // Ru: Убийца гоблинов En: Goblin slayers
            _ = this.GetLocalization("Quests.Quest6Name").Value; // Ru: По зову рога En: At the call of the horn
            _ = this.GetLocalization("Quests.Quest7Name").Value; // Ru: Броня нежити En: Undead's armor
            _ = this.GetLocalization("Quests.Quest8Name").Value; // Ru: Осквернитель могил En: Gravedigger
            _ = this.GetLocalization("Quests.Quest9Name").Value; // Ru: Новый священник En: New priest
            _ = this.GetLocalization("Quests.Quest10Name").Value; // Ru: Неуязвимость в бутылке En: Immortality in a bottles
            _ = this.GetLocalization("Quests.Quest11Name").Value; // Ru: Величайший алхимик En: The greatest alchemist
            _ = this.GetLocalization("Quests.Quest12Name").Value; // Ru: Накормить мир En: Feed the world
            _ = this.GetLocalization("Quests.Quest13Name").Value; // Ru: Ценитель искусства En: Art connoisseur
            _ = this.GetLocalization("Quests.Quest14Name").Value; // Ru: Важное донесение En: Important report

            _ = this.GetLocalization("Quests.Quest1Short").Value; // Ru: Получить стартовую экипировку En: Get start equipment
            _ = this.GetLocalization("Quests.Quest2Short").Value; // Ru: Помочь ведьме найти древний фолиатн En: Help witch get an ancient tome
            _ = this.GetLocalization("Quests.Quest3Short").Value; // Ru: Определить судьбу таинственного камня En: Determine the fate of mysterious stone
            _ = this.GetLocalization("Quests.Quest4Short").Value; // Ru: Помочь страннику вернуться домой En: Help wanderer to return home
            _ = this.GetLocalization("Quests.Quest5Short").Value; // Ru: Заполучить оружие против гоблинов En: Get powerful weapon against goblins
            _ = this.GetLocalization("Quests.Quest6Short").Value; // Ru: Помочь кузнецу изготовить боевой рог En: Help blacksmith to create battle horn
            _ = this.GetLocalization("Quests.Quest7Short").Value; // Ru: Принести кузнецу бронепластины En: Bring armor plates to blacksmiths
            _ = this.GetLocalization("Quests.Quest8Short").Value; // Ru: Выбрать, на чьей вы стороне En: Choose, which side you are on...
            _ = this.GetLocalization("Quests.Quest9Short").Value; // Ru: Убедить вождя принять нового священника En: Persuade leader to approve a new priest
            _ = this.GetLocalization("Quests.Quest10Short").Value; // Ru: Принести компоненты зелья алхимику En: Bring components for potion to alchemist
            _ = this.GetLocalization("Quests.Quest11Short").Value; // Ru: Заполучить мощнейший артефакт En: Get the most powerful artefact
            _ = this.GetLocalization("Quests.Quest12Short").Value; // Ru: Завоевать доверие бедняка En: Gain the trust of beggar
            _ = this.GetLocalization("Quests.Quest13Short").Value; // Ru: Сделать вождю подарок En: Make a present for leader
            _ = this.GetLocalization("Quests.Quest14Short").Value; // Ru: Доставить документы главнокомандующему En: Deliver documents to commander

            _ = this.GetLocalization("Quests.Oldman_2").Value; // Ru: Я отправился сюда из-за рассказов о несметных сокровищах, что скрывают эти руины, но лишь только я нашел их, как каменный завал оборвал мой путь наружу, к тому же я потерял волшебный камень где-то в лабиринте, без которого мне не вернуться домой. Найди его для меня, а остальную добычу можешь оставить себе. Я нашел этот ключ в завале, он может тебе пригодиться. Удачи! En: Unfortunately, when I came here searching for treasures I’ve heard of in the rumors, an avalanche cut off my path to the surface. I also lost a magical stone without which I can’t return home. It is somewhere in the labyrinth, find it for me, please, you can keep everything else. By the way, this key was lying among the rubble, take it, might come in handy. Good luck!
            _ = this.GetLocalization("Quests.Oldman_4").Value; // Ru: Не медли, моя жизнь зависит от тебя! En: Don’t take too long, my life is in your hands!
            _ = this.GetLocalization("Quests.Oldman_5").Value; // Ru: Не могу передать словами, как я благодарен тебе! Этот камень поможет мне вернуться домой. Навести меня в Имперском городе, как будет время. En: I can’t put into words how grateful I am! This stone will help me go home. Visit me in the city when you have a spare moment.
            _ = this.GetLocalization("Quests.Oldman_6").Value; // Ru: Рад, что у тебя нашлась минутка посетить город. Я прекрасно помню о том, что ты спас мою жизнь - возьми этот камень в качестве благодарности, с его помощью ты сможешь мнгновенно перемещаться в центр Имперского города. Не стоит благодарности - это меньшее, что я могу сделать для тебя. En: I’m glad you had a minute to talk. You saved my life, so take this stone as a sign of my appreciation, with its help you can instantly teleport to the city. Don’t thank me, this is the least I can do to repay you.
            _ = this.GetLocalization("Quests.Oldman_8").Value; // Ru: Я слышал, тебе удалось разоблачить некроманта, что своим присутствием отравлял наш оплот спокойствия. Я рад этому, однако в городе не осталось священника. В молодости я увлекался богословием, так что, наверное, мог бы стать новым представителем духовенства. Не мог бы ты поговорить с консулом об этом? Я был бы очень признателен. En: I heard you exposed a necromancer, who poisoned our peace with his presence. I’m glad, of course, but now the city has lost its only priest. In my younger years, I was quite into theology, so maybe I could become his replacement? Could you talk to the Consul about this, please? I’d appreciate that.

            _ = this.GetLocalization("Quests.SwampWitch_2").Value; // Ru: В глубине болота сокрыто древнее сокровище - камень, хранящий в себе мощь морского народа. Его охраняют чары, прерывающие жизненный путь тех безумцев, которые отважились попробовать заполучить камень, не подготовив свой разум. Великая Пустыня скрывает в себе старинный фолиант, что поможет нам добыть камень. Принеси мне книгу - и я поделюсь с тобой знанием. En: Somewhere within this swamp is an ancient treasure – a stone imbued with the might of the water folk. It is not easy to get to – the artifact is protected by a powerful curse, killing anyone unprepared for the adventure, but there might be a solution to that - bring me a tome from the city in the Great Desert, from what I’ve heard, the knowledge it holds could help.
            _ = this.GetLocalization("Quests.SwampWitch_4").Value; // Ru: Мне нужна книга, чтобы продолжить мои исследования. En: I need the book to continue my research.
            _ = this.GetLocalization("Quests.SwampWitch_5").Value; // Ru: Фолиант у тебя? Отлично… Хм, он написан на языке о котором даже я немногое знаю, очень интересно… Прости, но тебе придётся вернуться чуть позже - мне нужно время чтобы его расшифровать. En: Do you have the tome? Excellent… Huh, it seems to be written in a language even I know little of, very unusual… Sorry, but you’ll have to come back in a short while – I need some time to decypher it.
            _ = this.GetLocalization("Quests.SwampWitch_6").Value; // Ru: Мои исследования ещё не завершены - приходи позже. En: My research is not yet over – come back later.
            _ = this.GetLocalization("Quests.SwampWitch_8").Value; // Ru: Сундук с камнем находится в тайнике, где-то в подземельях болота. Добраться туда не сложно, но перед походом обязательно прочти книгу - это поможет тебе безопасно достать камень. Удачи! En: The chest with the stone is hidden somewhere underground. It shouldn’t be hard to get there, but you still need to read the tome to bypass whatever has killed all the adventurers before you. Good luck!
            _ = this.GetLocalization("Quests.SwampWitch_10").Value; // Ru: Принеси мне камень - и ты будешь вознагражден En: Bring me the stone – and you’ll be rewarded.
            _ = this.GetLocalization("Quests.SwampWitch_13").Value; // Ru: Что?! Похоже я в тебе ошиблась, негодяй! Никакой ты не герой, и я заставлю тебя заплатить! En: What?! It seems I was wrong about you, scoundrel! You’re no hero, and I’ll make sure you pay for this!

            _ = this.GetLocalization("Quests.Blacksmith_2").Value; // Ru: Я знал, что ты не из робкого десятка! Расклад такой. Когда-то давно я слышал о Гламдринге - мече эльфийской работы, что может с поразительной легкостью рубить и кромсать гоблинские черепушки. Мне известно, что у {0} есть чертеж этого меча. Хочешь насолить гоблинам? Принеси мне чертеж, и я изготовлю тебе этот клинок. En: I knew you weren’t some coward! This is the deal. Some time ago, I heard of Glamdring – a blade of elven craft, which slices those goblin skulls open with remarkable ease. I’m aware that {0} has a blueprint of this weapon. Want to screw them over? Bring it to me, and I’ll forge it for you
            _ = this.GetLocalization("Quests.Blacksmith_3").Value; // Ru: В окрестностях города чересчур много гоблинских морд, не отделенных пока от туловища, но это дело поправимое, если ты принесешь мне чертеж. En: There are far too many goblin snouts in the vicinity of this town, but that’s a solvable problem, if you bring me the blueprint, of course.
            _ = this.GetLocalization("Quests.Blacksmith_4").Value; // Ru: Отлично, теперь я могу изготовить клинок. Приходи через некоторое время En: Great, now I can forge the blade. Come back in a short while to pick it up.
            _ = this.GetLocalization("Quests.Blacksmith_5").Value; // Ru: Меч ещё не готов, приходи позже. En: The blade is not ready yet, come back later.
            _ = this.GetLocalization("Quests.Blacksmith_6").Value; // Ru: Да, я выковал его. Бери клинок и наваляй этим тварям от моего имени! En: Yes, I forged it! Take the blade and kick their asses in my name!
            _ = this.GetLocalization("Quests.Blacksmith_8").Value; // Ru: Где-то в подземельях прямо под нашим городом есть древний лабиринт, хранящий в себе уйму полезного, однако охраняется это добро минотавром. Из рога этой твари выйдет отличный музыкальный инструмент и ты сможешь его заполучить, если достанешь мне заготовку. En: Somewhere under our city lies an ancient labyrinth, holding a bunch of useful stuff, it is, however, protected by a minotaur. I could forge an excellent musical instrument for you if you get me a horn of that beast.
            _ = this.GetLocalization("Quests.Blacksmith_10").Value; // Ru: В таком случае не теряй времени, я буду ждать тебя. En: In that case don’t waste any more time, I’ll be waiting for you.
            _ = this.GetLocalization("Quests.Blacksmith_11").Value; // Ru: Итак, хранитель лабиринта повержен? Превосходно, дай мне пару минут...Готово! Прими этот боевой рог в качестве презента, он будет воодушевлять тебя на подвиги. En: So, the keeper of the labyrinth has been defeated? Excellent, give me a few minutes… Done! Take this battle horn as a present, it will inspire you to perform many heroic deeds, I’m sure!
            _ = this.GetLocalization("Quests.Blacksmith_13").Value; // Ru: Хорошо. Каждый гном снаряжался очень ценным нагрудником, изготавливающимся из редкого сплава. Я уверен, что доспехи ещё можно спасти. Если ты принесешь мне, скажем, пять бронепластин, я вознагражу тебя, а братья мои обретут наконец вечный покой. По рукам? En: Ok, ok. Every gnome was equipped with a precious breastplate, forged from a rare alloy. I’m sure, the armor can still be saved. If you bring me, say, 5 plates, I’ll reward you, and my brothers will finally find peace. Deal?
            _ = this.GetLocalization("Quests.Blacksmith_15").Value; // Ru: В таком случае не теряй времени даром, ты знаешь, что делать. En: In that case, don’t waste any more time – you know what to do.
            _ = this.GetLocalization("Quests.Blacksmith_16").Value; // Ru: Итак, они у тебя? Великолепная работа, {0}. Возможно тебе известно, что некоторые вещи в моем магазине я продаю за особую валюту. Думаю, ты заслужил получить по одной гномьей монете за каждый добытый нагрудник. Если у тебя впредь заваляются лишние доспехи - неси их мне, я оплачу твои старания. En: So, you have the stuff? Perfect job, {0}. You might know that some of the items in my shop are sold for a special kind of currency. I think you deserve a gnomish coin for each breastplate. If you have any spare in the future – bring them to me, and I’ll pay for your efforts.

            _ = this.GetLocalization("Quests.Priest_3").Value; // Ru: Недалеко от океана, в стороне джунглей, есть могила некогда великого война. Его останки нужны мне для проведения ритуала. Сможешь достать их, не побеспокоив дух усопшего - получишь награду. Эта лопата поможет тебе достать мощи, не повредив могильной плиты. И не смей никому говорить о нашей с тобой встрече, иначе, клянусь самой тьмой, ты пожалеешь. En: Not far away from the ocean, where the jungle lies, there is a grave of a once great warrior. I need his remains for a ritual. Get them without disturbing his spirit – and you’ll be rewarded. This shovel will help you recover what’s left without damaging the tombstone. And don’t you dare tell anyone about this meeting - I swear upon the dark itself, you’ll regret it.
            _ = this.GetLocalization("Quests.Priest_5").Value; // Ru: Мне нужны останки для проведения ритуала. Приходи, когда добудешь их. En: I need the remains for a ritual. Come back once you have them.
            _ = this.GetLocalization("Quests.Priest_6").Value; // Ru: Прекрасно, брат мой! Знай же, что {0} не бросает слов на ветер. Когда-то давно сама Смерть даровала мне эту косу - теперь же я охотно делюсь её с тобой. Она поможет тебе отделять души павших врагов от тела и использовать их в своих целях. Но коса со временем истощается, так что если тебе понадобиться зарядить её - приходи ко мне. En: Marvelous, my brother! Know that I, {0}, am a man of my word. Once upon a time Death itself granted me this scythe – now I eagerly share it with you. It’ll help you separate the souls of fallen enemies from their bodies and use them to your ends. However, the scythe loses its power over time, so if you need it charged – come to me.
            _ = this.GetLocalization("Quests.Priest_7").Value; // Ru: Воистину нет предела человеческой глупости! Ты сорвал все мои планы! Убирайся прочь с моих глаз и думать забудь о награде! En: Truly, there is no end to human foolishness! You messed up every one of my plans! Begone, and forget about the reward!

            _ = this.GetLocalization("Quests.Consul_2").Value; // Ru: О, я рад, что наконец нашелся желающий. Да, думаю, {0} может приступить к этой должности сегодня же. En: Oh, I’m glad we finally have a volunteer. Yes, {0} can take on the job today onwards.
            _ = this.GetLocalization("Quests.Consul_3").Value; // Ru: Ты говоришь, что священник дал тебе задание осквернить могилу? Не могу в это поверить! Однако все предоставленные тобой доказательства бессомненны. Постарайся арестовать некроманта, пока он не сбежал. И да - вот награда за твою честность. En: You're telling me that the priest tasked you with desecrating a grave? This is simply unbelievable! But… All of the evidence you've presented seems viable. Try to arrest him while he still hasn’t gotten away. And yes – here is the reward for your honesty.
            _ = this.GetLocalization("Quests.Consul_4").Value; // Ru: Это крайне серьезное обвинение, есть ли у тебя доказательства? Я не готов верить твоим словам без подтверждения, особенно если учесть, что у {0} безупречная репутация, а ты в наших краях появился недавно. En: That is a very serious accusation, do you have proof of his guilt? I am not ready prosecute the priest based on just the words of some newcomer, especially taking into account {0}'s flawless reputation over the years.

            _ = this.GetLocalization("Quests.Commander_1").Value; // Ru: Ты тот самый рекрут, что прибыл сюда недавно? Отлично, у меня есть экипировка, которая поможет тебе оставаться в живых чуть дольше. И нет - это не лагерь Наварро, так что тебе не придется работать до 510 лет, чтобы оплатить её. En: You’re that recruit who arrived recently? Good, I have some equipment to keep you alive for a little longer. And no – this is not camp Navarro, so you don't have to work yourself to the bone to repay this.
            _ = this.GetLocalization("Quests.Commander_3").Value; // Ru: Один из наших разведчиков был отправлен проверять обстановку в окрестностях заброшенного замка - древнего здания, следа ушедшей в небытие цивилизации. Прошло уже два дня, а он так и не вернулся с отчетом. Проверь, что произошло и доложи мне. En: One of our scouts has been sent to check the situation in the area of a deserted castle – an ancient relic of a lost civilization. It’s been two days already, and he hasn’t come back yet. Check it out and report to me when you’re done.
            _ = this.GetLocalization("Quests.Commander_5").Value; // Ru: Возвращайтесь, как только добудете информацию En: Come back once you have the information.
            _ = this.GetLocalization("Quests.Commander_6").Value; // Ru: Разведчик погиб, но вам удалось достать его отчет? Дайте его сюда, в нем может содержаться необходимая Империи информация...Ага...Вот оно как...В этом отчете описываются наблюдения лазутчика за замком. Тут сказано, что по ночам сундук внутри замка словно трясется. Дальше запись обрывается... En: So the scout is dead, but you’ve recovered his report? Give it here, it could hold information crucial to the Empire… Okay… So that’s how it is, huh… This report contains his observations of the castle. It says here that during nighttime the chest in there is seems to be shaking, then the writing ends…
            _ = this.GetLocalization("Quests.Commander_6_2").Value; // Ru: Понятия не имею, с чем это может быть связано, однако разведчик отдал свою жизнь за эти наблюдения, так что вам лучше быть осторожнее в окрестностях этого замка. И да, у меня есть кое-что для вас. Возьмите эту книгу, она содержит знания, которые могут помочь вам в дальнейших странствиях. En: I don’t have a slightest clue what this could mean, however, the scout gave his life for these notes, so you better be careful around that castle. Also, I have something for you. Take this book, it holds knowledge that could help you in your travels.
            _ = this.GetLocalization("Quests.Commander_6_3").Value; // Ru: Понятия не имею, с чем это может быть связано, однако разведчик отдал свою жизнь за эти наблюдения, так что вам лучше быть осторожнее в окрестностях этого замка. И да, у меня есть кое-что для вас. Возьмите немного золота. Оно поможет вам в дальнейших странствиях. En: I don’t have a slightest clue what this could mean, however, the scout gave his life for these notes, so you better be careful around that castle. Also, I have something for you. Take some gold, it could help you in your travels.

            _ = this.GetLocalization("Quests.Alchemist_2").Value; // Ru: У нашего консула скоро юбилей и мы хотим от лица благодарных жителей города преподнести ему подарок в виде древнего произведения искусства. Я слышал о картине, которая хранится в святилище бога солнца Гелиоса. Если ты сможешь принести мне её, то я щедро награжу тебя En: Our Consul is having an anniversary soon and we, the grateful citizens, want to show him our appreciation with a present – an ancient piece of art. I’ll cut to the chase – we are interested in a certain picture stored in the shrine of the Sun God Helios. Bring it to me, and you’ll be rewarded.
            _ = this.GetLocalization("Quests.Alchemist_4").Value; // Ru: В таком случае я буду ждать. Это святилище находится где-то в небесах. En: In that case, I’ll wait. The shrine is somewhere up in the sky, by the way.
            _ = this.GetLocalization("Quests.Alchemist_5").Value; // Ru: Прекрасно, консул будет доволен. Тебя я тоже не оставлю обделенным - это зелье поможет тебе сбросить свою расу и вернуть человеческий облик En: Just what we needed, the consul will love this. You will not leave emptyhanded too – this potion will help you to reset your race and return to human form
            _ = this.GetLocalization("Quests.Alchemist_7").Value; // Ru: Сейчас я изготавливаю зелье, которое делает выпившего бессмертным на некоторое время. У него крайне сложный состав, в который входят цветы папоротника. Если ты сможешь достать для меня 5 таких цветков, то я поделюсь с тобой готовым зельем. Ты в деле? En: Right now, I’m making a potion to make the consumer immortal for a short period of time. It has a highly complex composition, which includes fern leaves. You get me 5 of those, and I’ll share some of the stuff with you. Are you in?
            _ = this.GetLocalization("Quests.Alchemist_9").Value; // Ru: Продолжай поиски, мне нужно ровно 5 штук. En: Keep up the search, I need just 5 of them.
            _ = this.GetLocalization("Quests.Alchemist_10").Value; // Ru: Великолепно, друг мой. Осталась последняя стадия - нужно добавить днецветов. К сожалению, мой запас этих растений иссяк, но я слышал, что их можно заменить смерть-травой. Доверюсь твоему чутью. Что ты выбираешь? En: Perfect, my friend. The final thing left is some dayblooms. Sadly, my stock of those is empty, but I heard they could be replaced with deathweed. I’ll trust you to make that decision. What do you think?
            _ = this.GetLocalization("Quests.Alchemist_14").Value; // Ru: Стало быть, ты знаешь, чем заняться в свободное время. Жду тебя с цветками. En: You sure know what to do in your free time, huh. I’m waiting for the flowers.
            _ = this.GetLocalization("Quests.Alchemist_15").Value; // Ru: Итак, последний ингредиент добавлен! Спасибо большое за твою помощь - прими же эти зелья в качестве благодарности. Я уверен, они сильно помогут тебе в заварушке! En: And so, the last ingredient is here! Thanks for your help – take these potions as a sign of my appreciation. I’m confident they’ll help you in a time of need!
            _ = this.GetLocalization("Quests.Alchemist_17").Value; // Ru: Для его зарядки мне нужна очень редкая субстанция - эфир, её рецепт хранится в изумрудной скрижали - старинном алхимическом трактате. Если ты принесешь мне скрижаль, я смогу зарядить камень для тебя. По рукам? En: To charge it I need an extremely exotic substance – aether. It’s recipe is kept on a certain emerald tablet – an ancient repository of wisdom. If you bring it to me, I might be able to charge the stone. Deal?
            _ = this.GetLocalization("Quests.Alchemist_19").Value; // Ru: О Боги, да, это она! У тебя получилось! В этом трактате изложен рецепт эфира. Мне понадобится некоторое время на расшифровку этих символов. Посети меня через некоторое время, я постараюсь что-нибудь придумать. En: Oh Gods, yes, this is it! You've done it! This tablet describes the method of creating aether. I'll need some time to decypher the symbols, visit me in a short while, I'll try to think something up.
            _ = this.GetLocalization("Quests.Alchemist_20").Value; // Ru: Нет, к сожалению, мне пока не удалось раскрыть тайну эфира. Приходи позже. En: No, sadly, I'm not done solving the mystery of aether yet. Come back later.
            _ = this.GetLocalization("Quests.Alchemist_21").Value; // Ru: Да, мой друг, мне удалось перевести скрижаль. Для создания эфира нам потребуются эссенции четырех стихий: огня, земли, воды и воздуха. Из них ты и сам сможешь изготовить субстанцию, но сперва прочти перевод скрижали, дабы не ошибиться в приготовлении. Помимо этого мне понадобятся все семь небесных металлов. Приходи, когда добудешь всё это. En: Yes, my friend, I've succeed in decyphering the tablet. To create aether we'll need the essences of four elements: fire, earth, water and wind. Using those it’s possible to create the substance, but first, read the translation of this tablet to avoid making a mistake in manufacturing. Aside from this, I'll need all seven celestial metals. Come back once you've obtained every ingredient.
            _ = this.GetLocalization("Quests.Alchemist_22").Value; // Ru: К сожалению, тебе не хватает материалов. Для зарядки камня необходимо:\n30[i:{ItemID.CopperOre}], 30[i:{ItemID.TinOre}], 30[i:{ItemID.IronOre}], 30[i:{ItemID.LeadOre}], 30[i:{ItemID.SilverOre}], 30[i:{ItemID.GoldOre}], 30[i:{ModContent.ItemType<Items.Materials.Quicksilver>()}]\n10[i:{ModContent.ItemType<Items.Materials.Aether>()}]\n[i:{ModContent.ItemType<Items.Other.UnchargedTruePhilosopherStone>()}] En: Unfortunately, you do not have enough materials. To charge the stone you’ll need:\n30[i:{ItemID.CopperOre}], 30[i:{ItemID.TinOre}], 30[i:{ItemID.IronOre}], 30[i:{ItemID.LeadOre}], 30[i:{ItemID.SilverOre}], 30[i:{ItemID.GoldOre}], 30[i:{ModContent.ItemType<Items.Materials.Quicksilver>()}]\n10[i:{ModContent.ItemType<Items.Materials.Aether>()}]\n[i:{ModContent.ItemType<Items.Other.UnchargedTruePhilosopherStone>()}]
            _ = this.GetLocalization("Quests.Alchemist_23").Value; // Ru: Отлично, я сейчас же начну заряжать камень. Приходи позже. En: Cool, I’ll start charging the stone right now. Come back later.
            _ = this.GetLocalization("Quests.Alchemist_24").Value; // Ru: Да, камень готов. Бери его и пусть он хранит тебя! En: Yeah, the stone is ready. Take it and may it protect you!

            _ = this.GetLocalization("Quests.Beggar_2").Value; // Ru: Я знаю, что такой смелый и отважный воин, как ты, не откажет в помощи старому больному человеку. Принеси мне чего-нибудь пожевать, и тогда, возможно, я награжу тебя... Шучу, конечно En: I know a valiant warrior such as yourself wouldn’t refuse to aid a helpless old man. Bring me a snack, and then, perhaps I’ll reward you… A joke, obviously.
            _ = this.GetLocalization("Quests.Beggar_4").Value; // Ru: Возвращайся, как только достанешь чего-нибудь вкусненького! En: Come back once you have something nice and tasty!
            _ = this.GetLocalization("Quests.Beggar_5").Value; // Ru: Отлично, друг мой, ты оказал мне неоценимую услугу! Знаешь, вообще в нашем городе запрещены азартные игры, но для тебя я сделаю исключение. Приходи в любое время, если захочешь посостязаться со мной в игре в кости, а также расстаться с содержимым своего кошелька! En: Thanks friend, you did me a big favor! You know, gambling is forbidden in this city, but I’ll make an exception just for you. Come here anytime you want to try your luck at game of dice with me, as well as lighten that wallet of yours!

            _ = this.GetLocalization("Quests.Blacksmith_17").Value; // Ru: Отлично сработано, вот твоя награда. En: Excellent work, here is your reward.

            _ = this.GetLocalization("Quests.Priest_8").Value; // Ru: Да, брат мой, я смогу зарядить косу. Навести меня через некоторое время. En: Yes, my brother, I will charge the scythe. Come back later.
            _ = this.GetLocalization("Quests.Priest_9").Value; // Ru: Вижу, ты пришел за косой? Хорошо, я как раз закончил. Пусть она послужит тебе во многих темных деяниях. En: I see you came to take the scythe? Well, I’ve just finished. It should help you in many dark affaires.

            _ = this.GetLocalization("Quests.BackToTitle").Value; // Ru: Назад на главную страницу En: Back to title page
            _ = this.GetLocalization("Quests.TitleText").Value; // Ru: Добро пожаловать в Bismuth Mod - модификацию для террарии, которая добавляет большое количество новых игровых механик. В книге приключенца содержится вся полезная информация, которая может пригодиться игроку. Вкладки книги помогут вам получить информацию об активных и выполненных заданиях, о характеристиках персонажа, а также доступ к древу умений - если вы воспользовались гравировкой класса.\nТакже проверьте разделы Mod Controls и Mod Config, и настройте их по своему вкусу! En: Welcome to the Bismuth Mod - a modification for Terraria, adding a large amount of new game mechanics. All of the information the player might need to learn the ropes can be found in the Adventurer's Book. Its pages contain: a list of active/completed quests, the stats of your character, as well as the skill tree (unlocked once you choose your class).\nAlso check Mod Controls and Mod Config options and configure it as you like!
            _ = this.GetLocalization("Quests.LinksText").Value; // Ru: Полезные Ссылки: En: Useful Links

            _ = this.GetLocalization("Quests.ActiveQuests").Value; // Ru: Активные задания: En: Active Quests: 
            _ = this.GetLocalization("Quests.CompletedQuests").Value; // Ru: Выполненные задания: En: Completed Quests:
            _ = this.GetLocalization("Quests.Stages").Value; // Ru: Этапы: En: Stages:
            _ = this.GetLocalization("Quests.Quest1Stage1").Value; // Ru: Выберите свой класс En: Choose your class
            _ = this.GetLocalization("Quests.Quest1Stage2").Value; // Ru: Получите экипировку в казарме En: Take start equipment from commander
            _ = this.GetLocalization("Quests.Quest2Stage1").Value; // Ru: Найдите фолиант в пустынном городе En: Find the book in the desert town
            _ = this.GetLocalization("Quests.Quest3Stage1_1").Value; // Ru: Принесите Гаэрмир ведьме En: Bring Gaermire to witch
            _ = this.GetLocalization("Quests.Quest3Stage1_2").Value; // Ru: Оставьте его у себя En: Keep it
            _ = this.GetLocalization("Quests.Quest4Stage1").Value; // Ru: Принесите старику волшебный камень En: Bring magic stone to oldman
            _ = this.GetLocalization("Quests.Quest4Stage2").Value; // Ru: Получите награду En: Get reward
            _ = this.GetLocalization("Quests.Quest5Stage1").Value; // Ru: Купите у гоблина-инженера чертеж меча En: Buy sword blueprint from goblin tinkerer
            _ = this.GetLocalization("Quests.Quest5Stage2").Value; // Ru: Подождите, пока меч не будет готов En: Wait for new sword
            _ = this.GetLocalization("Quests.Quest6Stage1").Value; // Ru: Принесите рог минотавра кузнецу En: Bring minotaur horn to blacksmith
            _ = this.GetLocalization("Quests.Quest7Stage1").Value; // Ru: Принесите сломанные гномьи нагрудники En: Bring remains of dwarven armor
            _ = this.GetLocalization("Quests.Quest8Stage1_1").Value; // Ru: Раскопайте могилу En: Dig tombstone
            _ = this.GetLocalization("Quests.Quest8Stage1_2").Value; // Ru: Доложите консулу En: Report to leader
            _ = this.GetLocalization("Quests.Quest9Stage1").Value; // Ru: Поговорите с консулом о новом священнике En: Talk to leader about priest job
            _ = this.GetLocalization("Quests.Quest10Stage1").Value; // Ru: Принесите цветки папоротника алхимику En: Bring fern flowers to alchemist
            _ = this.GetLocalization("Quests.Quest10Stage2_1").Value; // Ru: Выберите днецветы En: Choose dayblooms
            _ = this.GetLocalization("Quests.Quest10Stage3").Value; // Ru: Принесите алхимику днецветы En: Bring dayblooms to alchemist
            _ = this.GetLocalization("Quests.Quest11Stage1").Value; // Ru: Восстановите изумрудную скрижаль En: Make Tabula from parts
            _ = this.GetLocalization("Quests.Quest11Stage2").Value; // Ru: Дождитесь перевода трактата En: Wait for translation
            _ = this.GetLocalization("Quests.Quest12Stage1").Value; // Ru: Принесите бедняку еды En: Bring food to beggar
            _ = this.GetLocalization("Quests.Quest13Stage1").Value; // Ru: Принесите алхимику картину En: Bring picture to alchemist
            _ = this.GetLocalization("Quests.Quest14Stage1").Value; // Ru: Найдите разведчика En: Find scout
            _ = this.GetLocalization("Quests.Quest14Stage2").Value; // Ru: Принесите отчет главнокомандующему En: Bring report to commander

            _ = this.GetLocalization("Quests.QuestOr").Value; // Ru: Или En: Or

            _ = this.GetLocalization("Quests.QuestDiary1").Value; // Ru: Забавно, но первое, что я помню – это разговор с человеком в белой робе, словно до этого момента меня не существовало. Если мне не изменяет память, то его зовут {0}, а место, в котором я оказался – Имперский город. Тут неплохо, особенно если учесть, что это единственное безопасное место в округе. {0} , похоже, здесь главный. Он дал мне указание встретиться с местным главнокомандующим и получить от него экипировку. Стоит последовать его совету, однако сначала нужно решить – какой стиль боя мне ближе, а после воспользоваться гравировкой класса. En: Curiously, the last thing I remember - me talking to a guy in a white robe, almost as if I hadn’t existed before then. If I remember correctly, his name is {0}, and the place I found myself in – Imperial city. It’s pretty good here, moslty due to it’s the safest place in these lands. Looks like {0} is the leader. He told me to meet the commander and pick up my equipment. I should follow his advice, however, first I must decide which fighting style suits me the most and use class engraving.
            _ = this.GetLocalization("Quests.QuestDiary1_2").Value; // Ru: Забавно, но первое, что я помню - это разговор с человеком в белой робе, словно до этого момента меня не существовало. Если мне не изменяет память, то его зовут {0}, а место, в котором я оказался - Имперский город. Этот парень с самого начала ждёт, что я стану ходить по струнке и выполнять все его приказы - как бы не так! Я отказался от предложенной экипировки - пусть ищет кого-нибудь поглупее. En: Curiously, the last thing I remember - me talking to a guy in a white robe, almost as if I hadn’t existed before then. If I remember correctly, his name is {0}, and the place I found myself in - Imperial city. Right from the start, this guy expects me to follow his orders, I don’t think so! I refused his offer of equipment - he should find someone else to toy with!
            _ = this.GetLocalization("Quests.QuestDiary2").Value; // Ru: Эти болота – гиблое место. Ядовитые топи и местные обитатели – не лучшее, что со мной случалось. Странно, но даже в таких заброшенных окраинах не угас очаг цивилизации. В центре болота я нашел избу, в которой живет старая ведьма. Она рассказала мне историю о сокровище, спрятанном где-то в недрах болота, и попросила принести ей фолиант, который поможет достать его. Эта старуха выглядит подозрительно, однако рискнуть стоит. Эта книга хранится где-то в заброшенном пустынном городе – стоит начать поиски там. En: These swamps are a rotten place. Poisonous marshes and their residents are not the best that’s happened to me. Oddly enough, even in godforsaken outskirts like these there still are some signs of civilisation. In the middle of the swamp I found a guy housing a witch. She told me a tale of a treasure, hidden somewhere deep inside the moor, and told me to bring her a time, that could help recover it. Not going to lie, she looks suspicious but I think it’s worth the risk. The time is stored somewhere in the desert city – I should begin my search there.
            _ = this.GetLocalization("Quests.QuestDiary2_2").Value; // Ru: Мне удалось добыть книгу, которую просила старуха. Теперь нужно ждать, пока она не переведёт фолиант. En: I succeeded in recovering the tome the swamp hag asked of me. Now, I must wait while she’s busy deciphering it.
            _ = this.GetLocalization("Quests.QuestDiary3").Value; // Ru: Итак, этой ведьме удалось перевести книгу. Мне стоит прочесть перевод, прежде чем я отправлюсь за камнем, иначе древнее проклятие убьет меня. Старуха явно скрывает истинную силу артефакта – одна из страниц книги указывает на то, что с помощью этого камня можно заполучить силы древнего морского народа – для этого нужно зарядить его на алтаре в заброшенном храме где-то на дне океана. Теперь мне стоит решить, как я поступлю – оставлю сокровище себе или сдержу обещание. En: At last, the witch is done deciphering the tome. I should read the result, before setting of to get the artifact, lest the ancient curse kill me. The hag's obviously hiding the true power of this relic – one of the pages states that with it, I could attain the powers of the water folk – for that, I should charge the stone at an altar in a temple somewhere on the  seabed. Now I must decide how to act – take it for myself or keep my promise.
            _ = this.GetLocalization("Quests.QuestDiary4").Value; // Ru: Я думал, что нет ничего хуже, чем потерять память и очнуться в незнакомом городе – но сегодняшняя встреча показала мне, что я ошибался. Ища руду для новой экипировки в подземелье, я услышал мольбу о помощи. Разобрав завал, я встретил старика, который, похоже, жил тут не первый день. Он сказал, что дверь дальше по коридору – вход в лабиринт, а где-то внутри катакомб лежит магический камень, который поможет ему вернуться домой. Я получил от старика ключ от двери. Сейчас, похоже, самое время вызволить его, а заодно и посмотреть, какие богатства сокрыты в этом лабиринте. En: And here I thought nothing could be worse than losing your memories only to find yourself in a foreign city, today’s meeting showed me otherwise. Searching for ore underground, I heard a plea for help. Behind the rubble, I found an old man, who, by the looks of it, had been living here for a while. He told me that the door further down the corridor is an entrance to a labyrinth. Somewhere inside is a magic stone that could help him return home. He gave me a key to said door. Now it’s time to free him, as well as check out the goods kept inside.
            _ = this.GetLocalization("Quests.QuestDiary4_2").Value; // Ru: Я смог достать камень, о котором меня просил старик. Оказалось, что это телепортатор, мгновенно перемещающий владельца в Имперский город. Старик сказал, что мне стоит навестить его там, если я хочу получить награду за старания. En: I succeeded in recovering the man's stone. Turned out, it was a teleporting device, immediately bringing the owner to the Imperial city. The old man told me to come by, in case I want a reward for my efforts.
            _ = this.GetLocalization("Quests.QuestDiary5").Value; // Ru: Гоблины оказались весьма крепкими ребятами, мне точно нужно что-то более эффективное против этих тварей. {0} сказал мне, что готов выковать для меня меч специально против них, если я добуду чертеж. По его словам, этот свиток есть у {1} – нашего гоблина-инженера. Иронично. En: The goblins turned out to be a tough bunch, it’s clear I need something more effective against these beasts. {0} told me that with the right blueprint, I could forge a weapon specifically for that purpose. From his words, the scroll is in {1}'s – our goblin tinkerer's possession. Ironic.
            _ = this.GetLocalization("Quests.QuestDiary6").Value; // Ru: Сегодня снова беседовал с {0} – он сказал мне, что где-то под имперским городом находится лабиринт, в недрах которого обитает минотавр. Кузнецу интересен лишь рог этого чудища, из которого он хочет сделать музыкальный инструмент, так что остальную добычу я могу оставить себе. Стоит заняться подготовкой к битве с минотавром. En: Today I again spoke to {0} – he told me of a labyrinth somewhere beneath the city, deep inside of which is a Minotaur. The blacksmith is interested only in its horn, out of which he could make a musical instrument, therefore, the rest of the treasure is mine. I should take some time to prepare before battling the beast.
            _ = this.GetLocalization("Quests.QuestDiary7").Value; // Ru: А ведь действительно, я до сих пор не встречал ни одного гнома, кроме {0}. Его история о некогда великой цивилизации дварфов всё объясняет. Может кузнец и испытывает жалость по отношению ко своим павшим братьям, но лично мне не очень интересна их судьба. С другой стороны, {0} заплатит за их бронепластины, так что теперь мне придется переквалифицироваться в охотника на нежить, если хочу получить немного гномьих монет. En: Now that I actually think about it, I've never met a gnome besides {0}. His tale of a once great dwarf civilisation explains everything. Perhaps he pities his fallen comrades, but their fate is not of much importance to me. On the other hand, {0} is willing to pay for their breastplates, so I must now assume the role of an undead Hunter, if I want some of those dwarven coins.
            _ = this.GetLocalization("Quests.QuestDiary8").Value; // Ru: Ночью разговаривал с {0} – местным священником. Он явно не так прост, как кажется. Попросил меня найти могилу воина, которая должна быть где-то возле океана в стороне джунглей, и принести ему останки для проведения ритуала. В Имперском городе некромантия запрещена под страхом смерти, однако {0} пообещал мне некое «оружие невиданной силы» и пригрозил отомстить, если я расскажу кому-то о нашем разговоре. Теперь стоит решить, рассказать ли консулу о замыслах священника, или нарушить закон ради этого оружия. En: Last night I spoke to {0} – this place's priest. He is obviously more than he lets on. I was told to recover remains from a warrior’s grave somewhere beside the ocean on the side of the jungle, and bring them to him for a ritual. Necromancy is forbidden here on pain of death, however, {0} promised me a “weapon of unseen power” and promised a bitter end should I betray him. Now I must decide, do I reveal his schemes to the consul or break the law to get that weapon?
            _ = this.GetLocalization("Quests.Quest8Stage1_3").Value; // Ru: Уничтожьте могилу En: Destroy the tombstone
            _ = this.GetLocalization("Quests.QuestDiary9").Value; // Ru: Старик, которого я вызволил из лабиринта, сказал мне, что некогда увлекался богословием и знает, что {0}, уличенный в некромантии, сбежал. Он хочет стать новым священником и попросил меня замолвить за него словечко перед {1}. Не вижу причин, из-за которых мне следует ему отказать в этой услуге. En: The old man I freed from the labyrinth told md, that he once dabbled in theology and knows that {0} – the necromancer, escaped. He wants to take his place and asked me to speak to {1} on the matter. I don’t see a reason to refuse him.
            _ = this.GetLocalization("Quests.QuestDiary10").Value; // Ru: "Наконец-то просьба {0} представляет из себя что-то более существенное. Алхимик рассказал мне, что работает над созданием зелья, которое делает выпившего неуязвимым на короткий промежуток времени. Для создания ему нужны цветки папоротника, споры которого я могу достать на болоте из зарослей этого растения. После стоит посадить споры в горшок и дождаться цветения. En: Finally, {0} asked me for something interesting. He told me of work-in-progress potion, that should make the user invincible for a short period of time. To create it he needs fern flowers, the spores of which I can find in the swamp. I should plant those spores in a pot and wait for them to bloom.
            _ = this.GetLocalization("Quests.Quest10Stage2_2").Value; // Ru: Выберите смерть-траву En: Choose deathweed
            _ = this.GetLocalization("Quests.QuestDiary11").Value; // Ru: {0} доволен моей помощью, вероятно поэтому он рассказал мне об истинном философском камне – артефакте, который позволяет владельцу избежать смерти. Этот камень – реликвия семьи {0}, однако проблема заключается в том, что для работы он должен быть заряжен. Сделать это можно лишь при помощи эфира – вещества, рецепт которого описан в изумрудной скрижали – древнем алхимическом трактате.  Осколки скрижали хранятся в шкатулках, разбросанных по всему миру, а найти их я могу с помощью ртутных зеркал. После того, как я соберу скрижаль, мне нужно принести её алхимику. En: Looks like {0} is satisfied with my help, and that’s why he told me of the true philosopher's stone – an artefact that helps the used escape death's grasp. It's a family relic of {0}'s, the issue is it has to be charged to work. And the only way to do that is to use aether – a substance, the recipe of which is described in Tabula Smaragdina – an ancient alchemical tract. The shards of said tract are kept in caskets scattered all over the world, the only way to find those is to use Quicksilver mirrors. I should bring the Tabula to {0} once it’s assembled.
            _ = this.GetLocalization("Quests.QuestDiary12").Value; // Ru: Кого только не встретишь в этом городе! Рядом с кузницей постоянно ошивается {0} – местный сумасшедший любитель азартных игр, живущий в палатке. Он попросил меня принести ему еды. Дело нехитрое, к тому же он может владеть полезной информацией, так что выполнить его просьбу определенно стоит. En: There’s a wide assortment of people in here. Take {0}, the local crazy gambler living in a tent near the smithy. He asked me to bring me some food. The task's not rocket science, and he has some useful info to boot, so I probably should fulfill his request.
            _ = this.GetLocalization("Quests.QuestDiary13").Value; // Ru: {0} – местный алхимик. Этот человек – большой энтузиаст, причем не только в областях, касающихся создания зелий, поэтому я не был удивлен, когда он попросил меня помочь ему сделать подарок консулу на его юбилей. {0} хочет подарить ему редкую картину, достать которую можно в святилище бога солнца Гелиоса. Оно должно находиться где-то в небе над Имперским городом. En: {0} – is this place’s alchemist. The man is a big enthusiast, and not only in the field of potion-making, so I was not surprised, when he asked me to help him make a gift for the consul's anniversary. {0} wants to present him with a rare picture, found in the shrine of the Sun God Helios. It should be somewhere in the skies above the city.
            _ = this.GetLocalization("Quests.QuestDiary14").Value; // Ru: Главнокомандующий дал мне важное поручение – проверить обстановку рядом с заброшенным замком древней цивилизации. По его сведениям, разведчик, отправленный в те места, пропал без вести, а полководцу очень важен отчёт, который был у скаута. Мне необходимо обнаружить этот замок и добыть документы. En: The commander tasked me with an important mission – check the situation in the vicinity of a forsaken fort. His Intel tells that the scout previously sent to those lands disappeared without a trace, and his report is of utmost importance to the city. I must find the castle and recover the document.

            _ = this.GetLocalization("Player.PlayerStat").Value; // Ru: Характеристики игрока: En: Player Stats:
            _ = this.GetLocalization("Player.HPStat").Value; // Ru: Максимальное здоровье: {0} En: Max health: {0}
            _ = this.GetLocalization("Player.RegenStat").Value; // Ru: Регенерация здоровья: {0}{1} хп/сек En: Life regeneration: {0}{1} hp
            _ = this.GetLocalization("Player.MPStat").Value; // Ru: Макс. маны: {0} En: Max mana: {0}
            _ = this.GetLocalization("Player.ManaCostStat").Value; // Ru: Стоимость заклинаний: {0}% En: Spells cost: {0}%
            _ = this.GetLocalization("Player.DefenceStat").Value; // Ru: Защита: {0} En: Defence: {0}
            _ = this.GetLocalization("Player.EnduranceStat").Value; // Ru: Поглощение урона: {0}% En: Damage resistance: {0}%
            _ = this.GetLocalization("Player.BlockStat").Value; // Ru: Шанс блокирования: {0}% En: Block chance: {0}%
            _ = this.GetLocalization("Player.DodgeStat").Value; // Ru: Шанс уворота: {0}% En: Dodge chance: {0}%
            _ = this.GetLocalization("Player.ParryStat").Value; // Ru: Parry chance: {0}% En: Шанс парирования: {0}%
            _ = this.GetLocalization("Player.MSStat").Value; // Ru: Movement speed: {0}% En: Скорость передвижения: {0}%
            _ = this.GetLocalization("Player.MeleeDmgStat").Value; // Ru: Урон в ближнем бою: {0}% En: Melee damage: {0}%
            _ = this.GetLocalization("Player.MeleeCritStat").Value; // Ru: Melee critical strike chance: {0}% En: Шанс крита в ближнем бою: {0}%
            _ = this.GetLocalization("Player.MeleeSpeedStat").Value; // Ru: Скорость ближнего боя: {0}% En: Melee speed: {0}%
            _ = this.GetLocalization("Player.MagicDmgStat").Value; // Ru: Магический урон: {0}% En: Magical damage: {0}%
            _ = this.GetLocalization("Player.MagicCritStat").Value; // Ru: Шанс крита магией: {0}% En: Magical critical strike chance: {0}%
            _ = this.GetLocalization("Player.MinionDmgStat").Value; // Ru: Урон прислужников: {0}% En: Minion damage: {0}%
            _ = this.GetLocalization("Player.MaxMinionStat").Value; // Ru: Максимальное количество прислужников {0} En: Max minion number: {0}
            _ = this.GetLocalization("Player.RangedDmgStat").Value; // Ru: Урон в дальнем бою: {0}% En: Ranged damage: {0}%
            _ = this.GetLocalization("Player.RangedCritStat").Value; // Ru: Шанс крита в дальнем бою: {0}% En: Ranged critical strike chance: {0}%
            _ = this.GetLocalization("Player.ThrownDmgStat").Value; // Ru: Метательный урон: {0}% En: Throwing damage: {0}%
            _ = this.GetLocalization("Player.ThrownCritStat").Value; // Ru: Шанс крита метательного урона: {0}% En: Throwing critical strike chance: {0}%
            _ = this.GetLocalization("Player.ThrownVelStat").Value; // Ru: Скорость метательных снарядов: {0}% En: Throwing projectiles speed: {0}%

            _ = this.GetLocalization("Player.AssassinDmgStat").Value; // Ru: Урон головореза: {0}% En: Assassin damage: {0}%
            _ = this.GetLocalization("Player.AssassinCritStat").Value; // Ru: Шанс крита головореза: {0}% En: Assassin critical strike chance: {0}%
            _ = this.GetLocalization("Player.CritDmgStat").Value; // Ru: Критический урон: {0}% En: Critical strike damage: {0}%
            _ = this.GetLocalization("Player.CharmStat").Value; // Ru: Обаяние: {0} En: Charm: {0}
            _ = this.GetLocalization("Player.SkillsTree").Value; // Ru: Древо умений: En: Skills tree:
        }
        public override void Initialize()
        {
            EquipmentQuest = 0;
            BookOfSecretsQuest = 0;
            ElessarQuest = 0;
            LuceatQuest = 0;
            GlamdringQuest = 0;
            MinotaurHornQuest = 0;
            ArmorPlateQuest = 0;
            TombstoneQuest = 0;
            NewPriestQuest = 0;
            PotionQuest = 0;
            PhilosopherStoneQuest = 0;
            FoodQuest = 0;
            SunriseQuest = 0;
            ReportQuest = 0;
            activequests = new List<int>();
            completedquests = new List<int>();
            descs = new List<string>();
            shorts = new List<string>();
            descscompl = new List<string>();
            shortscompl = new List<string>();
            desc1 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest1Name");
            desc2 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest2Name");
            desc3 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest3Name");
            desc4 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest4Name");
            desc5 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest5Name");
            desc6 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest6Name");
            desc7 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest7Name");
            desc8 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest8Name");
            desc9 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest9Name");
            desc10 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest10Name");
            desc11 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest11Name");
            desc12 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest12Name");
            desc13 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest13Name");
            desc14 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest14Name");
            short1 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest1Short");
            short2 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest2Short");
            short3 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest3Short");
            short4 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest4Short");
            short5 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest5Short");
            short6 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest6Short");
            short7 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest7Short");
            short8 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest8Short");
            short9 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest9Short");
            short10 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest10Short");
            short11 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests..Quest11Short");
            short12 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest12Short");
            short13 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest13Short");
            short14 = Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.Quest14Short");
        }
        public override void SaveData(TagCompound tag)
        {
            tag["Quest1"] = EquipmentQuest;
            tag["Quest2"] = BookOfSecretsQuest;
            tag["Quest3"] = ElessarQuest;
            tag["Quest4"] = LuceatQuest;
            tag["Quest5"] = GlamdringQuest;
            tag["Quest6"] = MinotaurHornQuest;
            tag["Quest7"] = ArmorPlateQuest;
            tag["Quest8"] = TombstoneQuest;
            tag["Quest9"] = NewPriestQuest;
            tag["Quest10"] = PotionQuest;
            tag["Quest11"] = PhilosopherStoneQuest;
            tag["Quest12"] = FoodQuest;
            tag["Quest13"] = SunriseQuest;
            tag["Quest14"] = ReportQuest;
            tag["SoulScytheQuest"] = SoulScytheQuest;
            tag["PhilosopherStoneCharging"] = PhilosopherStoneCharging;
            tag["ActiveQuests"] = activequests;
            tag["CompletedQuests"] = completedquests;
            tag["QuestDescriptions"] = descs;
            tag["QuestTitles"] = shorts;
            tag["CompletedQuestDescriptions"] = descscompl;
            tag["CompletedQuestTitles"] = shortscompl;
        }
        //public override void SaveData(TagCompound tag)
        //{
        //    TagCompound save_data = new TagCompound();
        //    tag("Quest1", EquipmentQuest);
        //    tag("Quest2", BookOfSecretsQuest);
        //    tag("Quest3", ElessarQuest);
        //    tag("Quest4", LuceatQuest);
        //    tag("Quest5", GlamdringQuest);
        //    tag("Quest6", MinotaurHornQuest);
        //    tag("Quest7", ArmorPlateQuest);
        //    tag("Quest8", TombstoneQuest);
        //    tag("Quest9", NewPriestQuest);
        //    tag("Quest10", PotionQuest);
        //    tag("Quest11", PhilosopherStoneQuest);
        //    tag("Quest12", FoodQuest);
        //    tag("Quest13", SunriseQuest);
        //    tag("Quest14", ReportQuest);
        //    tag("SoulScytheQuest", SoulScytheQuest);
        //    tag("PhilosopherStoneCharging", PhilosopherStoneCharging);
        //    tag("ActiveQuests", activequests);
        //    tag("CompletedQuests", completedquests);
        //    tag("QuestDescriptions", descs);
        //    tag("QuestTitles", shorts);
        //    tag("CompletedQuestDescriptions", descscompl);
        //    tag("CompletedQuestTitles", shortscompl);
        //    return;
        //}
        public override void LoadData(TagCompound tag)
        {
            EquipmentQuest = tag.GetInt("Quest1");
            BookOfSecretsQuest = tag.GetInt("Quest2");
            ElessarQuest = tag.GetInt("Quest3");
            LuceatQuest = tag.GetInt("Quest4");
            GlamdringQuest = tag.GetInt("Quest5");
            MinotaurHornQuest = tag.GetInt("Quest6");
            ArmorPlateQuest = tag.GetInt("Quest7");
            TombstoneQuest = tag.GetInt("Quest8");
            NewPriestQuest = tag.GetInt("Quest9");
            PotionQuest = tag.GetInt("Quest10");
            PhilosopherStoneQuest = tag.GetInt("Quest11");
            FoodQuest = tag.GetInt("Quest12");
            SunriseQuest = tag.GetInt("Quest13");
            ReportQuest = tag.GetInt("Quest14");
            SoulScytheQuest = tag.GetInt("SoulScytheQuest");
            PhilosopherStoneCharging = tag.GetInt("PhilosopherStoneCharging");
            activequests = tag.GetList<int>("ActiveQuests");
            completedquests = tag.GetList<int>("CompletedQuests");
            descs = tag.GetList<string>("QuestDescriptions");
            shorts = tag.GetList<string>("QuestTitles");
            descscompl = tag.GetList<string>("CompletedQuestDescriptions");
            shortscompl = tag.GetList<string>("CompletedQuestTitles");
        }
        void UpdateQuests()
        {
            for(int i = 1; i < 255; i++)
            {
                if(Main.player[i].active)
                {
                    Player.GetModPlayer<Quests>().EquipmentQuest = Main.player[0].GetModPlayer<Quests>().EquipmentQuest;                    
                    Player.GetModPlayer<Quests>().LuceatQuest = Main.player[0].GetModPlayer<Quests>().LuceatQuest;
                    Player.GetModPlayer<Quests>().BookOfSecretsQuest = Main.player[0].GetModPlayer<Quests>().BookOfSecretsQuest;
                    Player.GetModPlayer<Quests>().ElessarQuest = Main.player[0].GetModPlayer<Quests>().ElessarQuest;
                    Player.GetModPlayer<Quests>().GlamdringQuest = Main.player[0].GetModPlayer<Quests>().GlamdringQuest;
                    Player.GetModPlayer<Quests>().MinotaurHornQuest = Main.player[0].GetModPlayer<Quests>().MinotaurHornQuest;
                    Player.GetModPlayer<Quests>().ArmorPlateQuest = Main.player[0].GetModPlayer<Quests>().ArmorPlateQuest;
                    Player.GetModPlayer<Quests>().TombstoneQuest = Main.player[0].GetModPlayer<Quests>().TombstoneQuest;
                    Player.GetModPlayer<Quests>().FoodQuest = Main.player[0].GetModPlayer<Quests>().FoodQuest;
                    Player.GetModPlayer<Quests>().SoulScytheQuest = Main.player[0].GetModPlayer<Quests>().SoulScytheQuest;
                    Player.GetModPlayer<Quests>().PotionQuest = Main.player[0].GetModPlayer<Quests>().PotionQuest;
                    Player.GetModPlayer<Quests>().NewPriestQuest = Main.player[0].GetModPlayer<Quests>().NewPriestQuest;
                    Player.GetModPlayer<Quests>().PhilosopherStoneQuest = Main.player[0].GetModPlayer<Quests>().PhilosopherStoneQuest;
                    Player.GetModPlayer<Quests>().SunriseQuest = Main.player[0].GetModPlayer<Quests>().SunriseQuest;
                    Player.GetModPlayer<Quests>().ReportQuest = Main.player[0].GetModPlayer<Quests>().ReportQuest;
                }
            }
        }
        public override void PreUpdateBuffs()
        {
            #region questlists
            if ((EquipmentQuest >= 10 && EquipmentQuest < 100) && !activequests.Contains(1))
            {
                activequests.Insert(0, 1);
                descs.Insert(0, desc1);
                shorts.Insert(0, short1);
            }
            if (EquipmentQuest == 100 && !completedquests.Contains(1))
            {
                activequests.Remove(1);
                completedquests.Insert(0, 1);
                descscompl.Insert(0, desc1);
                shortscompl.Insert(0, short1);
                shorts.Remove(short1);
                descs.Remove(desc1);
            }
            if (BookOfSecretsQuest >= 10 && BookOfSecretsQuest < 100 && !activequests.Contains(2))
            {
                descs.Insert(0, desc2);
                activequests.Insert(0, 2);
                shorts.Insert(0, short2);
            }
            if (BookOfSecretsQuest == 100 && !completedquests.Contains(2))
            {
                activequests.Remove(2);
                completedquests.Insert(0, 2);
                shorts.Remove(short2);
                descs.Remove(desc2);
                descscompl.Insert(0, desc2);
                shortscompl.Insert(0, short2);
            }
            if (ElessarQuest >= 10 && ElessarQuest < 100 && !activequests.Contains(3))
            {
                descs.Insert(0, desc3);
                activequests.Insert(0, 3);
                shorts.Insert(0, short3);
            }
            if ((ElessarQuest == 100 || ElessarQuest == 200) && !completedquests.Contains(3))
            {
                activequests.Remove(3);
                completedquests.Insert(0, 3);
                shorts.Remove(short3);
                descs.Remove(desc3);
                descscompl.Insert(0, desc3);
                shortscompl.Insert(0, short3);
            }
            if (LuceatQuest >= 10 && LuceatQuest < 100 && !activequests.Contains(4))
            {
                activequests.Insert(0, 4);
                descs.Insert(0, desc4);
                shorts.Insert(0, short4);
            }
            if (LuceatQuest == 100 && !completedquests.Contains(4))
            {
                activequests.Remove(4);
                completedquests.Insert(0, 4);
                shorts.Remove(short4);
                descs.Remove(desc4);
                descscompl.Insert(0, desc4);
                shortscompl.Insert(0, short4);
            }
            if (GlamdringQuest >= 10 && GlamdringQuest < 100 && !activequests.Contains(5))
            {
                activequests.Insert(0, 5);
                descs.Insert(0, desc5);
                shorts.Insert(0, short5);
            }
            if (GlamdringQuest == 100 && !completedquests.Contains(5))
            {
                activequests.Remove(5);
                completedquests.Insert(0, 5);
                shorts.Remove(short5);
                descs.Remove(desc5);
                descscompl.Insert(0, desc5);
                shortscompl.Insert(0, short5);
            }
            if (MinotaurHornQuest >= 10 && MinotaurHornQuest < 100 && !activequests.Contains(6))
            {
                descs.Insert(0, desc6);
                activequests.Insert(0, 6);
                shorts.Insert(0, short6);
            }
            if (MinotaurHornQuest == 100 && !completedquests.Contains(6))
            {
                activequests.Remove(6);
                completedquests.Insert(0, 6);
                shorts.Remove(short6);
                descscompl.Insert(0, desc6);
                descs.Remove(desc6);
                shortscompl.Insert(0, short6);
            }
            if (ArmorPlateQuest >= 10 && ArmorPlateQuest < 100 && !activequests.Contains(7))
            {
                descs.Insert(0, desc7);
                activequests.Insert(0, 7);
                shorts.Insert(0, short7);
            }
            if (ArmorPlateQuest == 100 && !completedquests.Contains(7))
            {
                activequests.Remove(7);
                completedquests.Insert(0, 7);
                shorts.Remove(short7);
                descscompl.Insert(0, desc7);
                descs.Remove(desc7);
                shortscompl.Insert(0, short7);
            }
            if (TombstoneQuest >= 10 && TombstoneQuest < 100 && !activequests.Contains(8))
            {
                descs.Insert(0, desc8);
                activequests.Insert(0, 8);
                shorts.Insert(0, short8);
            }           
            if ((TombstoneQuest == 100 || TombstoneQuest == 200 || TombstoneQuest == 300) && !completedquests.Contains(8))
            {
                activequests.Remove(8);
                completedquests.Insert(0, 8);
                shorts.Remove(short8);
                descs.Remove(desc8);
                descscompl.Insert(0, desc8);
                shortscompl.Insert(0, short8);
            }
            if (NewPriestQuest >= 10 && NewPriestQuest < 100 && !activequests.Contains(9))
            {
                descs.Insert(0, desc9);
                activequests.Insert(0, 9);
                shorts.Insert(0, short9);
            }
            if (NewPriestQuest == 100 && !completedquests.Contains(9))
            {
                activequests.Remove(9);
                completedquests.Insert(0, 9);
                shorts.Remove(short9);
                descs.Remove(desc9);
                descscompl.Insert(0, desc9);
                shortscompl.Insert(0, short9);
            }
            if (PotionQuest >= 10 && PotionQuest < 100 && !activequests.Contains(10))
            {
                descs.Insert(0, desc10);
                activequests.Insert(0, 10);
                shorts.Insert(0, short10);
            }
            if ((PotionQuest == 100 || PotionQuest == 200) && !completedquests.Contains(10))
            {
                activequests.Remove(10);
                completedquests.Insert(0, 10);
                shorts.Remove(short10);
                descs.Remove(desc10);
                descscompl.Insert(0, desc10);
                shortscompl.Insert(0, short10);
            }
            if (PhilosopherStoneQuest >= 10 && PhilosopherStoneQuest < 100 && !activequests.Contains(11))
            {
                descs.Insert(0, desc11);
                activequests.Insert(0, 11);
                shorts.Insert(0, short11);
            }
            if (PhilosopherStoneQuest == 100 && !completedquests.Contains(11))
            {
                activequests.Remove(11);
                completedquests.Insert(0, 11);
                shorts.Remove(short11);
                descscompl.Insert(0, desc11);
                shortscompl.Insert(0, short11);
                descs.Remove(desc11);
            }
            if (FoodQuest >= 10 && FoodQuest < 100 && !activequests.Contains(12))
            {
                descs.Insert(0, desc12);
                activequests.Insert(0, 12);
                shorts.Insert(0, short12);
            }
            if (FoodQuest == 100 && !completedquests.Contains(12))
            {
                activequests.Remove(12);
                completedquests.Insert(0, 12);
                shorts.Remove(short12);
                descscompl.Insert(0, desc12);
                descs.Remove(desc12);
                shortscompl.Insert(0, short12);
            }
            if (SunriseQuest >= 10 && SunriseQuest < 100 && !activequests.Contains(13))
            {
                descs.Insert(0, desc13);
                activequests.Insert(0, 13);
                shorts.Insert(0, short13);
            }
            if (SunriseQuest == 100 && !completedquests.Contains(13))
            {
                activequests.Remove(13);
                completedquests.Insert(0, 13);
                shorts.Remove(short13);
                descs.Remove(desc13);
                descscompl.Insert(0, desc13);
                shortscompl.Insert(0, short13);
            }
            if (ReportQuest >= 10 && ReportQuest < 100 && !activequests.Contains(14))
            {
                descs.Insert(0, desc14);
                activequests.Insert(0, 14);
                shorts.Insert(0, short14);
            }
            if (ReportQuest == 100 && !completedquests.Contains(14))
            {
                activequests.Remove(14);
                completedquests.Insert(0, 14);
                shorts.Remove(short14);
                descs.Remove(desc14);
                descscompl.Insert(0, desc14);
                shortscompl.Insert(0, short14);
            }
            #endregion
            #region UpdateStages
            if (EquipmentQuest == 20 && Player.GetModPlayer<BismuthPlayer>().PlayerClass != 0)
                EquipmentQuest = 30;
            if (EquipmentQuest == 90 && Player.talkNPC == -1)
            {
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
                EquipmentQuest = 100;
                if (!Player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                {
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 1)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Gladius>());
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Scutum>());
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 2)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<WoodenCrossbow>());
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 3)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<WoodenStaff>());
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 4)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Lancea>());
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 5)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Parazonium>());
                    }
                }
            }
            if (LuceatQuest == 90 && Player.talkNPC == -1)
            {
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Luceat>());
                LuceatQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (BookOfSecretsQuest == 90 && Player.talkNPC == -1)
            {
                BookOfSecretsQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (ElessarQuest == 90 && Player.talkNPC == -1)
            {
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Panacea>(), 5);
                ElessarQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (ElessarQuest == 190 && Player.talkNPC == -1)
            {
                ElessarQuest = 200;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (GlamdringQuest == 90 && Player.talkNPC == -1)
            {
                GlamdringQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Glamdring>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (MinotaurHornQuest == 90 && Player.talkNPC == -1)
            {
                MinotaurHornQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<HornOfGondor>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (ArmorPlateQuest == 90 && Player.talkNPC == -1)
            {
                ArmorPlateQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<DwarvenCoin>(), 5);
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (TombstoneQuest == 90 && Player.talkNPC == -1)
            {
                TombstoneQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<UnchargedSoulScythe>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");               
            }
            if (TombstoneQuest == 190 && Player.talkNPC == -1)
            {               
              //  TombstoneQuest = 200;
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                }
                foreach (Player player in Main.player)
                {
                    if (player.active)
                        player.GetModPlayer<Quests>().TombstoneQuest = 200;
                }
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<ImperianBanner>());
            }
            if (TombstoneQuest == 290 && Player.talkNPC == -1)
            {
                TombstoneQuest = 300;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST FAILED!");
            }
            if (NewPriestQuest == 90 && Player.talkNPC == -1)
            {
                NewPriestQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (ReportQuest == 90 && Player.talkNPC == -1)
            {
                ReportQuest = 100;
                if (!Player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<BookOfMazarbul>());
                else
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, 5);
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (PotionQuest == 90 && Player.talkNPC == -1)
            {
                PotionQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<PotionOfInvulnerability>(), 5);
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (PotionQuest == 190 && Player.talkNPC == -1)
            {
                PotionQuest = 200;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST FAILED!");
            }
            if (PhilosopherStoneQuest == 90 && Player.talkNPC == -1)
            {
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<TabulaSmaragdina>());
                PhilosopherStoneQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (SunriseQuest == 90 && Player.talkNPC == -1)
            {
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<PotionOfHumanity>());
                SunriseQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (FoodQuest == 90 && Player.talkNPC == -1)
            {
                FoodQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            #endregion
        }     
        public void OldmanQuests()
        {
            string Oldman_2 = this.GetLocalization("Quests.Oldman_2").Value;
            string Oldman_4 = this.GetLocalization("Quests.Oldman_4").Value;
            string Oldman_5 = this.GetLocalization("Quests.Oldman_5").Value;
            string Oldman_6 = this.GetLocalization("Quests.Oldman_6").Value;
            string Oldman_8 = this.GetLocalization("Quests.Oldman_8").Value;

            if (Main.npcChatText == Oldman_4)
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (LuceatQuest < 10)
            {
                Main.npcChatText = Oldman_2;
                Main.npcChatCornerItem = ModContent.ItemType<UnchargedLuceat>();
                LuceatQuest += 5;
            }
            if (LuceatQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;           
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<GreenKey>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                LuceatQuest = 20;
                return;
            }
            if (LuceatQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<UnchargedLuceat>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        LuceatQuest = 30;
                        Main.npcChatText = Oldman_5;
                        temp = true;
                    }
                }
                if (!temp)
                    Main.npcChatText = Oldman_4;
            }
            if (LuceatQuest == 40 && Player.HasBuff(ModContent.BuffType<AuraOfEmpire>()))
            {
                LuceatQuest = 90;
                Main.npcChatText = Oldman_6;
                
            }
            if (LuceatQuest == 100 && TombstoneQuest == 200 && NewPriestQuest <= 10)
            {
                Main.npcChatText = Oldman_8;
                NewPriestQuest += 5;
            }
            if (NewPriestQuest == 10)
            {
                //Player.talkNPC = -1;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                NewPriestQuest = 20;
                return;
            }

        }
        public void BabaYagaQuests()
        {
            string SwampWitch_2 = this.GetLocalization("Quests.SwampWitch_2").Value;
            string SwampWitch_4 = this.GetLocalization("Quests.SwampWitch_4").Value;
            string SwampWitch_5 = this.GetLocalization("Quests.SwampWitch_5").Value;
            string SwampWitch_6 = this.GetLocalization("Quests.SwampWitch_6").Value;
            string SwampWitch_8 = this.GetLocalization("Quests.SwampWitch_8").Value;
            string SwampWitch_10 = this.GetLocalization("Quests.SwampWitch_10").Value;
            string SwampWitch_13 = this.GetLocalization("Quests.SwampWitch_13").Value;

            if (Main.npcChatText == SwampWitch_4)
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (Main.npcChatText == SwampWitch_10)
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (BookOfSecretsQuest < 10)
            {
                Main.npcChatText = SwampWitch_2;
                Main.npcChatCornerItem = ModContent.ItemType<BookOfSecrets>();
                BookOfSecretsQuest += 5;
            }
            if (BookOfSecretsQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                BookOfSecretsQuest = 20;
                return;
            }
            if (BookOfSecretsQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<BookOfSecrets>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        BookOfSecretsQuest = 90;
                        Main.npcChatText = SwampWitch_5;
                        temp = true;
                    }
                }
                if(!temp)
                    Main.npcChatText = SwampWitch_4;
            }
            if (BookOfSecretsQuest == 100 && ElessarQuest == 0 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().BosWait < 86400)
                Main.npcChatText = SwampWitch_6;          
            if (BookOfSecretsQuest == 100 && ElessarQuest < 10)
            {
                if (Player.GetModPlayer<BismuthPlayer>().BosWait == 86400)
                {
                    Main.npcChatText = SwampWitch_8;
                    Main.npcChatCornerItem = ModContent.ItemType<Elessar>();
                    ElessarQuest += 5;
                }
              
            }
            if (BookOfSecretsQuest == 100 && ElessarQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<BookOfSecrets>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCEPTED!");
                ElessarQuest = 20;
                return;
            }
            if (ElessarQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<UnchargedElessar>() && Player.inventory[num66].stack > 0)
                    {
                       // player.inventory[num66].stack--;
                        ElessarQuest = 190;
                        Main.npcChatText = SwampWitch_13;
                        temp = true;
                    }
                }
                if (!temp)
                    Main.npcChatText = SwampWitch_10;
            }           
        }
        public void BlacksmithQuests()
        {
            string Blacksmith_2 = this.GetLocalization("Quests.Blacksmith_2").Value;
            string Blacksmith_3 = this.GetLocalization("Quests.Blacksmith_3").Value;
            string Blacksmith_4 = this.GetLocalization("Quests.Blacksmith_4").Value;
            string Blacksmith_5 = this.GetLocalization("Quests.Blacksmith_5").Value;
            string Blacksmith_6 = this.GetLocalization("Quests.Blacksmith_6").Value;
            string Blacksmith_8 = this.GetLocalization("Quests.Blacksmith_8").Value;
            string Blacksmith_10 = this.GetLocalization("Quests.Blacksmith_10").Value;
            string Blacksmith_11 = this.GetLocalization("Quests.Blacksmith_11").Value;
            string Blacksmith_13 = this.GetLocalization("Quests.Blacksmith_13").Value;
            string Blacksmith_15 = this.GetLocalization("Quests.Blacksmith_15").Value;
            string Blacksmith_16 = this.GetLocalization("Quests.Blacksmith_16").Value;

            if (Main.npcChatText == Blacksmith_10 || Main.npcChatText == Blacksmith_15)
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (GlamdringQuest < 10)
            {
                Main.npcChatText = string.Format(this.GetLocalization("Quests.ValueBlacksmith_2").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(NPCID.GoblinTinkerer)].GivenName));
                Main.npcChatCornerItem = ModContent.ItemType<GlamdringBlueprint>();
                GlamdringQuest += 5;
            }
            if (GlamdringQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                GlamdringQuest = 20;
                return;
            }
            if (GlamdringQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<GlamdringBlueprint>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        GlamdringQuest = 30;
                        Main.npcChatText = Blacksmith_4;
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Blacksmith_3;
            }
            if (GlamdringQuest == 30)
            {
                if (Player.GetModPlayer<BismuthPlayer>().WaitGlamdring >= 600)
                {
                    Main.npcChatText = Blacksmith_6;                    
                    GlamdringQuest = 90;                   
                }
                else
                {
                    Main.npcChatText = Blacksmith_5;
                }
            }
            if (GlamdringQuest == 100 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledEoC && MinotaurHornQuest < 10)
            {
                Main.npcChatText = Blacksmith_8;
                Main.npcChatCornerItem = ModContent.ItemType<MinotaurHorn>();
                MinotaurHornQuest += 5;
            }
            if (GlamdringQuest == 100 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledEoC && MinotaurHornQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                MinotaurHornQuest = 20;
                return;
            }
            if (MinotaurHornQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<MinotaurHorn>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        MinotaurHornQuest = 90;
                        Main.npcChatText = Blacksmith_11;                      
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Blacksmith_10;
            }
            if (MinotaurHornQuest == 100 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledWoF && ArmorPlateQuest < 10)
            {
                Main.npcChatText = Blacksmith_13;
                Main.npcChatCornerItem = ModContent.ItemType<DwarvenBrokenArmor>();
                ArmorPlateQuest += 5;
            }
            if (MinotaurHornQuest == 100 && ArmorPlateQuest == 10 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledWoF)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                ArmorPlateQuest = 20;
                return;
            }
            if (ArmorPlateQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<DwarvenBrokenArmor>() && Player.inventory[num66].stack >= 5)
                    {
                        Player.inventory[num66].stack -= 5;                        
                        ArmorPlateQuest = 90;
                        Main.npcChatText = string.Format(this.GetLocalization("Quests.Blacksmith_16").Value, Convert.ToString(Main.LocalPlayer.name));                      
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Blacksmith_15;
            }
        }
        public void PriestQuests()
        {
            string Priest_3 = this.GetLocalization("Quests.Priest_3").Value;
            string Priest_5 = this.GetLocalization("Quests.Priest_5").Value;
            string Priest_6 = this.GetLocalization("Quests.Priest_6").Value;
            string Priest_7 = this.GetLocalization("Quests.Priest_7").Value;

            if (Main.npcChatText == Priest_5)
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (TombstoneQuest < 10)
            {
                Main.npcChatText = Priest_3;
                Main.npcChatCornerItem = ModContent.ItemType<WarriorsRemains>();
                TombstoneQuest += 5;
            }
            if (TombstoneQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<DirtyShovel>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                TombstoneQuest = 20;
                return;
            }
            if (TombstoneQuest == 20 || TombstoneQuest == 30)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<WarriorsRemains>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        TombstoneQuest = 90;
                        Main.npcChatText = string.Format(this.GetLocalization("Quests.Priest_6").Value, Convert.ToString(Main.npc[Player.talkNPC].GivenName));
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Priest_5;
               
            }
            else if (TombstoneQuest == 40)
            {
                TombstoneQuest = 290;
                Main.npcChatText = Priest_7;
            }

        }
        public void ConsulQuests()
        {
            string Consul_2 = this.GetLocalization("Quests.Consul_2").Value;
            string Consul_3 = this.GetLocalization("Quests.Consul_3").Value;
            string Consul_4 = this.GetLocalization("Quests.Consul_4").Value;
            if (EquipmentQuest < 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                EquipmentQuest = 20;
                return;
            }
            if (TombstoneQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<DirtyShovel>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        TombstoneQuest = 190;
                        Main.npcChatText = Consul_3;
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                {
                    TombstoneQuest = 25;
                    Main.npcChatText = string.Format(this.GetLocalization("Quests.Consul_4").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Priest>())].GivenName));
                }
            }

            if (NewPriestQuest == 20)
            {
                NewPriestQuest = 90;
                Main.npcChatText = string.Format(this.GetLocalization("Quests.Consul_2").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<StrangeOldman>())].GivenName));               
            }

        }
        public void CommanderQuests()
        {
            string Commander_1 = this.GetLocalization("Quests.Commander_1").Value;
            string Commander_3 = this.GetLocalization("Quests.Commander_3").Value;
            string Commander_5 = this.GetLocalization("Quests.Commander_5").Value;
            string Commander_6 = this.GetLocalization("Quests.Commander_6").Value;
            string Commander_6_2 = this.GetLocalization("Quests.Commander_6_2").Value;
            string Commander_6_3 = this.GetLocalization("Quests.Commander_6_3").Value;

            if (Main.npcChatText == Commander_5)
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (EquipmentQuest == 30)
            {
                EquipmentQuest = 90;
                Main.npcChatText = Commander_1;               
            }
            if (EquipmentQuest == 20)
            {
                EquipmentQuest = 90;
                Main.npcChatText = Commander_1;
            }
            if (ReportQuest < 10 && EquipmentQuest == 100)
            {
                Main.npcChatText = Commander_3; 
                ReportQuest += 5;
            }
            if (ReportQuest == 10 && EquipmentQuest == 100)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                ReportQuest = 20;
                return;
            }
            if (ReportQuest == 20)
                Main.npcChatText = Commander_5;
            if (ReportQuest == 30)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<ScoutsReport>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        ReportQuest = 80;                       
                        Main.npcChatText = Commander_6;
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Commander_5; 
            }
            if (ReportQuest == 80)
            {
                if (!Player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                    Main.npcChatText = Commander_6_2;
                else
                    Main.npcChatText = Commander_6_3;
                ReportQuest = 90;
            }                    
        }
        public void AlchemistQuests()
        {
            string Alchemist_2 = this.GetLocalization("Quests.Alchemist_2").Value;
            string Alchemist_4 = this.GetLocalization("Quests.Alchemist_4").Value;
            string Alchemist_5 = this.GetLocalization("Quests.Alchemist_5").Value;
            string Alchemist_7 = this.GetLocalization("Quests.Alchemist_7").Value;
            string Alchemist_9 = this.GetLocalization("Quests.Alchemist_9").Value;
            string Alchemist_10 = this.GetLocalization("Quests.Alchemist_10").Value;
            string Alchemist_14 = this.GetLocalization("Quests.Alchemist_14").Value;
            string Alchemist_15 = this.GetLocalization("Quests.Alchemist_15").Value;
            string Alchemist_17 = this.GetLocalization("Quests.Alchemist_17").Value;
            string Alchemist_19 = this.GetLocalization("Quests.Alchemist_19").Value;
            string Alchemist_20 = this.GetLocalization("Quests.Alchemist_20").Value;
            string Alchemist_21 = this.GetLocalization("Quests.Alchemist_21").Value;

            if (Main.npcChatText == Alchemist_4 || Main.npcChatText == Alchemist_9 || Main.npcChatText == Alchemist_14)
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (SunriseQuest < 10)
            {
                Main.npcChatText = Alchemist_2;
                Main.npcChatCornerItem = ModContent.ItemType<SunrisePicture>();
                SunriseQuest += 5;
            }
            if (SunriseQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                SunriseQuest = 20;
                return;
            }
            if (SunriseQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<SunrisePicture>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        SunriseQuest = 90;                        
                        Main.npcChatText = Alchemist_5;
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Alchemist_4;
            }


            if (SunriseQuest == 100 && PotionQuest < 10)
            {
                Main.npcChatText = Alchemist_7;
                Main.npcChatCornerItem = ModContent.ItemType<FernFlower>();
                PotionQuest += 5;
            }
            if (PotionQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                PotionQuest = 20;
                return;
            }
            if (PotionQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<FernFlower>() && Player.inventory[num66].stack >= 5)
                    {
                        Player.inventory[num66].stack -= 5;
                        PotionQuest = 30;
                        Main.npcChatText = Alchemist_10;
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Alchemist_9;
            }
            if (PotionQuest == 40)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ItemID.Daybloom && Player.inventory[num66].stack >= 30)
                    {
                        Player.inventory[num66].stack -= 30;
                        PotionQuest = 90;
                        Main.npcChatText = Alchemist_15;
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Alchemist_14;
            }
            if (PotionQuest == 100 && PhilosopherStoneQuest < 10)
            {
                Main.npcChatText = Alchemist_17;
                Main.npcChatCornerItem = ModContent.ItemType<TabulaSmaragdina>();
                PhilosopherStoneQuest += 5;
            }
            if (PotionQuest == 100 && PhilosopherStoneQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                PhilosopherStoneQuest = 20;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<UnchargedTruePhilosopherStone>());
                return;
            }
            if (PhilosopherStoneQuest == 20)
            {
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<TabulaSmaragdina>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        PhilosopherStoneQuest = 30;
                        Main.npcChatText = Alchemist_19;
                        return;
                    }
                }               
            }
            if (PhilosopherStoneQuest == 30)
            {
                if (Player.GetModPlayer<BismuthPlayer>().WaitTabula >= 86400)
                {
                    Main.npcChatText = Alchemist_21;
                    PhilosopherStoneQuest = 90;                    
                }
                else
                {
                    Main.npcChatText = Alchemist_20;
                }
            }
        }
        public void BeggarQuests()
        {
            string Beggar_2 = this.GetLocalization("Quests.Beggar_2").Value;
            string Beggar_4 = this.GetLocalization("Quests.Beggar_4").Value;
            string Beggar_5 = this.GetLocalization("Quests.Beggar_5").Value;

            if (EquipmentQuest == 100 && FoodQuest < 10)
            {
                Main.npcChatText = Beggar_2;
                Main.npcChatCornerItem = ItemID.CookedFish;
                FoodQuest += 5;
            }
            if (FoodQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                FoodQuest = 20;
                return;
            }
            if (FoodQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].buffType == 26)
                    {
                        Player.inventory[num66].stack--;
                        FoodQuest = 90;                     
                        Main.npcChatText = Beggar_5;
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Beggar_4;
            }
        }
        public void BrokenArmorExchange()
        {
            string Blacksmith_17 = this.GetLocalization("Quests.Blacksmith_17").Value;
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (Player.inventory[num66].type == ModContent.ItemType<DwarvenBrokenArmor>() && Player.inventory[num66].stack > 0)
                {
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<DwarvenCoin>(), Player.inventory[num66].stack);
                    Player.inventory[num66].stack = 0;
                    Main.npcChatText = Blacksmith_17;
                    return;
                }
            }
        }
        public void SoulScytheCharging()
        {
            string Priest_8 = this.GetLocalization("Quests.Priest_8").Value;
            string Priest_9 = this.GetLocalization("Quests.Priest_9").Value;

            for (int num66 = 0; num66 < 58; num66++)
            {
                if (Player.inventory[num66].type == ModContent.ItemType<UnchargedSoulScythe>() && Player.inventory[num66].stack > 0)
                {
                    Player.inventory[num66].stack--;
                    SoulScytheQuest = 10;
                    Main.npcChatText = Priest_8;                    
                    return;
                }
            }           
            if (SoulScytheQuest == 10)
            {
                if (Player.GetModPlayer<BismuthPlayer>().WaitSoulScythe >= 1800)
                {
                    Main.npcChatText = Priest_9;
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<SoulScythe>());
                    Player.GetModPlayer<BismuthPlayer>().SoulScytheCharge = 20;
                    SoulScytheQuest = 0;                  
                }               
            }
        }
        public void PholosopherStoneCharging()
        {
            string Alchemist_22 = this.GetLocalization("Quests.Alchemist_22").Value;
            string Alchemist_23 = this.GetLocalization("Quests.Alchemist_23").Value;
            string Alchemist_24 = this.GetLocalization("Quests.Alchemist_24").Value;

            bool temp = false;
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (Player.inventory[num66].type == ModContent.ItemType<UnchargedTruePhilosopherStone>() && Player.inventory[num66].stack > 0)
                {
                    for (int num67 = 0; num67 < 58; num67++)
                    {
                        if (Player.inventory[num67].type == ModContent.ItemType<Aether>() && Player.inventory[num67].stack >= 10)
                        {
                            for (int num68 = 0; num68 < 58; num68++)
                            {
                                if (Player.inventory[num68].type == ItemID.SilverOre && Player.inventory[num68].stack >= 30)
                                {
                                    for (int num69 = 0; num69 < 58; num69++)
                                    {
                                        if (Player.inventory[num69].type == ModContent.ItemType<Quicksilver>() && Player.inventory[num69].stack >= 30)
                                        {
                                            for (int num70 = 0; num70 < 58; num70++)
                                            {
                                                if (Player.inventory[num70].type == ItemID.CopperOre && Player.inventory[num70].stack >= 30)
                                                {
                                                    for (int num71 = 0; num71 < 58; num71++)
                                                    {
                                                        if (Player.inventory[num71].type == ItemID.GoldOre && Player.inventory[num71].stack >= 30)
                                                        {
                                                            for (int num72 = 0; num72 < 58; num72++)
                                                            {
                                                                if (Player.inventory[num72].type == ItemID.IronOre && Player.inventory[num72].stack >= 30)
                                                                {
                                                                    for (int num73 = 0; num73 < 58; num73++)
                                                                    {
                                                                        if (Player.inventory[num73].type == ItemID.TinOre && Player.inventory[num73].stack >= 30)
                                                                        {
                                                                            for (int num74 = 0; num74 < 58; num74++)
                                                                            {
                                                                                if (Player.inventory[num74].type == ItemID.LeadOre && Player.inventory[num74].stack >= 30)
                                                                                {
                                                                                    Player.inventory[num66].stack--;
                                                                                    Player.inventory[num67].stack -= 10;
                                                                                    Player.inventory[num68].stack -= 30;
                                                                                    Player.inventory[num69].stack -= 30;
                                                                                    Player.inventory[num70].stack -= 30;
                                                                                    Player.inventory[num71].stack -= 30;
                                                                                    Player.inventory[num72].stack -= 30;
                                                                                    Player.inventory[num73].stack -= 30;
                                                                                    Player.inventory[num74].stack -= 30;
                                                                                    PhilosopherStoneCharging = 10;
                                                                                    Main.npcChatText = Alchemist_23;
                                                                                    temp = true;
                                                                                    return;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            if (!temp)
                Main.npcChatText = Alchemist_22;

            if (PhilosopherStoneCharging == 10)
            {
                if (Player.GetModPlayer<BismuthPlayer>().WaitStoneCharging >= 1800)
                {
                    Main.npcChatText = Alchemist_24;
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<TruePhilosopherStone>());
                    PhilosopherStoneCharging = 0;
                    CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
                }
            }
        }
        Texture2D emptypage = ModContent.Request<Texture2D>("Bismuth/UI/AdventurersBookPageEmpty").Value;
        Texture2D closebook = ModContent.Request<Texture2D>("Bismuth/UI/CloseBook").Value;
        Texture2D titletex = ModContent.Request<Texture2D>("Bismuth/UI/AdventurersBookTitle").Value;
        Texture2D arrowtex = ModContent.Request<Texture2D>("Bismuth/UI/ABArrow").Value;
        Texture2D activetex = ModContent.Request<Texture2D>("Bismuth/UI/ActivePart").Value;
        Texture2D completedtex = ModContent.Request<Texture2D>("Bismuth/UI/CompletedPart").Value;
        Texture2D emptypatterntex = ModContent.Request<Texture2D>("Bismuth/UI/EmptyPattern").Value;
        Texture2D activeQtex = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuestsSign").Value;
        Texture2D completedQtex = ModContent.Request<Texture2D>("Bismuth/UI/CompletedQuestsSign").Value;
        Texture2D statstex = ModContent.Request<Texture2D>("Bismuth/UI/PlayerStatsSign").Value;
        Texture2D linetex = ModContent.Request<Texture2D>("Bismuth/UI/QuestsLine").Value;
        Texture2D line2tex = ModContent.Request<Texture2D>("Bismuth/UI/QuestsLine2").Value;
        bool treeflag;
        int currentpage = 0;
        int completedpage = 1;
        public static int FrameWidth = 390;
        public static int FrameHeight = 474;
        public static Vector2 FrameStart = new Vector2(bookcoord.X + 510, bookcoord.Y + 60);
        public static void DrawPart(SpriteBatch sb, Texture2D button, Vector2 buttonpos, Vector2 RectStart, int width, int height, Color color) //Intersect работает хуева, поэтому такие костыли
        {
             if ((buttonpos.X + button.Width < RectStart.X && buttonpos.Y + button.Height < RectStart.Y) || (buttonpos.X + button.Width < RectStart.X && buttonpos.Y > RectStart.Y + width) || (buttonpos.X > RectStart.X + width && buttonpos.Y + button.Height < RectStart.Y) || buttonpos.X > RectStart.X && buttonpos.Y > RectStart.Y + height)
               return;

            if (buttonpos.X <= RectStart.X)
            {
                if (buttonpos.Y <= RectStart.Y)
                    sb.Draw(button, RectStart, new Rectangle?(new Rectangle((int)RectStart.X - (int)buttonpos.X, (int)RectStart.Y - (int)buttonpos.Y, (int)buttonpos.X + button.Width - (int)RectStart.X, (int)buttonpos.Y + button.Height - (int)RectStart.Y)), color);
                else if (buttonpos.Y > RectStart.Y && buttonpos.Y + button.Height < RectStart.Y + height)
                    sb.Draw(button, new Vector2(RectStart.X, buttonpos.Y), new Rectangle?(new Rectangle((int)RectStart.X - (int)buttonpos.X, 0, (int)buttonpos.X + button.Width - (int)RectStart.X, button.Height)), color);
                else if (buttonpos.Y + button.Height >= RectStart.Y + height)
                    sb.Draw(button, new Vector2(RectStart.X, buttonpos.Y), new Rectangle?(new Rectangle((int)RectStart.X - (int)buttonpos.X, 0, (int)buttonpos.X + button.Width - (int)RectStart.X, (int)RectStart.Y + height - (int)buttonpos.Y)), color);
            }
            else if (buttonpos.X > RectStart.X && buttonpos.X + button.Width < RectStart.X + width)
            {
                if (buttonpos.Y <= RectStart.Y)
                    sb.Draw(button, new Vector2(buttonpos.X, RectStart.Y), new Rectangle?(new Rectangle(0, (int)RectStart.Y - (int)buttonpos.Y, button.Width, (int)buttonpos.Y + button.Height - (int)RectStart.Y)), color);
                else if (buttonpos.Y > RectStart.Y && buttonpos.Y + button.Height < RectStart.Y + height)
                    sb.Draw(button, buttonpos, color);
                else if (buttonpos.Y + button.Height >= RectStart.Y + height)
                    sb.Draw(button, buttonpos, new Rectangle?(new Rectangle(0, 0, button.Width, (int)RectStart.Y + height - (int)buttonpos.Y)), color);
            }
            else if (buttonpos.X >= RectStart.X)
            {
                if (buttonpos.Y <= RectStart.Y)
                    sb.Draw(button, new Vector2(buttonpos.X, RectStart.Y), new Rectangle?(new Rectangle(0, (int)RectStart.Y - (int)buttonpos.Y, (int)RectStart.X + width - (int)buttonpos.X, (int)buttonpos.Y + button.Height - (int)RectStart.Y)), color);
                else if (buttonpos.Y > RectStart.Y && buttonpos.Y + button.Height < RectStart.Y + height)
                    sb.Draw(button, buttonpos, new Rectangle?(new Rectangle(0, 0, (int)RectStart.X + width - (int)buttonpos.X, button.Height)), color);
                else if (buttonpos.Y + button.Height >= RectStart.Y + height)
                    sb.Draw(button, buttonpos, new Rectangle?(new Rectangle(0, 0, (int)RectStart.X + width - (int)buttonpos.X, (int)RectStart.Y + height - (int)buttonpos.Y)), color);
            }
            
        }
        public void DrawBook(SpriteBatch sb)
        {
            DynamicSpriteFont curfont = FontAssets.MouseText.Value; // было Bismuth.Adonais 
            FrameStart = new Vector2(bookcoord.X + emptypage.Width / 2 + 40, bookcoord.Y + 60);
            treeflag = Main.mouseX > FrameStart.X && Main.mouseX < FrameStart.X + FrameWidth && Main.mouseY > FrameStart.Y && Main.mouseY < FrameStart.Y + FrameHeight && currentpage == 4; // Лежит ли мышь в рамке с древом          
            #region strings

            string desc1 = this.GetLocalization("Quests.Quest1Name").Value; 
            string desc2 = this.GetLocalization("Quests.Quest2Name").Value;
            string desc3 = this.GetLocalization("Quests.Quest3Name").Value;
            string desc4 = this.GetLocalization("Quests.Quest4Name").Value;
            string desc5 = this.GetLocalization("Quests.Quest5Name").Value;
            string desc6 = this.GetLocalization("Quests.Quest6Name").Value;
            string desc7 = this.GetLocalization("Quests.Quest7Name").Value;
            string desc8 = this.GetLocalization("Quests.Quest8Name").Value;
            string desc9 = this.GetLocalization("Quests.Quest9Name").Value;
            string desc10 = this.GetLocalization("Quests.Quest10Name").Value;
            string desc11 = this.GetLocalization("Quests.Quest11Name").Value;
            string desc12 = this.GetLocalization("Quests.Quest12Name").Value;
            string desc13 = this.GetLocalization("Quests.Quest14Name").Value;
            string desc14 = this.GetLocalization("Quests.Quest14Name").Value;

            string short1 = this.GetLocalization("Quests.Quest1Short").Value;
            string short2 = this.GetLocalization("Quests.Quest2Short").Value;
            string short3 = this.GetLocalization("Quests.Quest3Short").Value;
            string short4 = this.GetLocalization("Quests.Quest4Short").Value;
            string short5 = this.GetLocalization("Quests.Quest5Short").Value;
            string short6 = this.GetLocalization("Quests.Quest6Short").Value;
            string short7 = this.GetLocalization("Quests.Quest7Short").Value;
            string short8 = this.GetLocalization("Quests.Quest8Short").Value;
            string short9 = this.GetLocalization("Quests.Quest9Short").Value;
            string short10 = this.GetLocalization("Quests.Quest10Short").Value;
            string short11 = this.GetLocalization("Quests.Quest11Short").Value;
            string short12 = this.GetLocalization("Quests.Quest12Short").Value;
            string short13 = this.GetLocalization("Quests.Quest13Short").Value;
            string short14 = this.GetLocalization("Quests.Quest14Short").Value;

            string BackToTitle = this.GetLocalization("Quests.BackToTitle").Value;
            string LinksText = this.GetLocalization("Quests.LinksText").Value;

            string ActiveQuests = this.GetLocalization("Quests.ActiveQuests").Value;
            string CompletedQuests = this.GetLocalization("Quests.CompletedQuests").Value; 
            string Stages = this.GetLocalization("Quests.Stages").Value;
            string Quest1Stage1 = this.GetLocalization("Quests.Quest1Stage1").Value;
            string Quest1Stage2 = this.GetLocalization("Quests.Quest1Stage2").Value;
            string Quest2Stage1 = this.GetLocalization("Quests.Quest2Stage1").Value;
            string Quest3Stage1_1 = this.GetLocalization("Quests.Quest3Stage1_1").Value;
            string Quest3Stage1_2 = this.GetLocalization("Quests.Quest3Stage1_2").Value;
            string Quest4Stage1 = this.GetLocalization("Quests.Quest4Stage1").Value;
            string Quest4Stage2 = this.GetLocalization("Quests.Quest4Stage2").Value;
            string Quest5Stage1 = this.GetLocalization("Quests.Quest5Stage1").Value;
            string Quest5Stage2 = this.GetLocalization("Quests.Quest5Stage2").Value;
            string Quest6Stage1 = this.GetLocalization("Quests.Quest6Stage1").Value;
            string Quest7Stage1 = this.GetLocalization("Quests.Quest7Stage1").Value;
            string Quest8Stage1_1 = this.GetLocalization("Quests.Quest8Stage1_1").Value;
            string Quest8Stage1_2 = this.GetLocalization("Quests.Quest8Stage1_2").Value;
            string Quest9Stage1 = this.GetLocalization("Quests.Quest9Stage1").Value;
            string Quest10Stage1 = this.GetLocalization("Quests.Quest10Stage1").Value;
            string Quest10Stage2_1 = this.GetLocalization("Quests.Quest10Stage2_1").Value;
            string Quest10Stage3 = this.GetLocalization("Quests.Quest10Stage3").Value;
            string Quest11Stage1 = this.GetLocalization("Quests.Quest11Stage1").Value;
            string Quest11Stage2 = this.GetLocalization("Quests.Quest11Stage2").Value;
            string Quest12Stage1 = this.GetLocalization("Quests.Quest12Stage1").Value;
            string Quest13Stage1 = this.GetLocalization("Quests.Quest13Stage1").Value;
            string Quest14Stage1 = this.GetLocalization("Quests.Quest14Stage1").Value;
            string Quest14Stage2 = this.GetLocalization("Quests.Quest14Stage2").Value;

            string QuestOr = this.GetLocalization("Quests.QuestOr").Value;

            string QuestDiary1 = this.GetLocalization("Quests.QuestDiary1").Value;
            string QuestDiary1_2 = this.GetLocalization("Quests.QuestDiary1_2").Value;
            string QuestDiary2 = this.GetLocalization("Quests.QuestDiary2").Value;
            string QuestDiary2_2 = this.GetLocalization("Quests.QuestDiary2_2").Value;
            string QuestDiary3 = this.GetLocalization("Quests.QuestDiary3").Value;
            string QuestDiary4 = this.GetLocalization("Quests.QuestDiary4").Value;
            string QuestDiary4_2 = this.GetLocalization("Quests.QuestDiary4_2").Value;
            string QuestDiary5 = this.GetLocalization("Quests.QuestDiary5").Value;
            string QuestDiary6 = this.GetLocalization("Quests.QuestDiary6").Value;
            string QuestDiary7 = this.GetLocalization("Quests.QuestDiary7").Value;
            string QuestDiary8 = this.GetLocalization("Quests.QuestDiary8").Value;
            string Quest8Stage1_3 = this.GetLocalization("Quests.Quest8Stage1_3").Value;
            string QuestDiary9 = this.GetLocalization("Quests.QuestDiary9").Value;
            string QuestDiary10 = this.GetLocalization("Quests.QuestDiary10").Value;
            string Quest10Stage2_2 = this.GetLocalization("Quests.Quest10Stage2_2").Value;
            string QuestDiary11 = this.GetLocalization("Quests.QuestDiary11").Value;
            string QuestDiary12 = this.GetLocalization("Quests.QuestDiary12").Value;
            string QuestDiary13 = this.GetLocalization("Quests.QuestDiary13").Value;
            string QuestDiary14 = this.GetLocalization("Quests.QuestDiary14").Value;

            string PlayerStat = this.GetLocalization("Player.PlayerStat").Value;
            string HPStat = this.GetLocalization("Player.HPStat").Value;
            string RegenStat = this.GetLocalization("Player.RegenStat").Value;
            string MPStat = this.GetLocalization("Player.MPStat").Value;
            string ManaCostStat = this.GetLocalization("Player.ManaCostStat").Value;
            string DefenceStat = this.GetLocalization("Player.DefenceStat").Value;
            string EnduranceStat = this.GetLocalization("Player.EnduranceStat").Value;
            string BlockStat = this.GetLocalization("Player.BlockStat").Value;
            string DodgeStat = this.GetLocalization("Player.DodgeStat").Value;
            string ParryStat = this.GetLocalization("Player.ParryStat").Value;
            string MSStat = this.GetLocalization("Player.MSStat").Value;
            string MeleeDmgStat = this.GetLocalization("Player.MeleeDmgStat").Value;
            string MeleeCritStat = this.GetLocalization("Player.MeleeCritStat").Value;
            string MeleeSpeedStat = this.GetLocalization("Player.MeleeSpeedStat").Value;
            string MagicDmgStat = this.GetLocalization("Player.MagicDmgStat").Value;
            string MagicCritStat = this.GetLocalization("Player.MagicCritStat").Value;
            string MinionDmgStat = this.GetLocalization("Player.MinionDmgStat").Value;
            string MaxMinionStat = this.GetLocalization("Player.MaxMinionStat").Value;
            string RangedDmgStat = this.GetLocalization("Player.RangedDmgStat").Value;
            string RangedCritStat = this.GetLocalization("Player.RangedCritStat").Value;
            string ThrownDmgStat = this.GetLocalization("Player.ThrownDmgStat").Value;
            string ThrownCritStat = this.GetLocalization("Player.ThrownCritStat").Value;
            string ThrownVelStat = this.GetLocalization("Player.ThrownVelStat").Value;
            string AssassinDmgStat = this.GetLocalization("Player.AssassinDmgStat").Value;
            string AssassinCritStat = this.GetLocalization("Player.AssassinCritStat").Value;
            string CritDmgStat = this.GetLocalization("Player.CritDmgStat").Value;
            string CharmStat = this.GetLocalization("Player.CharmStat").Value;
            string SkillsTree = this.GetLocalization("Player.SkillsTree").Value;
            #endregion
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().OpenedBook)
            {
                if (Main.mouseX > bookcoord.X && Main.mouseX < bookcoord.X + emptypage.Width && Main.mouseY > bookcoord.Y && Main.mouseY < bookcoord.Y + emptypage.Height && (Player.GetModPlayer<BismuthPlayer>().PlayerClass != 0 ? !treeflag : true) && Main.mouseLeft) //Лежит ли мышь в пределах книги, но вне рамки
                {
                    int oldposX = Main.mouseX - Main.lastMouseX;
                    int oldposY = Main.mouseY - Main.lastMouseY;
                    bookcoord.X += oldposX;
                    bookcoord.Y += oldposY;
                    treecoord.X += oldposX;
                    treecoord.Y += oldposY;
                }
                if (currentpage == 0)
                {
                    sb.Draw(titletex, bookcoord, Color.White);
                    sb.Draw(arrowtex, new Vector2(bookcoord.X + 450, bookcoord.Y + 272), Color.White);
                    if (Main.mouseX > bookcoord.X + 450 && Main.mouseX < bookcoord.X + 450 + arrowtex.Width && Main.mouseY > bookcoord.Y + 272 && Main.mouseY < bookcoord.Y + 272 + arrowtex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        bookcoord.X -= 465;
                        currentpage = 1;
                        SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                    }
                }
                else
                {
                    sb.Draw(emptypage, bookcoord, Color.White);
                    sb.Draw(closebook, bookcoord + new Vector2(894, 20), Color.White);
                    if (Main.mouseX > bookcoord.X + 894 && Main.mouseX < bookcoord.X + 894 + closebook.Width && Main.mouseY > bookcoord.Y + 20 && Main.mouseY < bookcoord.Y + 20 + closebook.Height && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        Player.GetModPlayer<BismuthPlayer>().OpenedBook = false;
                        SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookClose"));
                    }
                    if (currentpage != 0 && currentpage != 1)
                    {
                        Utils.DrawBorderStringFourWay(sb, curfont, BackToTitle, bookcoord.X + 700 - curfont.MeasureString(BackToTitle).X / 2, bookcoord.Y + 570, Color.White, Color.Black, Vector2.Zero);
                        if (Main.mouseX > bookcoord.X + 695 - curfont.MeasureString(BackToTitle).X / 2 && Main.mouseX < bookcoord.X + 705 + curfont.MeasureString(BackToTitle).X / 2 && Main.mouseY > bookcoord.Y + 565 && Main.mouseY < bookcoord.Y + 595 && Main.mouseLeft && Main.mouseLeftRelease)
                        {
                            currentpage = 1;
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                        }
                        if(currentpage == 2 || currentpage == 3)
                        sb.Draw(line2tex, new Vector2(bookcoord.X + 502, bookcoord.Y + 160), Color.White);
                    }
                    if (currentpage == 1)
                    {
                        string text1 = BismuthPlayer.StringBreak(curfont, Language.GetTextValue("Mods.Bismuth.QuestsSystem.Quests.Quests.TitleText"), 380f);
                        Utils.DrawBorderStringFourWay(sb, curfont, text1, bookcoord.X + 26, bookcoord.Y + 26, Color.White, Color.Black, Vector2.Zero);                       
                        string text2 = BismuthPlayer.StringBreak(curfont, LinksText, 380f);
                        sb.Draw(emptypatterntex, new Vector2(bookcoord.X + 510, bookcoord.Y + 14), Color.White);
                        sb.Draw(statstex, new Vector2(bookcoord.X + 526, bookcoord.Y + 20), Color.White);
                        sb.Draw(emptypatterntex, new Vector2(bookcoord.X + 610, bookcoord.Y + 14), Color.White);
                        sb.Draw(activeQtex, new Vector2(bookcoord.X + 631, bookcoord.Y + 18), Color.White);
                        sb.Draw(emptypatterntex, new Vector2(bookcoord.X + 710, bookcoord.Y + 14), Color.White);
                        sb.Draw(completedQtex, new Vector2(bookcoord.X + 722, bookcoord.Y + 18), Color.White);
                        if (Main.mouseX > bookcoord.X + 610 && Main.mouseX < bookcoord.X + 610 + emptypatterntex.Width && Main.mouseY > bookcoord.Y + 14 && Main.mouseY < bookcoord.Y + 14 + emptypatterntex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                        {                            
                            currentpage = 2;
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                        }
                        if (Main.mouseX > bookcoord.X + 710 && Main.mouseX < bookcoord.X + 710 + emptypatterntex.Width && Main.mouseY > bookcoord.Y + 14 && Main.mouseY < bookcoord.Y + 14 + emptypatterntex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                        {
                            currentpage = 3;
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                        }
                        if (Main.mouseX > bookcoord.X + 510 && Main.mouseX < bookcoord.X + 510 + emptypatterntex.Width && Main.mouseY > bookcoord.Y + 14 && Main.mouseY < bookcoord.Y + 14 + emptypatterntex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                        {
                            currentpage = 4;
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                            return;
                        }
                    }
                    float size = 0.8f;

                    if (currentpage == 2)
                    {
                        Utils.DrawBorderStringFourWay(sb, curfont, ActiveQuests, bookcoord.X + 240 - curfont.MeasureString(ActiveQuests).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                        #region questsdescription
                        if(selectedquest != 0 && selectedquest != -1)
                        Utils.DrawBorderStringFourWay(sb, curfont, Stages, bookcoord.X + 700 - curfont.MeasureString(Stages).X / 2, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                        switch (selectedquest)
                        {
                            
                            case 1:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc1, bookcoord.X + 700 - curfont.MeasureString(desc1).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (EquipmentQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest1Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest1Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (EquipmentQuest >= 30 && EquipmentQuest < 100)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest1Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest1Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest1Stage2).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest1Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }                                    
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary1").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianConsul>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 2:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc2, bookcoord.X + 700 - curfont.MeasureString(desc2).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest2Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest2Stage1, bookcoord.X + 518, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, QuestDiary2, 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 3:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc3, bookcoord.X + 700 - curfont.MeasureString(desc3).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc3, bookcoord.X + 520 + curfont.MeasureString(Quest3Stage1_1).X * 0.9f, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest3Stage1_1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest3Stage1_1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    Utils.DrawBorderStringFourWay(sb, curfont, QuestOr, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest3Stage1_2).X * 0.9f, bookcoord.Y + 127), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest3Stage1_2, bookcoord.X + 516, bookcoord.Y + 130, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, QuestDiary3, 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 4:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc4, bookcoord.X + 700 - curfont.MeasureString(desc4).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (LuceatQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest4Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest4Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, QuestDiary4, 380f, size);
                                        Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    }
                                    if (LuceatQuest == 30 || LuceatQuest == 40 || LuceatQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest4Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest4Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest4Stage2).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest4Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, QuestDiary4_2, 380f, size);
                                        Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc5, bookcoord.X + 700 - curfont.MeasureString(desc5).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (GlamdringQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest5Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest5Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (GlamdringQuest == 30 || GlamdringQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest5Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest5Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest5Stage2).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest5Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary5").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName), Convert.ToString(Main.npc[NPC.FindFirstNPC(NPCID.GoblinTinkerer)].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 6:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc6, bookcoord.X + 700 - curfont.MeasureString(desc6).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest6Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest6Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary6").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 7:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc7, bookcoord.X + 700 - curfont.MeasureString(desc7).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest7Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest7Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary7").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                } //!/
                            case 8:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc8, bookcoord.X + 700 - curfont.MeasureString(desc8).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest8Stage1_1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest8Stage1_1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    Utils.DrawBorderStringFourWay(sb, curfont, QuestOr, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest8Stage1_2).X * 0.9f, bookcoord.Y + 127), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest8Stage1_2, bookcoord.X + 516, bookcoord.Y + 130, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary8").Value, Convert.ToString(Main.LocalPlayer.GetModPlayer<BismuthPlayer>().necrosname)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 9:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc9, bookcoord.X + 700 - curfont.MeasureString(desc9).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest9Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest9Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary9").Value, Convert.ToString(Main.LocalPlayer.GetModPlayer<BismuthPlayer>().oldmanname), Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianConsul>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 10:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc10, bookcoord.X + 700 - curfont.MeasureString(desc10).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (PotionQuest == 20 || PotionQuest == 30)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest10Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest10Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (PotionQuest == 40 || PotionQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest10Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest10Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest10Stage2_1).X * 0.9f, bookcoord.Y + 108), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest10Stage2_1, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest10Stage3).X * 0.9f, bookcoord.Y + 127), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest10Stage3, bookcoord.X + 516, bookcoord.Y + 130, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary10").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Alchemist>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 11:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc11, bookcoord.X + 700 - curfont.MeasureString(desc11).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (PhilosopherStoneQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest11Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest11Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (PhilosopherStoneQuest == 30 || PhilosopherStoneQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest11Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest11Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest11Stage2).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest11Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary11").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Alchemist>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 12:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc12, bookcoord.X + 700 - curfont.MeasureString(desc12).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest12Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest12Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary12").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Beggar>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 13:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc13, bookcoord.X + 700 - curfont.MeasureString(desc13).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest13Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest13Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary13").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Alchemist>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 14:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc14, bookcoord.X + 700 - curfont.MeasureString(desc14).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (ReportQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest14Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest14Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (ReportQuest == 30 || ReportQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest14Stage1).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest14Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest14Stage2).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest14Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary14").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianCommander>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            default:
                                break;

                        }
                        #endregion
                        #region active quest selection
                        if (!activequests.Contains(selectedquest))
                            selectedquest = 0;
                        if (activequests.Count > 0)
                        {

                            Utils.DrawBorderStringFourWay(sb, curfont, descs[0], bookcoord.X + 40, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[0], bookcoord.X + 44, bookcoord.Y + 84, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 10 && Main.mouseY < bookcoord.Y + 104 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                SoundEngine.PlaySound(SoundID.MenuOpen);
                                selectedquest = activequests[0];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 108), Color.White);
                        }
                        if (activequests.Count > 1)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[1], bookcoord.X + 40, bookcoord.Y + 126, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[1], bookcoord.X + 44, bookcoord.Y + 150, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 122 && Main.mouseY < bookcoord.Y + 170 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                SoundEngine.PlaySound(SoundID.MenuOpen);
                                selectedquest = activequests[1];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 172), Color.White);
                        }
                        if (activequests.Count > 2)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[2], bookcoord.X + 40, bookcoord.Y + 190, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[2], bookcoord.X + 44, bookcoord.Y + 214, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 186 && Main.mouseY < bookcoord.Y + 234 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                selectedquest = activequests[2];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 236), Color.White);
                        }
                        if (activequests.Count > 3)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[3], bookcoord.X + 40, bookcoord.Y + 254, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[3], bookcoord.X + 44, bookcoord.Y + 278, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 250 && Main.mouseY < bookcoord.Y + 298 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                selectedquest = activequests[3];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 300), Color.White);
                        }
                        if (activequests.Count > 4)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[4], bookcoord.X + 40, bookcoord.Y + 318, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[4], bookcoord.X + 44, bookcoord.Y + 342, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 314 && Main.mouseY < bookcoord.Y + 362 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                selectedquest = activequests[4];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 364), Color.White);
                        }
                        if (activequests.Count > 5)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[5], bookcoord.X + 40, bookcoord.Y + 382, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[5], bookcoord.X + 44, bookcoord.Y + 406, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 378 && Main.mouseY < bookcoord.Y + 426 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                selectedquest = activequests[5];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 428), Color.White);
                        }
                    }
                    #endregion
                    if (currentpage == 3)
                    {
                        Utils.DrawBorderStringFourWay(sb, curfont, CompletedQuests, bookcoord.X + 240 - curfont.MeasureString(CompletedQuests).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                        if (selectedquest2 != 0 && selectedquest2 != -1)
                            Utils.DrawBorderStringFourWay(sb, curfont, Stages, bookcoord.X + 700 - curfont.MeasureString(Stages).X / 2, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                        if (completedquests.Count > 6 && completedpage != 3)
                        {
                            sb.Draw(arrowtex, new Vector2(bookcoord.X + emptypage.Width / 2 - 45, bookcoord.Y + emptypage.Height - 90), Color.White);
                            if (Main.mouseX > bookcoord.X + emptypage.Width / 2 - 45 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 45 + arrowtex.Width && Main.mouseY > bookcoord.Y + emptypage.Height - 90 && Main.mouseY < bookcoord.Y + emptypage.Height - 90 + arrowtex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                completedpage++;
                                SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                            }
                        }
                        if (completedquests.Count > 6 && completedpage != 1)
                        {
                            sb.Draw(arrowtex, new Vector2(bookcoord.X + 30, bookcoord.Y + emptypage.Height - 90), new Rectangle(0, 0, arrowtex.Width, arrowtex.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
                            if (Main.mouseX > bookcoord.X + 30 && Main.mouseX < bookcoord.X + 30 + arrowtex.Width && Main.mouseY > bookcoord.Y + emptypage.Height - 90 && Main.mouseY < bookcoord.Y + emptypage.Height - 90 + arrowtex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                completedpage--;
                                SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                            }
                        }
                        #region completedquestsdescription
                        switch (selectedquest2)
                        {
                            case 1:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc1, bookcoord.X + 700 - curfont.MeasureString(desc1).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest1Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest1Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest1Stage2).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest1Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    if (Player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                                    {
                                        string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary1_2").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianConsul>())].GivenName)), 380f, size);
                                        Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    }
                                    else
                                    {
                                        string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary1").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianConsul>())].GivenName)), 380f, size);
                                        Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc2, bookcoord.X + 700 - curfont.MeasureString(desc2).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest2Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest2Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, QuestDiary2_2, 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 3:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc3, bookcoord.X + 700 - curfont.MeasureString(desc3).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (ElessarQuest == 100)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest3Stage1_1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest3Stage1_1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (ElessarQuest == 200)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest3Stage1_2).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest3Stage1_2, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, QuestDiary3, 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 4:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc4, bookcoord.X + 700 - curfont.MeasureString(desc4).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest4Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest4Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest4Stage2).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest4Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, QuestDiary4_2, 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 5:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc5, bookcoord.X + 700 - curfont.MeasureString(desc5).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest5Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest5Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest5Stage2).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest5Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary5").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName), Convert.ToString(Main.npc[NPC.FindFirstNPC(NPCID.GoblinTinkerer)].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 6:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc6, bookcoord.X + 700 - curfont.MeasureString(desc6).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest6Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest6Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary6").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 7:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc7, bookcoord.X + 700 - curfont.MeasureString(desc7).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest7Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest7Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary7").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                } 
                            case 8:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc8, bookcoord.X + 700 - curfont.MeasureString(desc8).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (TombstoneQuest == 100)
                                    {
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest8Stage1_1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest8Stage1_1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    }
                                    if (TombstoneQuest == 300)
                                    {
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest8Stage1_3, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest8Stage1_3).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    }
                                    if (TombstoneQuest == 200)
                                    {
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest8Stage1_2, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest8Stage1_2).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary8").Value, Convert.ToString(Main.LocalPlayer.GetModPlayer<BismuthPlayer>().necrosname)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 9:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc9, bookcoord.X + 700 - curfont.MeasureString(desc9).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest9Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest9Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary9").Value, Convert.ToString(Main.LocalPlayer.GetModPlayer<BismuthPlayer>().oldmanname), Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianConsul>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 10:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc10, bookcoord.X + 700 - curfont.MeasureString(desc10).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest10Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest10Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    if (PotionQuest == 100)
                                    {

                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest10Stage2_1).X * 0.9f, bookcoord.Y + 108), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest10Stage2_1, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest10Stage3).X * 0.9f, bookcoord.Y + 128), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest10Stage3, bookcoord.X + 516, bookcoord.Y + 130, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (PotionQuest == 200)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest10Stage2_2).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Quest10Stage2_2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary10").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Alchemist>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 11:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc11, bookcoord.X + 700 - curfont.MeasureString(desc11).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest11Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest11Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest11Stage2).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest11Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary11").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Alchemist>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 12:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc12, bookcoord.X + 700 - curfont.MeasureString(desc12).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest12Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest12Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary12").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Beggar>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 13:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc13, bookcoord.X + 700 - curfont.MeasureString(desc13).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest13Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest13Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary13").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Alchemist>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 14:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc14, bookcoord.X + 700 - curfont.MeasureString(desc14).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest14Stage1).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest14Stage1, bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Quest14Stage2).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Quest14Stage2, bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, string.Format(this.GetLocalization("Quests.QuestDiary14").Value, Convert.ToString(Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianCommander>())].GivenName)), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            default:
                                break;

                        }
                        #endregion
                        #region completed quest selection
                        if (completedpage == 1)
                        {
                            if (completedquests.Count > 0)
                            {

                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[0], bookcoord.X + 40, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[0], bookcoord.X + 44, bookcoord.Y + 84, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 10 && Main.mouseY < bookcoord.Y + 104 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    SoundEngine.PlaySound(SoundID.MenuOpen);
                                    selectedquest2 = completedquests[0];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 108), Color.White);
                            }
                            if (completedquests.Count > 1)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[1], bookcoord.X + 40, bookcoord.Y + 126, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[1], bookcoord.X + 44, bookcoord.Y + 150, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 122 && Main.mouseY < bookcoord.Y + 170 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    SoundEngine.PlaySound(SoundID.MenuOpen);
                                    selectedquest2 = completedquests[1];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 172), Color.White);
                            }
                            if (completedquests.Count > 2)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[2], bookcoord.X + 40, bookcoord.Y + 190, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[2], bookcoord.X + 44, bookcoord.Y + 214, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 186 && Main.mouseY < bookcoord.Y + 234 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[2];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 236), Color.White);
                            }
                            if (completedquests.Count > 3)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[3], bookcoord.X + 40, bookcoord.Y + 254, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[3], bookcoord.X + 44, bookcoord.Y + 278, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 250 && Main.mouseY < bookcoord.Y + 298 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[3];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 300), Color.White);
                            }
                            if (completedquests.Count > 4)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[4], bookcoord.X + 40, bookcoord.Y + 318, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[4], bookcoord.X + 44, bookcoord.Y + 342, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 314 && Main.mouseY < bookcoord.Y + 362 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[4];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 364), Color.White);
                            }
                            if (completedquests.Count > 5)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[5], bookcoord.X + 40, bookcoord.Y + 382, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[5], bookcoord.X + 44, bookcoord.Y + 406, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 378 && Main.mouseY < bookcoord.Y + 426 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[5];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 428), Color.White);
                            }
                        }
                        if (completedpage == 2)
                        {
                            if (completedquests.Count > 6)
                            {

                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[6], bookcoord.X + 40, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[6], bookcoord.X + 44, bookcoord.Y + 84, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 10 && Main.mouseY < bookcoord.Y + 104 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    SoundEngine.PlaySound(SoundID.MenuOpen);
                                    selectedquest2 = completedquests[6];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 108), Color.White);
                            }
                            if (completedquests.Count > 7)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[7], bookcoord.X + 40, bookcoord.Y + 126, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[7], bookcoord.X + 44, bookcoord.Y + 150, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 122 && Main.mouseY < bookcoord.Y + 170 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    SoundEngine.PlaySound(SoundID.MenuOpen);
                                    selectedquest2 = completedquests[7];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 172), Color.White);
                            }
                            if (completedquests.Count > 8)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[8], bookcoord.X + 40, bookcoord.Y + 190, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[8], bookcoord.X + 44, bookcoord.Y + 214, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 186 && Main.mouseY < bookcoord.Y + 234 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[8];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 236), Color.White);
                            }
                            if (completedquests.Count > 9)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[9], bookcoord.X + 40, bookcoord.Y + 254, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[9], bookcoord.X + 44, bookcoord.Y + 278, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 250 && Main.mouseY < bookcoord.Y + 298 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[9];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 300), Color.White);
                            }
                            if (completedquests.Count > 10)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[10], bookcoord.X + 40, bookcoord.Y + 318, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[10], bookcoord.X + 44, bookcoord.Y + 342, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 314 && Main.mouseY < bookcoord.Y + 362 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[10];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 364), Color.White);
                            }
                            if (completedquests.Count > 11)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[11], bookcoord.X + 40, bookcoord.Y + 382, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[11], bookcoord.X + 44, bookcoord.Y + 406, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 378 && Main.mouseY < bookcoord.Y + 426 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[11];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 428), Color.White);
                            }
                        }
                        if (completedpage == 3)
                        {
                            if (completedquests.Count > 12)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[12], bookcoord.X + 40, bookcoord.Y + 382, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[12], bookcoord.X + 44, bookcoord.Y + 406, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 378 && Main.mouseY < bookcoord.Y + 426 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[12];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 108), Color.White);
                            }
                        }
                        #endregion
                    }
                    if (currentpage == 4)
                    {

                        #region Stats
                        float meleeDamage = Player.GetDamage(DamageClass.Melee).Additive;
                        float magicDamage = Player.GetDamage(DamageClass.Magic).Additive;
                        float summonDamage = Player.GetDamage(DamageClass.Summon).Additive;
                        float rangerDamage = Player.GetDamage(DamageClass.Ranged).Additive;
                        float throwingDamage = Player.GetDamage(DamageClass.Throwing).Additive;

                        Utils.DrawBorderStringFourWay(sb, curfont, PlayerStat, bookcoord.X + 240 - curfont.MeasureString(PlayerStat).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.HPStat").Value, Convert.ToString(Player.statLifeMax2)), bookcoord.X + 70, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero, 0.82f);                                                
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.RegenStat").Value, Convert.ToString(Player.lifeRegen / 2), Convert.ToString(Player.lifeRegen % 2 == 0 ? ".5" : "")), bookcoord.X + 70, bookcoord.Y + 80, Color.White, Color.Black, Vector2.Zero, 0.82f);                      
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.MPStat").Value, Convert.ToString(Player.statManaMax2)), bookcoord.X + 70, bookcoord.Y + 100, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.ManaCostStat").Value, Convert.ToString(Player.manaCost * 100)), bookcoord.X + 70, bookcoord.Y + 120, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.DefenceStat").Value, Convert.ToString(Player.statDefense)), bookcoord.X + 70, bookcoord.Y + 140, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.EnduranceStat").Value, Convert.ToString(Player.endurance * 100)), bookcoord.X + 70, bookcoord.Y + 160, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.BlockStat").Value, Convert.ToString(Player.GetModPlayer<BismuthPlayer>().BlockChance + Player.GetModPlayer<BismuthPlayer>().BlockChanceForSkills)), bookcoord.X + 70, bookcoord.Y + 180, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.DodgeStat").Value, Convert.ToString(Player.GetModPlayer<BismuthPlayer>().DodgeChance + Player.GetModPlayer<BismuthPlayer>().DodgeChanceForSkills)), bookcoord.X + 70, bookcoord.Y + 200, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.ParryStat").Value, Convert.ToString(Player.GetModPlayer<BismuthPlayer>().ParryChance + Player.GetModPlayer<BismuthPlayer>().ParryChanceForSkills)), bookcoord.X + 70, bookcoord.Y + 220, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.MSStat").Value, Convert.ToString(Player.moveSpeed * 100)), bookcoord.X + 70, bookcoord.Y + 240, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.MeleeDmgStat").Value, (int)(meleeDamage * 100)), bookcoord.X + 70, bookcoord.Y + 260, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.MeleeCritStat").Value, Convert.ToString(Player.GetCritChance(DamageClass.Melee))), bookcoord.X + 70, bookcoord.Y + 280, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.MeleeSpeedStat").Value, Convert.ToString((int)(((float)1 / Player.GetAttackSpeed(DamageClass.Melee)) * 100))), bookcoord.X + 70, bookcoord.Y + 300, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.MagicDmgStat").Value, (int)(magicDamage * 100)), bookcoord.X + 70, bookcoord.Y + 320, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.MagicCritStat").Value, Convert.ToString(Player.GetCritChance(DamageClass.Magic))), bookcoord.X + 70, bookcoord.Y + 340, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.MinionDmgStat").Value, (int)(summonDamage * 100)), bookcoord.X + 70, bookcoord.Y + 360, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.MaxMinionStat").Value, Convert.ToString(Player.maxMinions)), bookcoord.X + 70, bookcoord.Y + 380, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.RangedDmgStat").Value, (int)(rangerDamage * 100)), bookcoord.X + 70, bookcoord.Y + 400, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.RangedCritStat").Value, Convert.ToString(Player.GetCritChance(DamageClass.Ranged))), bookcoord.X + 70, bookcoord.Y + 420, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.ThrownDmgStat").Value, (int)(throwingDamage * 100)), bookcoord.X + 70, bookcoord.Y + 440, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.ThrownCritStat").Value, Convert.ToString(Player.GetCritChance(DamageClass.Throwing))), bookcoord.X + 70, bookcoord.Y + 460, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.ThrownVelStat").Value, Convert.ToString(Player.ThrownVelocity * 100)), bookcoord.X + 70, bookcoord.Y + 480, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.AssassinDmgStat").Value, Convert.ToString(Player.GetModPlayer<ModP>().assassinDamage * 100)), bookcoord.X + 70, bookcoord.Y + 500, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.AssassinCritStat").Value, Convert.ToString(Player.GetModPlayer<ModP>().assassinCrit)), bookcoord.X + 70, bookcoord.Y + 520, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.CritDmgStat").Value, Convert.ToString((Player.GetModPlayer<BismuthPlayer>().critDmgMult + Player.GetModPlayer<BismuthPlayer>().critDmgMultForSkills) * 100)), bookcoord.X + 70, bookcoord.Y + 540, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, string.Format(this.GetLocalization("Player.CharmStat").Value, Convert.ToString(Player.GetModPlayer<BismuthPlayer>().Charm)), bookcoord.X + 70, bookcoord.Y + 560, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        #endregion
                        Utils.DrawBorderStringFourWay(sb, curfont, SkillsTree, bookcoord.X + 700 - curfont.MeasureString(SkillsTree).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                        if (Player.GetModPlayer<BismuthPlayer>().PlayerClass != 0)
                        {
                            if (treecoord.X > FrameStart.X)
                                treecoord.X = FrameStart.X;
                            if (treecoord.X + ActualPanel.Width < FrameStart.X + FrameWidth)
                                treecoord.X = FrameStart.X + FrameWidth - ActualPanel.Width;//
                            if (treecoord.Y > FrameStart.Y)
                                treecoord.Y = FrameStart.Y;
                            if (treecoord.Y + ActualPanel.Height < FrameStart.Y + FrameHeight)
                                treecoord.Y = FrameStart.Y + FrameHeight - ActualPanel.Height;
                            if (treeflag && Main.mouseLeft) // Лежит ли мышь в пределах рамки
                            {
                                int oldposX = Main.mouseX - Main.lastMouseX;
                                int oldposY = Main.mouseY - Main.lastMouseY;
                                if (treecoord.X <= FrameStart.X && treecoord.X + ActualPanel.Width >= FrameStart.X + FrameWidth && treecoord.Y <= FrameStart.Y && treecoord.Y + ActualPanel.Height >= FrameStart.Y + FrameHeight)
                                {
                                    treecoord.X += oldposX;
                                    treecoord.Y += oldposY;
                                }
                                if (treecoord.X > FrameStart.X)
                                    treecoord.X = FrameStart.X;
                                if (treecoord.X + ActualPanel.Width < FrameStart.X + FrameWidth)
                                    treecoord.X = FrameStart.X + FrameWidth - ActualPanel.Width;//
                                if (treecoord.Y > FrameStart.Y)
                                    treecoord.Y = FrameStart.Y;
                                if (treecoord.Y + ActualPanel.Height < FrameStart.Y + FrameHeight)
                                    treecoord.Y = FrameStart.Y + FrameHeight - ActualPanel.Height;

                            }
                            sb.Draw(ActualPanel, FrameStart, new Rectangle?(new Rectangle((int)(FrameStart.X - treecoord.X), (int)(FrameStart.Y - treecoord.Y), FrameWidth, FrameHeight)), Color.White);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 1)
                                Player.GetModPlayer<BismuthPlayer>().DrawWarriorTree(sb);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 2)
                                Player.GetModPlayer<BismuthPlayer>().DrawRangerTree(sb);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 3)
                                Player.GetModPlayer<BismuthPlayer>().DrawWizardTree(sb);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 4)
                                Player.GetModPlayer<BismuthPlayer>().DrawThrowerTree(sb);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 5)
                                Player.GetModPlayer<BismuthPlayer>().DrawAssassinTree(sb);
                        }
                        else
                        {
                            Utils.DrawBorderStringFourWay(sb, Bismuth.Adonais, "Use engraving to choose your class", bookcoord.X + 514, bookcoord.Y + 300, Color.White, Color.Black, Vector2.Zero, 1.1f);
                        }
                    }
                }
            }
            else
            {
                currentpage = 0;
                bookcoord = new Vector2(Main.screenWidth / 2 - 237, 200);
            }          
        }
    }
}
