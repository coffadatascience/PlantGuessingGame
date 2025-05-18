using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::PlantGuessingGame.DataModels;
using global::PlantGuessingGame.Enums;
using System.Collections.Generic;

namespace PlantGuessingGame.Services
{

    /// <summary>
    /// class to seed the database if it doesnt have content
    /// </summary>
    public static class PlantSeedData
    {

        /// <summary>
        /// return list with plants
        /// </summary>
        /// <returns></returns>
        public static List<Plant> GetAllPlants(IEnumerable<Phylum> phyla)
        {

            return new List<Plant>
            {
                //Nandina
                new Plant
                {
                    Id = 0,
                    LocalName = "Nandina",
                    CommonName = "Heavenly Bamboo",
                    Family = "Berberidaceae",
                    Genus = "Nandina",
                    Species = "domestica",
                    Description = "A popular ornamental, upright evergreen shrub with beautiful red berries and colorful foliage. Native to eastern Asia, widely grown for its ornamental value. Leaves are purplish in spring and winter, green in summer, and red in autumn. Small white flowers in summer, followed by bright red berries that persist into winter.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Purple (spring/winter), Green (summer), Red (autumn), White (flowers), Red (berries)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    TrimmingInstructions = "Thin out old stems to maintain density and shape. Remove dead or damaged wood.",
                    TrimmingPeriod = "Late winter to early spring, after risk of frost",
                    TemperatureRangeMinimum = -18,
                    TemperatureRangeMaximum = 35,
                    IsPoisonous = true,
                    FertilizationMethod = "General-purpose fertilizer in spring. Not heavy feeders; avoid over-fertilization.",
                    Shape = "Upright, bushy shrub with bamboo-like appearance",
                    FullGrownHeight = 200,
                    FullGrownWidth = 150
                },
                //Haagbeuk
                new Plant
                {
                    Id = 1,
                    LocalName = "Haagbeuk",
                    CommonName = "European Hornbeam",
                    Family = "Betulaceae",
                    Genus = "Carpinus",
                    Species = "betulus",
                    Description = "A deciduous tree often used for hedging, with a dense, narrow crown. Leaves are oval, double-serrated, and turn yellow to orange in autumn. Produces small, inconspicuous flowers in spring and winged nuts in autumn. Native to Europe and western Asia.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum) GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green (spring/summer), Yellow-Orange (autumn)",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Trim to shape in late summer if used as a hedge. Remove dead or diseased wood as needed.",
                    TrimmingPeriod = "Late summer for hedging; winter for structural pruning",
                    TemperatureRangeMinimum = -30,
                    TemperatureRangeMaximum = 35,
                    IsPoisonous = false,
                    FertilizationMethod = "Apply balanced fertilizer in early spring if soil is poor. Generally low maintenance.",
                    Shape = "Upright tree with dense, oval to pyramidal crown. Can be pruned into hedges.",
                    FullGrownHeight = 2000,
                    FullGrownWidth = 1500
                },
                //BeukenHaag
                new Plant
                {
                    Id = 2,
                    LocalName = "BeukenHaag",
                    CommonName = "European Beech",
                    Family = "Fagaceae",
                    Genus = "Fagus",
                    Species = "sylvatica",
                    Description = "A classic hedge and woodland tree with smooth, silvery-gray bark and glossy, wavy-edged leaves. In spring and summer, leaves are bright to deep green; in autumn, they turn copper, rust, or gold, and in hedges, the dead leaves often persist through winter, providing year-round screening. Beech is shade-tolerant, easy to grow, and responds well to pruning. It is cold-hardy, deer-resistant, and thrives in a range of soils, but prefers well-drained conditions. Flowers appear in April–May, followed by beech nuts in autumn. Left unpruned, it can reach 20–30 meters tall and 10–20 meters wide, but is usually kept much smaller as a hedge.[1][2][5][7]",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Shrub, // Used as a hedge, typically maintained as a shrub[1][5]
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),

                    IsEatable = false, // Not edible in hedge form
                    Color = "Bright green (spring), deep green (summer), copper/rust/gold (autumn), brown (winter leaves on hedge)[1][5][7]",
                    IsFlowering = true, // Produces small, inconspicuous flowers in spring[7]
                    IsEvergreen = false, // Deciduous, but dead leaves persist on hedges through winter[1][5][7]
                    TrimmingInstructions = "Trim established hedges in mid-August to maintain size and density. For new hedges, light formative pruning in winter. Avoid pruning between March and July due to bird nesting. Overgrown hedges can be hard-pruned in late winter, staggering cuts over 2–3 years if necessary.[6][8][9]",
                    TrimmingPeriod = "Main trim in mid-August; formative pruning in winter for young hedges; hard pruning in late winter if needed.[6][8][9]",
                    TemperatureRangeMinimum = -23, // Hardy to at least -23°C (USDA zone 5)[7]
                    TemperatureRangeMaximum = 35,  // Tolerates summer heat, prefers moderate climates[5]
                    IsPoisonous = false, // Not considered poisonous
                    FertilizationMethod = "Apply balanced fertilizer in early spring if soil is poor. Mulch in autumn to protect roots and retain moisture.[5]",
                    Shape = "Dense, upright hedge with smooth, graceful branches and wavy-edged leaves. Left unpruned, forms a large, majestic tree with a broad crown.[1][2][5][7]",
                    FullGrownHeight = 750, // Up to 7.5 meters as a hedge, 20–30 meters as a tree[7]
                    FullGrownWidth = 200,  // Typically maintained at 0.5–2 meters as a hedge, up to 10–20 meters as a tree[7]
                },
                // Hortensia
                new Plant
                 {
                    Id = 3,
                    LocalName = "Hortensia",
                    CommonName = "Bigleaf Hydrangea",
                    Family = "Hydrangeaceae",
                    Genus = "Hydrangea",
                    Species = "macrophylla",
                    Description = "A deciduous shrub widely cultivated for its large, globular or flattened clusters of showy flowers in shades of pink, blue, purple, and, rarely, white. Leaves are large, ovate, and serrated. Flower color varies with soil pH: blue in acidic soils, pink in alkaline. Blooms from summer into autumn. Native to Japan, popular in gardens worldwide.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Pink, blue, purple, red, or white flowers (color depends on soil pH); dark green leaves",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Prune after flowering by removing spent blooms and weak stems. Avoid heavy pruning, as flower buds form on old wood for most cultivars.",
                    TrimmingPeriod = "Late summer to early autumn, after flowering",
                    TemperatureRangeMinimum = -23,
                    TemperatureRangeMaximum = 35,
                    IsPoisonous = true,
                    FertilizationMethod = "Apply balanced, slow-release fertilizer in spring. Acidic fertilizer for blue flowers, lime for pink.",
                    Shape = "Rounded, bushy shrub with large, globular or flattened flower clusters",
                    FullGrownHeight = 200,
                    FullGrownWidth = 250
                },

                // Plane Tree
                new Plant
                {
                    Id = 4,
                    LocalName = "Plataan",
                    CommonName = "London Plane tree",
                    Family = "Platanaceae",
                    Genus = "Platanus",
                    Species = "acerifolia",
                    Description = "A large, fast-growing deciduous tree known for its distinctive mottled, exfoliating bark and broad, maple-like leaves. Widely planted in cities for its tolerance to pollution and pruning. Produces small, spherical fruit clusters that persist into winter.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green leaves (spring/summer), yellow-brown (autumn), mottled cream/green/grey bark",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Prune in late winter to early spring to remove dead or crossing branches. Can be pollarded to control size.",
                    TrimmingPeriod = "Late winter to early spring",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 40,
                    IsPoisonous = false,
                    FertilizationMethod = "Generally not required in urban soils. Mulch and water young trees.",
                    Shape = "Broad, spreading crown with strong, upright branches",
                    FullGrownHeight = 3000,
                    FullGrownWidth = 2000
                },

                // Apple tree
                new Plant
                {
                    Id = 5,
                    LocalName = "Appel tree",
                    CommonName = "Apple Tree",
                    Family = "Rosaceae",
                    Genus = "Malus",
                    Species = "domestica",
                    Description = "A medium-sized, deciduous tree widely cultivated for its edible fruit. Apple trees produce showy white or pink-tinged flowers in spring, followed by crisp, sweet or tart apples in late summer to autumn. There are thousands of cultivars with varying fruit colors, flavors, and uses. Native to Central Asia, now grown worldwide.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true,
                    Color = "Green leaves (spring/summer), yellow/red/orange (autumn); white or pink flowers; fruit varies in color: red, green, yellow",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Prune in late winter to early spring to maintain shape, remove dead or diseased wood, and encourage productive branches. Young trees require formative pruning for strong structure.",
                    TrimmingPeriod = "Late winter to early spring",
                    TemperatureRangeMinimum = -30,
                    TemperatureRangeMaximum = 35,
                    IsPoisonous = false,
                    FertilizationMethod = "Apply balanced fertilizer in early spring if soil is poor. Mulch annually to retain moisture and provide nutrients.",
                    Shape = "Rounded, spreading crown with dense branching",
                    FullGrownHeight = 900,
                    FullGrownWidth = 900
                },

            // Alder (Alnus glutinosa)
                new Plant
                {
                    Id = 6,
                    LocalName = "Els",
                    CommonName = "Alder",
                    Family = "Betulaceae",
                    Genus = "Alnus",
                    Species = "glutinosa",
                    Description = "A medium-sized, fast-growing deciduous tree that thrives in wet soils, often along rivers and ponds. Recognizable by its dark, fissured bark, rounded glossy green leaves, and woody, cone-like fruits. Catkins appear in early spring, providing an important pollen source for insects. Native to Europe and western Asia. The tree can reach 20–30 meters tall with a pyramidal to oval crown and is valued for its nitrogen-fixing roots and ecological importance in wet habitats.[1][2][4][5][6]",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green leaves (spring/summer), yellow (autumn); dark brown to black bark; brown catkins and cones",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Prune in late autumn or winter to remove dead or crossing branches. Minimal pruning required unless shaping or removing damaged wood.",
                    TrimmingPeriod = "Late autumn to winter",
                    TemperatureRangeMinimum = -25, // Hardy to at least -25°C[5][6]
                    TemperatureRangeMaximum = 35,
                    IsPoisonous = false,
                    FertilizationMethod = "Rarely needed; tolerates poor soils due to nitrogen-fixing roots. Mulch young trees to retain moisture.",
                    Shape = "Pyramidal to oval crown, often with multiple stems; can form dense thickets in wet areas[1][5][6]",
                    FullGrownHeight = 3000, // Up to 30 meters[2][5][6]
                    FullGrownWidth = 1000,  // Up to 10 meters[5][6]
                },

                // Tulip (Tulipa gesneriana)
                new Plant
                {
                    Id = 7,
                    LocalName = "Tulip",
                    CommonName = "Tulip",
                    Family = "Liliaceae",
                    Genus = "Tulipa",
                    Species = "gesneriana",
                    Description = "A bulbous, spring-flowering perennial known for its vibrant, cup-shaped flowers in a wide range of colors. Tulips are iconic garden plants, especially in the Netherlands, and bloom from early to late spring depending on the variety. Leaves are lance-shaped and bluish-green. Bulbs are planted in autumn for spring display.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Bulb,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Wide range: red, yellow, pink, purple, orange, white, and multicolored",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Remove spent flowers after blooming to prevent seed formation. Allow leaves to die back naturally to feed the bulb.",
                    TrimmingPeriod = "Deadhead after flowering; remove foliage only once it has yellowed and died back (late spring to early summer)",
                    TemperatureRangeMinimum = -25,
                    TemperatureRangeMaximum = 30,
                    IsPoisonous = true,
                    FertilizationMethod = "Apply a balanced bulb fertilizer at planting and again as shoots emerge in spring.",
                    Shape = "Upright, cup-shaped flowers on single, unbranched stems; lance-shaped leaves",
                    FullGrownHeight = 60,  // Most garden tulips reach 20–60 cm
                    FullGrownWidth = 15,   // Each plant typically 10–15 cm wide
                },

                // Narcis (Narcissus pseudonarcissus)
                new Plant
                {
                    Id = 8,
                    LocalName = "Narcis",
                    CommonName = "Daffodil",
                    Family = "Amaryllidaceae",
                    Genus = "Narcissus",
                    Species = "pseudonarcissus",
                    Description = "A spring-flowering perennial bulb known for its trumpet-shaped flowers, typically yellow or white, sometimes with orange or pink centers. Leaves are long, slender, and bluish-green. Each stem usually bears a single fragrant flower with a darker yellow trumpet surrounded by paler yellow tepals. Native to Europe, daffodils are widely grown in gardens and naturalized in meadows and woodlands. Bulbs are planted in autumn for a cheerful spring display. All parts of the plant are poisonous if ingested.[1][2][3][5][6][7][8]",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Bulb,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Yellow, white, orange, or bicolored flowers; bluish-green leaves",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Remove spent flowers after blooming to prevent seed formation. Allow leaves to die back naturally to feed the bulb.",
                    TrimmingPeriod = "Deadhead after flowering; remove foliage only once it has yellowed and died back (late spring)",
                    TemperatureRangeMinimum = -20, // Hardy to at least -20°C (USDA zone 6)[2][5]
                    TemperatureRangeMaximum = 30,
                    IsPoisonous = true, // All parts, especially bulbs, are toxic if eaten[5]
                    FertilizationMethod = "Apply a low-nitrogen, high-potassium fertilizer as shoots emerge in spring. Mulch in autumn to protect bulbs.",
                    Shape = "Upright, trumpet-shaped flowers on leafless stems; slender, strap-like leaves",
                    FullGrownHeight = 45, // Most daffodils reach 20–45 cm[2][7]
                    FullGrownWidth = 15,  // Each plant typically 10–15 cm wide[2]
                },

                // English Oak (Quercus robur)
                new Plant
                {
                    Id = 9,
                    LocalName = "Zomereik",
                    CommonName = "English Oak",
                    Family = "Fagaceae",
                    Genus = "Quercus",
                    Species = "robur",
                    Description = "A large, long-lived deciduous tree with a broad, spreading crown, deeply lobed leaves, and distinctive acorns. Known for its strong, durable wood and ecological value in supporting wildlife. Bark is greyish-brown and deeply fissured with age. Leaves are dark green above, paler below, with 3–7 rounded lobes per side and short petioles. Produces yellow catkins in spring and oval acorns on long stalks in autumn.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false, // Not edible for humans; acorns are consumed by wildlife
                    Color = "Green leaves (spring/summer), yellow/brown (autumn); greyish-brown bark; brown acorns",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Prune in winter to remove dead, diseased, or crossing branches. Minimal pruning required for mature trees.",
                    TrimmingPeriod = "Winter (dormant season)",
                    TemperatureRangeMinimum = -25,
                    TemperatureRangeMaximum = 35,
                    IsPoisonous = false, // Not considered poisonous, though acorns contain tannins and are not suitable for raw human consumption
                    FertilizationMethod = "Rarely needed; prefers deep, fertile, well-drained soils. Mulch young trees to retain moisture.",
                    Shape = "Broad, spreading crown with sturdy branches and a short, thick trunk",
                    FullGrownHeight = 4000, // Up to 40 meters (typically 20–40 m)
                    FullGrownWidth = 2500,  // Up to 25 meters (broad crown)
                },
                //Aardbei
                new Plant
                {
                    Id = 10, // Use a unique ID in your list
                    LocalName = "Aardbei",
                    CommonName = "Strawberry",
                    Family = "Rosaceae",
                    Genus = "Fragaria",
                    Species = "ananassa",
                    Description = "A low-growing, stoloniferous, herbaceous perennial plant known for its sweet, red, edible fruits. Leaves are trifoliate with toothed margins and hairy undersides. White, five-petaled flowers with yellow centers appear in spring. Fruits are aggregate accessory fruits, with each seed on the surface being a true fruit (achene). Plants spread via runners and are widely cultivated in gardens and farms worldwide.[1][2][3][4][5][6][7][8]",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Herb, // Low-growing herbaceous perennial[1][5][6]
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant[3]
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true, // Fruit is edible and widely consumed[1][3]
                    Color = "Green leaves; white flowers with yellow centers; red fruit[1][3][6]",
                    IsFlowering = true, // Yes, flowers in spring and early summer[1][6]
                    IsEvergreen = true, // Semi-evergreen in mild climates; may die back in cold climates[1][4][6]
                    TrimmingInstructions = "Remove old leaves and runners after fruiting to encourage new growth. Thin plants as needed to prevent overcrowding.",
                    TrimmingPeriod = "After fruiting (late summer to early autumn)[1][4]",
                    TemperatureRangeMinimum = -20, // Hardy to USDA zone 5, about -20°C[1][4]
                    TemperatureRangeMaximum = 30,  // Prefers cool to warm climates; protect from extreme heat[4]
                    IsPoisonous = false, // Not poisonous[1][3]
                    FertilizationMethod = "Apply balanced fertilizer in early spring and after the first harvest. Mulch to retain moisture and suppress weeds.[4]",
                    Shape = "Low, spreading mound with trifoliate leaves and runners forming new plants[1][5][6]",
                    FullGrownHeight = 30, // 6–30 cm (0.2–1 ft)[1][4]
                    FullGrownWidth = 60,  // 30–60 cm (1–2 ft) or more as plants spread by runners[1][4]
                },

                //Pampasgras
                new Plant
                {
                    Id = 11,
                    LocalName = "Pampasgras",
                    CommonName = "Pampas Grass",
                    Family = "Poaceae",
                    Genus = "Cortaderia",
                    Species = "selloana",
                    Description = "A large, perennial ornamental grass native to South America. Pampas grass forms impressive clumps of long, arching, bluish-green leaves with sharp edges. In late summer to autumn, it produces tall, feathery plumes that can be white, cream, or pink, rising well above the foliage. The plumes are popular in dried flower arrangements. Pampas grass is drought-tolerant, fast-growing, and can reach up to 3 meters tall. It prefers full sun and well-drained soil, and is often used as a specimen plant, screen, or windbreak in gardens.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Grass, // Ornamental grass
                    PlantClassification = PlantClassification.Angiosperms, // Flowering plant
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false, // Not edible
                    Color = "Bluish-green leaves; white, cream, or pink feathery flower plumes",
                    IsFlowering = true, // Yes, feathery plumes in late summer to autumn
                    IsEvergreen = false, // Semi-evergreen in mild climates, deciduous in colder regions
                    TrimmingInstructions = "Cut back old foliage and spent flower stems to about 30 cm above ground level in late winter or early spring before new growth begins. Wear gloves to protect from sharp leaf edges.",
                    TrimmingPeriod = "Late winter to early spring",
                    TemperatureRangeMinimum = -10, // Hardy to about -10°C (USDA zone 8), may need protection in colder climates
                    TemperatureRangeMaximum = 35,  // Tolerates heat and drought
                    IsPoisonous = false, // Not considered poisonous, but leaves can cause skin irritation
                    FertilizationMethod = "Apply a balanced fertilizer in spring to encourage strong growth. Avoid over-fertilizing.",
                    Shape = "Large, dense clump with long, arching leaves and tall, feathery plumes",
                    FullGrownHeight = 300, // Up to 3 meters (plumes included)
                    FullGrownWidth = 200,  // Clump can spread up to 2 meters wide
                },

                //Lampioengras
                new Plant
                {
                    Id = 12,
                    LocalName = "Lampioengras",
                    CommonName = "Lampenpoetsersgras",
                    Family = "Poaceae",
                    Genus = "Pennisetum",
                    Species = "alopecuroides",
                    Description = "Sierlijk, polvormend gras met smalle, overhangende bladeren en karakteristieke, borstelachtige bloeiaren die in de nazomer en herfst verschijnen. De aren zijn eerst geelroze, verkleuren naar roodbruin en blijven tot in de winter decoratief. De plant is onderhoudsvriendelijk, winterhard en vraagt weinig extra voeding. Ideaal als solitair of in groepen in de border. Groeit het beste op een zonnige plek in goed doorlatende grond.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Grass,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Groene bladeren die in de herfst geel tot bruin verkleuren; bloeiaren van geelroze naar diep roodbruin",
                    IsFlowering = true,
                    IsEvergreen = false, // Loopt in het voorjaar weer uit, blad sterft af in de winter[1][2][5][6]
                    TrimmingInstructions = "Snoei in het vroege voorjaar (maart/april) tot 10-20 cm boven de grond. Laat het dode blad en de aren in de winter staan voor bescherming en sierwaarde.",
                    TrimmingPeriod = "Vroeg voorjaar (maart/april)[4][5][6][8]",
                    TemperatureRangeMinimum = -20, // De meeste soorten zijn winterhard tot ca. -20°C[5][7]
                    TemperatureRangeMaximum = 35,
                    IsPoisonous = false,
                    FertilizationMethod = "Weinig extra voeding nodig. Eventueel in het voorjaar wat organische mest of speciale meststof voor siergrassen geven.[1][6]",
                    Shape = "Polvormend gras met overhangende bladeren en opstaande, borstelachtige bloeiaren",
                    FullGrownHeight = 120, // 60–120 cm, afhankelijk van de cultivar[1][5]
                    FullGrownWidth = 80,   // 50–80 cm breed[1][5]
                },

                //Cotoneaster
                new Plant
                {
                    Id = 12,
                    LocalName = "Cotoneaster",
                    CommonName = "Cotoneaster",
                    Family = "Rosaceae",
                    Genus = "Cotoneaster",
                    Species = "horizontalis", // or leave as "spp." for general
                    Description = "A low-growing, dense deciduous or semi-evergreen shrub with small, simple, waxy leaves. In late spring to early summer, it produces clusters of small pink or white flowers that attract pollinators. These are followed by showy red or orange berries in autumn and winter, which are popular with birds. The branches often form a distinctive herringbone or fishbone pattern. Foliage turns red, orange, or purple in fall, adding multi-season interest. Cotoneaster is widely used as groundcover, in rock gardens, or as a low hedge. Tolerant of drought, urban conditions, and a range of soils.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false, // Berries are not considered edible for humans
                    Color = "Glossy dark green leaves (spring/summer), red/orange/purple foliage (autumn), pink or white flowers, red/orange berries",
                    IsFlowering = true,
                    IsEvergreen = false, // Most species are deciduous or semi-evergreen; some are evergreen in mild climates[4][7][9]
                    TrimmingInstructions = "Prune in late winter or early spring before new growth. Shear or prune outer branch tips to shape and reduce size. Remove dead, diseased, or crossing branches. For hedges, trim regularly in summer to maintain shape and density.",
                    TrimmingPeriod = "Late winter to early spring for main pruning; light trimming in summer as needed[6][8][10]",
                    TemperatureRangeMinimum = -20, // Hardy to at least -20°C (USDA zone 5/6)[7]
                    TemperatureRangeMaximum = 35,
                    IsPoisonous = false, // Not considered poisonous, but berries are not for human consumption
                    FertilizationMethod = "Apply balanced, slow-release fertilizer in early spring if soil is poor. Young shrubs benefit from extra nutrients; established plants need little feeding.[8][10]",
                    Shape = "Dense, spreading shrub with arching or horizontal, herringbone-patterned branches",
                    FullGrownHeight = 80, // 50–80 cm for groundcover types like C. horizontalis, up to 200 cm for larger species[2][5][7]
                    FullGrownWidth = 200, // 100–200 cm or more as groundcover[2][5][7]
                },

                //Weigela
                new Plant
                {
                    Id = 13,
                    LocalName = "Weigela",
                    CommonName = "Weigela florida",
                    Family = "Caprifoliaceae",
                    Genus = "Weigela",
                    Species = "florida",
                    Description = "A popular, easy-to-grow deciduous shrub with arching branches and profuse clusters of tubular, five-lobed flowers in spring and early summer. Flowers are typically pink, red, or white, and attract hummingbirds and butterflies. Foliage is oblong, 2–6 cm long, with a slightly serrated edge, and may be green, gold, purple, or variegated depending on the cultivar. Used as a specimen, in borders, or as a flowering hedge. Tolerant of urban conditions and various soils, and virtually pest- and disease-free.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),

                    IsEatable = false, // Not edible
                    Color = "Green, gold, purple, or variegated leaves; pink, red, or white tubular flowers",
                    IsFlowering = true,
                    IsEvergreen = false, // Deciduous
                    TrimmingInstructions = "Prune immediately after flowering (late spring to early summer). Remove dead or old branches at the base to rejuvenate. Lightly shape as needed. For overgrown shrubs, remove up to one-third of the oldest stems in early spring.",
                    TrimmingPeriod = "Directly after flowering (late spring/early summer); rejuvenation pruning in early spring",
                    TemperatureRangeMinimum = -26, // Hardy to about -26°C (USDA zone 4)[7][10][12]
                    TemperatureRangeMaximum = 29,  // Thrives up to 29°C; tolerates summer heat if watered[7]
                    IsPoisonous = false, // Not considered toxic to pets or humans[2]
                    FertilizationMethod = "Apply a balanced, slow-release fertilizer in early spring. Mulch annually to conserve moisture and suppress weeds.",
                    Shape = "Arching, upright to mounding shrub, 1–2.5 m tall and wide, with abundant spring flowers",
                    FullGrownHeight = 250, // Up to 2.5 meters for mature shrubs[2][5]
                    FullGrownWidth = 250,  // Up to 2.5 meters wide[2][5]
                },

                //Hangende zegge
                new Plant
                {
                    Id = 14,
                    LocalName = "Hangende zegge",
                    CommonName = "Hangende zegge",
                    Family = "Cyperaceae",
                    Genus = "Carex",
                    Species = "pendula",
                    Description = "Wintergroen, sierlijk gras met lange, overhangende bloeiaren. Groeit in brede, dichte pollen en bereikt een hoogte van ca. 1 meter. De bladeren zijn donkergroen, lang, smal en ruw aan de rand. Bloeit in juni-juli met opvallende, hangende groene aren. Geschikt voor schaduwrijke tot halfschaduwrijke plekken, langs vijvers of in de border. Verdraagt temperaturen tot -25°C en is zeer onderhoudsvriendelijk. Kan zich sterk uitzaaien als uitgebloeide bloemen niet worden verwijderd.",
                    ImagePath = "path_to_picture.jpg",
                    PictureStringList = "path_to_picture.jpg",
                    PlantType = PlantType.Grass,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Donkergroene bladeren, groene hangende bloeiaren",
                    IsFlowering = true,
                    IsEvergreen = true, // Blijft de hele winter groen[1][4][5]
                    TrimmingInstructions = "Verwijder in het vroege voorjaar lelijke of beschadigde bladeren en knip uitgebloeide bloemen af om uitzaaiing te beperken. Laat gezonde bladeren zoveel mogelijk intact.",
                    TrimmingPeriod = "Vroeg voorjaar (maart/april)[6][8][10]",
                    TemperatureRangeMinimum = -25, // Verdraagt tot -25°C[1][4][5]
                    TemperatureRangeMaximum = 30,
                    IsPoisonous = false,
                    FertilizationMethod = "Geef in het voorjaar een lichte gift organische mest of speciale siergrasbemesting, direct na het snoeien.",
                    Shape = "Brede, dichte pol met lange, overhangende bladeren en bloeiaren",
                    FullGrownHeight = 100, // tot 100 cm hoog[1][4][5]
                    FullGrownWidth = 80,   // tot ca. 80 cm breed, kan zich uitbreiden[7][9]
                },

                // Ficus lyrata (Fiddle Leaf Fig)
                new Plant
                {
                    Id = 15,
                    LocalName = "Ficus lyrata",
                    CommonName = "Fiddle Leaf Fig",
                    Family = "Moraceae",
                    Genus = "Ficus",
                    Species = "lyrata",
                    Description = "A popular indoor tree with large, violin-shaped leaves. Native to western Africa, it thrives in bright, indirect light and can grow several meters tall indoors.",
                    ImagePath = "ficus_lyrata.jpg",
                    PictureStringList = "ficus_lyrata.jpg",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    TrimmingInstructions = "Prune to shape and remove damaged leaves.",
                    TrimmingPeriod = "Spring or early summer",
                    TemperatureRangeMinimum = 16,
                    TemperatureRangeMaximum = 24,
                    IsPoisonous = true,
                    FertilizationMethod = "Balanced liquid fertilizer during growing season.",
                    Shape = "Upright, tree-like",
                    FullGrownHeight = 300,
                    FullGrownWidth = 100
                },

                // Howea forsteriana (Kentia Palm)
                new Plant
                {
                    Id = 16,
                    LocalName = "Howea forsteriana",
                    CommonName = "Kentia Palm",
                    Family = "Arecaceae",
                    Genus = "Howea",
                    Species = "forsteriana",
                    Description = "Elegant, slow-growing palm native to Lord Howe Island. Well-suited for indoor environments, with arching fronds and a graceful appearance.",
                    ImagePath = "howea_forsteriana.jpg",
                    PictureStringList = "howea_forsteriana.jpg",
                    PlantType = PlantType.Palm,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    TrimmingInstructions = "Remove old or yellowing fronds at the base.",
                    TrimmingPeriod = "As needed, year-round",
                    TemperatureRangeMinimum = 10,
                    TemperatureRangeMaximum = 27,
                    IsPoisonous = false,
                    FertilizationMethod = "Palm fertilizer during growing season.",
                    Shape = "Graceful, arching fronds",
                    FullGrownHeight = 200,
                    FullGrownWidth = 150
                },

                // Dracaena fragrans (Corn Plant)
                new Plant
                {
                    Id = 17,
                    LocalName = "Dracaena fragrans",
                    CommonName = "Corn Plant",
                    Family = "Asparagaceae",
                    Genus = "Dracaena",
                    Species = "fragrans",
                    Description = "A popular houseplant with broad, arching leaves and a thick stem. Known for its tolerance of low light and air-purifying qualities.",
                    ImagePath = "dracaena_fragrans.jpg",
                    PictureStringList = "dracaena_fragrans.jpg",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Green (leaves), sometimes variegated",
                    IsFlowering = true,
                    IsEvergreen = true,
                    TrimmingInstructions = "Trim brown tips and remove old leaves.",
                    TrimmingPeriod = "As needed",
                    TemperatureRangeMinimum = 15,
                    TemperatureRangeMaximum = 25,
                    IsPoisonous = true,
                    FertilizationMethod = "General-purpose houseplant fertilizer monthly.",
                    Shape = "Upright, cane-like",
                    FullGrownHeight = 200,
                    FullGrownWidth = 80
                },

                // Lonicera nitida 'Maigrün' (Box Honeysuckle)
                new Plant
                {
                    Id = 18,
                    LocalName = "Lonicera nitida 'Maigrün'",
                    CommonName = "Box Honeysuckle",
                    Family = "Caprifoliaceae",
                    Genus = "Lonicera",
                    Species = "nitida",
                    Description = "Dense, evergreen shrub with small, glossy green leaves. Commonly used for low hedges and topiary. Fast-growing and easy to shape.",
                    ImagePath = "lonicera_nitida_maigruen.jpg",
                    PictureStringList = "lonicera_nitida_maigruen.jpg",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    TrimmingInstructions = "Trim regularly to maintain shape.",
                    TrimmingPeriod = "Spring and summer",
                    TemperatureRangeMinimum = -15,
                    TemperatureRangeMaximum = 30,
                    IsPoisonous = false,
                    FertilizationMethod = "Light fertilizer in spring.",
                    Shape = "Dense, bushy",
                    FullGrownHeight = 150,
                    FullGrownWidth = 120
                },

                // Nepeta cataria (Kattekruid, Catnip)
                new Plant
                {
                    Id = 19,
                    LocalName = "Kattekruid",
                    CommonName = "Catnip",
                    Family = "Lamiaceae",
                    Genus = "Nepeta",
                    Species = "cataria",
                    Description = "Aromatic perennial herb known for its effect on cats. Grey-green leaves and small white to lavender flowers.",
                    ImagePath = "kattekruid.jpg",
                    PictureStringList = "kattekruid.jpg",
                    PlantType = PlantType.Herb,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = true,
                    Color = "Green (leaves), White/Lavender (flowers)",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Cut back after flowering to promote bushiness.",
                    TrimmingPeriod = "Late summer",
                    TemperatureRangeMinimum = -30,
                    TemperatureRangeMaximum = 35,
                    IsPoisonous = false,
                    FertilizationMethod = "Minimal; compost in spring.",
                    Shape = "Upright, bushy herb",
                    FullGrownHeight = 90,
                    FullGrownWidth = 60
                },

                // Lavandula angustifolia (Lavender)
                new Plant
                {
                    Id = 20,
                    LocalName = "Lavendel",
                    CommonName = "Lavender",
                    Family = "Lamiaceae",
                    Genus = "Lavandula",
                    Species = "angustifolia",
                    Description = "Fragrant, evergreen shrub with narrow leaves and spikes of purple flowers. Popular for its scent and use in gardens and dried arrangements.",
                    ImagePath = "lavender.jpg",
                    PictureStringList = "lavender.jpg",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = true,
                    Color = "Purple (flowers), Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    TrimmingInstructions = "Prune lightly after flowering.",
                    TrimmingPeriod = "Late summer or early fall",
                    TemperatureRangeMinimum = -15,
                    TemperatureRangeMaximum = 30,
                    IsPoisonous = false,
                    FertilizationMethod = "Low-nutrient soil; avoid over-fertilizing.",
                    Shape = "Compact, bushy",
                    FullGrownHeight = 60,
                    FullGrownWidth = 80
                },

                // Paeonia lactiflora (Peony, Pioenroos)
                new Plant
                {
                    Id = 21,
                    LocalName = "Pioenroos",
                    CommonName = "Peony",
                    Family = "Paeoniaceae",
                    Genus = "Paeonia",
                    Species = "lactiflora",
                    Description = "Herbaceous perennial with large, fragrant flowers in late spring to early summer. Flowers come in shades of pink, white, and red.",
                    ImagePath = "pioenroos.jpg",
                    PictureStringList = "pioenroos.jpg",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Pink, White, Red (flowers), Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Remove spent flowers and cut back in autumn.",
                    TrimmingPeriod = "After flowering and in autumn",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 30,
                    IsPoisonous = false,
                    FertilizationMethod = "Compost in spring.",
                    Shape = "Bushy, upright",
                    FullGrownHeight = 100,
                    FullGrownWidth = 90
                },

                // Papaver nudicaule (Iceland Poppy, Gele Papaver)
                new Plant
                {
                    Id = 22,
                    LocalName = "Gele Papaver",
                    CommonName = "Iceland Poppy",
                    Family = "Papaveraceae",
                    Genus = "Papaver",
                    Species = "nudicaule",
                    Description = "Perennial poppy with delicate, papery yellow flowers. Blooms in late spring and early summer. Prefers cool climates.",
                    ImagePath = "gele_papaver.jpg",
                    PictureStringList = "gele_papaver.jpg",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Yellow (flowers), Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = false,
                    TrimmingInstructions = "Remove spent flowers to prolong blooming.",
                    TrimmingPeriod = "During flowering season",
                    TemperatureRangeMinimum = -40,
                    TemperatureRangeMaximum = 25,
                    IsPoisonous = true,
                    FertilizationMethod = "Light fertilizer in spring.",
                    Shape = "Clumping, upright",
                    FullGrownHeight = 50,
                    FullGrownWidth = 30
                },


            };
        }

        /// <summary>
        /// If GetPhylumByName is not static/global, you may need to adjust this:
        /// </summary>
        /// <param name="phyla"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static object GetPhylumByName(IEnumerable<Phylum> phyla, string name)
        {
            // Implement or call your actual phylum lookup logic here
            //loop phyla
            return phyla.FirstOrDefault(p => p.Name == name);

        }

    }



}
