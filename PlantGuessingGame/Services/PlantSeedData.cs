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
        /// disk location
        /// </summary>
        private const string diskLocationImages = "C:\\PlantLibraryImageSeed\\";

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
                    ImagePath = diskLocationImages + "HeavenlyBamboo_Nandina_domestica_Base01.png",
                    // PictureStringList REMOVED
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Purple (spring/winter), Green (summer), Red (autumn), White (flowers), Red (berries)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = true,
                    Shape = "Upright, bushy shrub with bamboo-like appearance",
                    FullGrownHeight = 200,
                    FullGrownWidth = 150,
                    // New plant care properties:
                    Light = "Full sun to partial shade",
                    Water = "Moderate; prefers moist, well-drained soil but is drought tolerant once established",
                    Soil = "Well-drained, fertile soil; tolerates a wide range but prefers slightly acidic conditions",
                    FertilizationMethod = "General-purpose fertilizer in spring. Not heavy feeders; avoid over-fertilization.",
                    TrimmingInstructions = "Thin out old stems to maintain density and shape. Remove dead or damaged wood.",
                    TrimmingPeriod = "Late winter to early spring, after risk of frost",
                    TemperatureRangeMinimum = -18,
                    TemperatureRangeMaximum = 35
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
                    ImagePath = diskLocationImages + "Haagbeuk_Carpinus_betulus_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum) GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green (spring/summer), Yellow-Orange (autumn)",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Upright tree with dense, oval to pyramidal crown. Can be pruned into hedges.",
                    FullGrownHeight = 2000,
                    FullGrownWidth = 1500,
                    // New plant care properties:
                    Light = "Full sun to partial shade", // Prefers plenty of sunlight, but tolerates some shade[1][4][7]
                    Water = "Regular watering, especially during dry periods; keep soil moist but not waterlogged", // Needs moist but well-drained soil, especially when young[1][4][5][7]
                    Soil = "Well-drained, humus-rich, slightly acidic to neutral soil; tolerates a range but prefers fertile conditions", // Prefers humus-rich, well-drained soil[1][4][7]
                    FertilizationMethod = "Apply balanced or organic fertilizer in early spring if soil is poor. Compost or horn shavings are suitable; generally low maintenance.", // Organic fertilizer in spring if needed[1][5][7]
                    TrimmingInstructions = "Trim to shape in late summer if used as a hedge. Remove dead or diseased wood as needed.",
                    TrimmingPeriod = "Late summer for hedging; winter for structural pruning",
                    TemperatureRangeMinimum = -30,
                    TemperatureRangeMaximum = 35
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
                    Description = "A classic hedge and woodland tree with smooth, silvery-gray bark and glossy, wavy-edged leaves. In spring and summer, leaves are bright to deep green; in autumn, they turn copper, rust, or gold, and in hedges, the dead leaves often persist through winter, providing year-round screening. Beech is shade-tolerant, easy to grow, and responds well to pruning. It is cold-hardy, deer-resistant, and thrives in a range of soils, but prefers well-drained conditions. Flowers appear in April–May, followed by beech nuts in autumn. Left unpruned, it can reach 20–30 meters tall and 10–20 meters wide, but is usually kept much smaller as a hedge.",
                    ImagePath = diskLocationImages + "Beukenhaag_Fagus_sylvatica_Base01.png",
                    PlantType = PlantType.Shrub, // Used as a hedge, typically maintained as a shrub
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Bright green (spring), deep green (summer), copper/rust/gold (autumn), brown (winter leaves on hedge)",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Dense, upright hedge with smooth, graceful branches and wavy-edged leaves. Left unpruned, forms a large, majestic tree with a broad crown.",
                    FullGrownHeight = 750, // Up to 7.5 meters as a hedge
                    FullGrownWidth = 200,  // Typically maintained at 0.5–2 meters as a hedge

                    // New plant care properties:
                    Light = "Full sun to partial shade", // Prefers at least 6 hours of sun, but tolerates some shade[1][2][7]
                    Water = "Keep soil evenly moist, especially when young or during dry spells. Water deeply once a week in dry weather; avoid waterlogged conditions.", // Likes evenly moist, well-drained soil, intolerant of drought and waterlogging[2][5][6][7]
                    Soil = "Rich, loose, loamy, well-drained soil; slightly acidic to neutral pH. Avoid waterlogged or compacted soils.", // Prefers well-drained, humus-rich soil, slightly acidic to neutral[1][2][5][7]
                    FertilizationMethod = "Apply balanced fertilizer in early spring if soil is poor. Mulch in autumn to protect roots and retain moisture.",
                    TrimmingInstructions = "Trim established hedges in mid-August to maintain size and density. For new hedges, light formative pruning in winter. Avoid pruning between March and July due to bird nesting. Overgrown hedges can be hard-pruned in late winter, staggering cuts over 2–3 years if necessary.",
                    TrimmingPeriod = "Main trim in mid-August; formative pruning in winter for young hedges; hard pruning in late winter if needed.",
                    TemperatureRangeMinimum = -23, // Hardy to at least -23°C
                    TemperatureRangeMaximum = 35   // Tolerates summer heat, prefers moderate climates
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
                    ImagePath = diskLocationImages + "HydrangeaMacrophylla_Hydrangea_macrophylla_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Pink, blue, purple, red, or white flowers (color depends on soil pH); dark green leaves",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = true,
                    Shape = "Rounded, bushy shrub with large, globular or flattened flower clusters",
                    FullGrownHeight = 200,
                    FullGrownWidth = 250,
                    // New plant care properties:
                    Light = "Partial shade; morning sun with afternoon shade is ideal", // Hydrangeas prefer dappled or partial shade[1][5]
                    Water = "Keep soil consistently moist but not soggy; water deeply during dry spells", // Needs regular watering, especially in summer[5]
                    Soil = "Rich, well-drained, moisture-retentive soil; pH affects flower color (acidic for blue, alkaline for pink)", // Prefers rich, well-drained soil; pH affects color[1][5]
                    FertilizationMethod = "Apply balanced, slow-release fertilizer in spring. Acidic fertilizer for blue flowers, lime for pink.",
                    TrimmingInstructions = "Prune after flowering by removing spent blooms and weak stems. Avoid heavy pruning, as flower buds form on old wood for most cultivars.",
                    TrimmingPeriod = "Late summer to early autumn, after flowering",
                    TemperatureRangeMinimum = -23,
                    TemperatureRangeMaximum = 35
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
                    ImagePath = diskLocationImages + "Plataan_Platanus_hispanica_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green leaves (spring/summer), yellow-brown (autumn), mottled cream/green/grey bark",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Broad, spreading crown with strong, upright branches",
                    FullGrownHeight = 3000,
                    FullGrownWidth = 2000,
                    // New plant care properties:
                    Light = "Full sun (at least 6 hours per day); tolerates partial shade but grows best in full sun", // [1][3][4][7]
                    Water = "Moderate; water deeply during dry periods, especially when young. Prefers consistently moist but well-drained soil. Once established, somewhat drought tolerant.", // [1][5][6][7]
                    Soil = "Well-drained, fertile, loamy soil; tolerates a wide range including sandy and clay soils. pH 6.0–7.5 preferred.", // [3][4][5][7]
                    FertilizationMethod = "Generally not required in urban soils. If soil is poor, apply a balanced tree fertilizer in early spring. Mulch and water young trees.", // [1][5][7]
                    TrimmingInstructions = "Prune in late winter to early spring to remove dead or crossing branches. Can be pollarded to control size.",
                    TrimmingPeriod = "Late winter to early spring",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 40
                }
,
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
                    ImagePath = diskLocationImages + "Malus_domestica_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true,
                    Color = "Green leaves (spring/summer), yellow/red/orange (autumn); white or pink flowers; fruit varies in color: red, green, yellow",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Rounded, spreading crown with dense branching",
                    FullGrownHeight = 900,
                    FullGrownWidth = 900,
                    // New plant care properties:
                    Light = "Full sun (at least 6 hours per day); tolerates dappled shade but fruits best in sun", // [1][2][3][5][7]
                    Water = "Keep soil evenly moist, especially during establishment and dry spells; avoid waterlogging", // [1][3][5][7]
                    Soil = "Fertile, well-drained loamy soil, rich in organic matter; pH 6.0–7.0; tolerates clay if not waterlogged", // [1][3][4][5][6][7]
                    FertilizationMethod = "Apply balanced fertilizer in early spring if soil is poor. Mulch annually to retain moisture and provide nutrients.",
                    TrimmingInstructions = "Prune in late winter to early spring to maintain shape, remove dead or diseased wood, and encourage productive branches. Young trees require formative pruning for strong structure.",
                    TrimmingPeriod = "Late winter to early spring",
                    TemperatureRangeMinimum = -30,
                    TemperatureRangeMaximum = 35
                }
,
            // Alder (Alnus glutinosa)
                new Plant
                {
                    Id = 6,
                    LocalName = "Els",
                    CommonName = "Alder",
                    Family = "Betulaceae",
                    Genus = "Alnus",
                    Species = "glutinosa",
                    Description = "A medium-sized, fast-growing deciduous tree that thrives in wet soils, often along rivers and ponds. Recognizable by its dark, fissured bark, rounded glossy green leaves, and woody, cone-like fruits. Catkins appear in early spring, providing an important pollen source for insects. Native to Europe and western Asia. The tree can reach 20–30 meters tall with a pyramidal to oval crown and is valued for its nitrogen-fixing roots and ecological importance in wet habitats.",
                    ImagePath = diskLocationImages + "ZwarteEls_Alnus_glutinosa_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green leaves (spring/summer), yellow (autumn); dark brown to black bark; brown catkins and cones",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Pyramidal to oval crown, often with multiple stems; can form dense thickets in wet areas",
                    FullGrownHeight = 3000,
                    FullGrownWidth = 1000,
                    // New plant care properties:
                    Light = "Full sun; thrives best with at least 6–8 hours of direct sunlight per day", // [2][4][5]
                    Water = "Keep soil consistently moist, especially when young. Thrives in wet or waterlogged soils but tolerates periodic dryness once established", // [1][3][4][5][8]
                    Soil = "Moist, loamy, well-drained to poorly drained soil; tolerates a range but prefers slightly acidic to neutral pH", // [4][5][7][8]
                    FertilizationMethod = "Rarely needed due to nitrogen-fixing roots. Mulch young trees to retain moisture. If soil is very poor, a balanced fertilizer can be applied sparingly.", // [4][5][7]
                    TrimmingInstructions = "Prune in late autumn or winter to remove dead or crossing branches. Minimal pruning required unless shaping or removing damaged wood.",
                    TrimmingPeriod = "Late autumn to winter",
                    TemperatureRangeMinimum = -25,
                    TemperatureRangeMaximum = 35
                }
,
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
                    ImagePath = diskLocationImages + "Tulp_Tulipa_sp_Base01.png",
                    PlantType = PlantType.Bulb,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Wide range: red, yellow, pink, purple, orange, white, and multicolored",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = true,
                    Shape = "Upright, cup-shaped flowers on single, unbranched stems; lance-shaped leaves",
                    FullGrownHeight = 60,  // Most garden tulips reach 20–60 cm
                    FullGrownWidth = 15,   // Each plant typically 10–15 cm wide
                    // New plant care properties:
                    Light = "Full sun (at least 6 hours per day); tolerates partial shade but best flowering in sun", // [1][2][3][8]
                    Water = "Moderate watering; keep soil moist during growth, but allow it to dry between waterings. Avoid waterlogging, especially during dormancy", // [2][5][8]
                    Soil = "Fertile, well-drained, sandy or loamy soil; pH 6.0–6.5 preferred. Good drainage is essential to prevent bulb rot", // [1][2][4][5][8]
                    FertilizationMethod = "Apply a balanced bulb fertilizer at planting and again as shoots emerge in spring.",
                    TrimmingInstructions = "Remove spent flowers after blooming to prevent seed formation. Allow leaves to die back naturally to feed the bulb.",
                    TrimmingPeriod = "Deadhead after flowering; remove foliage only once it has yellowed and died back (late spring to early summer)",
                    TemperatureRangeMinimum = -25,
                    TemperatureRangeMaximum = 30
                }
,
                // Narcis (Narcissus pseudonarcissus)
                new Plant
                {
                    Id = 8,
                    LocalName = "Narcis",
                    CommonName = "Daffodil",
                    Family = "Amaryllidaceae",
                    Genus = "Narcissus",
                    Species = "pseudonarcissus",
                    Description = "A spring-flowering perennial bulb known for its trumpet-shaped flowers, typically yellow or white, sometimes with orange or pink centers. Leaves are long, slender, and bluish-green. Each stem usually bears a single fragrant flower with a darker yellow trumpet surrounded by paler yellow tepals. Native to Europe, daffodils are widely grown in gardens and naturalized in meadows and woodlands. Bulbs are planted in autumn for a cheerful spring display. All parts of the plant are poisonous if ingested.",
                    ImagePath = diskLocationImages + "Narcis_Narcissus_sp_Base01.png",
                    PlantType = PlantType.Bulb,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Yellow, white, orange, or bicolored flowers; bluish-green leaves",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = true,
                    Shape = "Upright, trumpet-shaped flowers on leafless stems; slender, strap-like leaves",
                    FullGrownHeight = 45,
                    FullGrownWidth = 15,
                    // New plant care properties:
                    Light = "Full sun to partial shade; best flowering in sun but tolerates some shade", // [1][5][7]
                    Water = "Moderate; keep soil moist during growth and flowering, but allow to dry out after foliage dies back. Avoid waterlogging.", // [1][3][4][5][7]
                    Soil = "Well-drained, loamy or sandy soil; moderately fertile, humus-rich, slightly acidic to neutral pH (6.0–7.0)", // [1][3][5][7]
                    FertilizationMethod = "Apply a low-nitrogen, high-potassium fertilizer as shoots emerge in spring. Mulch in autumn to protect bulbs.", // [5][6][7]
                    TrimmingInstructions = "Remove spent flowers after blooming to prevent seed formation. Allow leaves to die back naturally to feed the bulb.",
                    TrimmingPeriod = "Deadhead after flowering; remove foliage only once it has yellowed and died back (late spring)",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 30
                }
,
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
                    ImagePath = diskLocationImages + "Zomereik_Quercus_robur_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green leaves (spring/summer), yellow/brown (autumn); greyish-brown bark; brown acorns",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Broad, spreading crown with sturdy branches and a short, thick trunk",
                    FullGrownHeight = 4000,
                    FullGrownWidth = 2500,
                    // New plant care properties:
                    Light = "Full sun; tolerates some dappled shade but grows best in open, sunny locations", // [1][3][5]
                    Water = "Average; prefers moist, well-drained soil but is highly drought-tolerant once established", // [1][3][4][5]
                    Soil = "Chalk, clay, loam, or sand; moist but well-drained or well-drained; pH acid, alkaline, or neutral. Adaptable but thrives in deep, fertile, organic-rich soils", // [1][3][4][5]
                    FertilizationMethod = "Rarely needed; mulch young trees with compost in spring. If soil is poor, apply a balanced fertilizer in early spring, but avoid over-fertilizing.", // [5][8]
                    TrimmingInstructions = "Prune in winter to remove dead, diseased, or crossing branches. Minimal pruning required for mature trees.",
                    TrimmingPeriod = "Winter (dormant season)",
                    TemperatureRangeMinimum = -25,
                    TemperatureRangeMaximum = 35
                }
,
                //Aardbei
                new Plant
                {
                    Id = 10,
                    LocalName = "Aardbei",
                    CommonName = "Strawberry",
                    Family = "Rosaceae",
                    Genus = "Fragaria",
                    Species = "ananassa",
                    Description = "A low-growing, stoloniferous, herbaceous perennial plant known for its sweet, red, edible fruits. Leaves are trifoliate with toothed margins and hairy undersides. White, five-petaled flowers with yellow centers appear in spring. Fruits are aggregate accessory fruits, with each seed on the surface being a true fruit (achene). Plants spread via runners and are widely cultivated in gardens and farms worldwide.",
                    ImagePath = diskLocationImages + "Aardbei_Fragaria_ananassa_Base01.png",
                    PlantType = PlantType.Herb,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true,
                    Color = "Green leaves; white flowers with yellow centers; red fruit",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Low, spreading mound with trifoliate leaves and runners forming new plants",
                    FullGrownHeight = 30,
                    FullGrownWidth = 60,
                    // New plant care properties:
                    Light = "Full sun (6–10 hours of direct sunlight daily) for optimal fruiting", // [1][2][5][6][8]
                    Water = "Keep soil consistently and evenly moist, especially during flowering and fruiting; avoid waterlogging", // [1][5][6][8]
                    Soil = "Fertile, well-drained, friable loamy soil rich in organic matter; slightly acidic to neutral (pH 5.5–7.0)", // [1][3][4][5][6]
                    FertilizationMethod = "Apply balanced fertilizer in early spring and after the first harvest. Mulch to retain moisture and suppress weeds.",
                    TrimmingInstructions = "Remove old leaves and runners after fruiting to encourage new growth. Thin plants as needed to prevent overcrowding.",
                    TrimmingPeriod = "After fruiting (late summer to early autumn)",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 30
                }
,
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
                    ImagePath = diskLocationImages + "Pampasgras_Cortaderia_selloana_Base01.png",
                    PlantType = PlantType.Grass,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Bluish-green leaves; white, cream, or pink feathery flower plumes",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Large, dense clump with long, arching leaves and tall, feathery plumes",
                    FullGrownHeight = 300, // Up to 3 meters (plumes included)
                    FullGrownWidth = 200,  // Clump can spread up to 2 meters wide
                    // New plant care properties:
                    Light = "Full sun is best; tolerates light shade but flowers most in sun", // [1][2][3][5][6][8]
                    Water = "Water deeply after planting and during the first growing season; once established, drought-tolerant and usually only needs water in prolonged dry spells", // [2][4][5]
                    Soil = "Fertile, well-drained, sandy or loamy soil; tolerates a range of pH and soil types as long as drainage is good", // [1][2][3][4][5][6][8]
                    FertilizationMethod = "Apply a balanced fertilizer in spring to encourage strong growth. Avoid over-fertilizing.", // [4][5]
                    TrimmingInstructions = "Cut back old foliage and spent flower stems to about 30 cm above ground level in late winter or early spring before new growth begins. Wear gloves to protect from sharp leaf edges.",
                    TrimmingPeriod = "Late winter to early spring",
                    TemperatureRangeMinimum = -10,
                    TemperatureRangeMaximum = 35
                }
,
                //Lampioengras
                // Fountain Grass
                new Plant
                {
                    Id = 12,
                    LocalName = "Fountain Grass",
                    CommonName = "Fountain Grass",
                    Family = "Poaceae",
                    Genus = "Pennisetum",
                    Species = "alopecuroides",
                    Description = "Elegant, clump-forming grass with narrow, arching leaves and characteristic, brush-like flower spikes that appear in late summer and autumn. The spikes start out yellow-pink, turn reddish-brown, and remain decorative into winter. The plant is low-maintenance, hardy, and requires little extra feeding. Ideal as a solitary plant or in groups in borders. Grows best in a sunny location with well-drained soil.",
                    ImagePath = diskLocationImages + "Lampenpoetsersgras_Pennisetum_alopecuroides_Base01.png",
                    PlantType = PlantType.Grass,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green leaves that turn yellow to brown in autumn; flower spikes change from yellow-pink to deep reddish-brown",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Clump-forming grass with arching leaves and upright, brush-like flower spikes",
                    FullGrownHeight = 120,
                    FullGrownWidth = 80,
                    // New plant care properties:
                    Light = "Full sun to light shade; best flowering in full sun", // [1][5][7]
                    Water = "Regular watering during establishment; keep soil consistently moist but not soggy. Once established, drought tolerant but benefits from watering in dry spells", // [2][3][4][5][7]
                    Soil = "Well-drained, fertile, loamy or sandy soil; tolerates clay if drainage is good. Slightly acidic to neutral pH preferred", // [1][2][3][4][5][7]
                    FertilizationMethod = "Requires little additional feeding. Optionally apply organic fertilizer or special ornamental grass fertilizer in spring.", // [2][5][8]
                    TrimmingInstructions = "Prune in early spring (March/April) to 10–20 cm above the ground. Leave the dead foliage and spikes during winter for protection and ornamental value.",
                    TrimmingPeriod = "Early spring (March/April)",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 35
                }
,
                //Cotoneaster
               new Plant
                {
                    Id = 12,
                    LocalName = "Cotoneaster",
                    CommonName = "Cotoneaster",
                    Family = "Rosaceae",
                    Genus = "Cotoneaster",
                    Species = "horizontalis",
                    Description = "A low-growing, dense deciduous or semi-evergreen shrub with small, simple, waxy leaves. In late spring to early summer, it produces clusters of small pink or white flowers that attract pollinators. These are followed by showy red or orange berries in autumn and winter, which are popular with birds. The branches often form a distinctive herringbone or fishbone pattern. Foliage turns red, orange, or purple in fall, adding multi-season interest. Cotoneaster is widely used as groundcover, in rock gardens, or as a low hedge. Tolerant of drought, urban conditions, and a range of soils.",
                    ImagePath = diskLocationImages + "Cotoneaster_Cotoneaster_sp_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Glossy dark green leaves (spring/summer), red/orange/purple foliage (autumn), pink or white flowers, red/orange berries",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Dense, spreading shrub with arching or horizontal, herringbone-patterned branches",
                    FullGrownHeight = 80,
                    FullGrownWidth = 200,
                    // New plant care properties:
                    Light = "Full sun to partial shade; best berry and foliage color in full sun", // [1][2][3][5][7]
                    Water = "Water regularly during the first year to establish roots. Once established, drought tolerant but prefers consistent soil moisture. Avoid waterlogging.", // [1][2][3][5][7]
                    Soil = "Moist but well-drained soil; tolerates a wide range including clay, loam, and sandy soils. pH neutral to slightly alkaline. Improve heavy soils with compost.", // [1][2][3][5][7]
                    FertilizationMethod = "Apply balanced, slow-release fertilizer in early spring if soil is poor. Young shrubs benefit from extra nutrients; established plants need little feeding.", // [3][5]
                    TrimmingInstructions = "Prune in late winter or early spring before new growth. Shear or prune outer branch tips to shape and reduce size. Remove dead, diseased, or crossing branches. For hedges, trim regularly in summer to maintain shape and density.",
                    TrimmingPeriod = "Late winter to early spring for main pruning; light trimming in summer as needed",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 35
                }
,
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
                    ImagePath = diskLocationImages + "WeigelaFlorida_Weigela_florida_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green, gold, purple, or variegated leaves; pink, red, or white tubular flowers",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Arching, upright to mounding shrub, 1–2.5 m tall and wide, with abundant spring flowers",
                    FullGrownHeight = 250,
                    FullGrownWidth = 250,
                    // New plant care properties:
                    Light = "Full sun to partial shade; best flowering and foliage color in full sun", // [2][3][4][5][7][8]
                    Water = "Water regularly during establishment; once established, moderately drought tolerant but benefits from deep watering during dry spells", // [4][5][6][7]
                    Soil = "Moist, well-drained, moderately fertile soil; tolerates a wide range but avoid waterlogged or very dry sites. pH 5.5–7.5", // [2][3][5][7][8]
                    FertilizationMethod = "Apply a balanced, slow-release fertilizer in early spring. Mulch annually to conserve moisture and suppress weeds.", // [2][5][6]
                    TrimmingInstructions = "Prune immediately after flowering (late spring to early summer). Remove dead or old branches at the base to rejuvenate. Lightly shape as needed. For overgrown shrubs, remove up to one-third of the oldest stems in early spring.",
                    TrimmingPeriod = "Directly after flowering (late spring/early summer); rejuvenation pruning in early spring",
                    TemperatureRangeMinimum = -26,
                    TemperatureRangeMaximum = 29
                }
,
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
                    ImagePath = diskLocationImages + "HangendeZegge_Carex_pendula_Base01.png",
                    PlantType = PlantType.Grass,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Donkergroene bladeren, groene hangende bloeiaren",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Brede, dichte pol met lange, overhangende bladeren en bloeiaren",
                    FullGrownHeight = 100,
                    FullGrownWidth = 80,
                    // New plant care properties:
                    Light = "Indirect bright light to partial shade; tolerates full sun if soil is moist, but prefers shade in hotter climates", //[1][3][4][5][6][7],
                    Water = "Keep soil consistently moist; thrives in moist to wet soil, especially during dry periods. Avoid prolonged drought",// [1][3][4][5][6][7],
                    Soil = "Fertile, loamy, moist or wet soil; well-drained but moisture-retentive; tolerates clay and organic-rich soils",//[1][3][4][5][6][7],
                    FertilizationMethod = "Apply a balanced fertilizer (e.g., 10-10-10 NPK) in spring. Avoid over-fertilizing; organic matter or compost can be added annually", //[1],
                    TrimmingInstructions = "Verwijder in het vroege voorjaar lelijke of beschadigde bladeren en knip uitgebloeide bloemen af om uitzaaiing te beperken. Laat gezonde bladeren zoveel mogelijk intact.",
                    TrimmingPeriod = "Vroeg voorjaar (maart/april)",
                    TemperatureRangeMinimum = -25,
                    TemperatureRangeMaximum = 30
                }
,
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
                    ImagePath = diskLocationImages + "Vioolbladplant_Ficus_lyrata_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = true,
                    Shape = "Upright, tree-like",
                    FullGrownHeight = 300,
                    FullGrownWidth = 100,
                    // New plant care properties:
                    Light = "Bright, indirect light; can tolerate some direct morning sun but avoid harsh afternoon sun",
                    Water = "Water when the top 2–3 cm of soil is dry; keep soil moderately moist but never soggy. Reduce watering in winter",
                    Soil = "Well-draining, peat-based indoor potting mix with added perlite or sand for aeration",
                    FertilizationMethod = "Balanced liquid fertilizer every 4 weeks during the growing season (spring to early autumn)",
                    TrimmingInstructions = "Prune to shape and remove damaged leaves.",
                    TrimmingPeriod = "Spring or early summer",
                    TemperatureRangeMinimum = 16,
                    TemperatureRangeMaximum = 24
                }
,
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
                    ImagePath = diskLocationImages + "KentiaPalm_Howea_forsteriana_Base01.png",
                    PlantType = PlantType.Palm,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Graceful, arching fronds",
                    FullGrownHeight = 200,
                    FullGrownWidth = 150,
                    // New plant care properties:
                    Light = "Bright, indirect light; tolerates lower light but avoid direct sun",
                    Water = "Water when the top 2–3 cm of soil is dry; keep soil lightly moist but never soggy. Reduce watering in winter",
                    Soil = "Well-draining, peat-based potting mix with added perlite or sand; avoid waterlogged soil",
                    FertilizationMethod = "Palm fertilizer or balanced liquid fertilizer every 2–4 weeks during spring and summer; do not fertilize in winter",
                    TrimmingInstructions = "Remove old or yellowing fronds at the base.",
                    TrimmingPeriod = "As needed, year-round",
                    TemperatureRangeMinimum = 10,
                    TemperatureRangeMaximum = 27
                }
,
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
                    ImagePath = diskLocationImages + "Drakenbloedboom_Dracaena_fragrans_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Green (leaves), sometimes variegated",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = true,
                    Shape = "Upright, cane-like",
                    FullGrownHeight = 200,
                    FullGrownWidth = 80,
                    // New plant care properties:
                    Light = "Bright, indirect light is best; tolerates partial shade and low light but avoid harsh direct sun",
                    Water = "Water when the top 2–3 cm of soil is dry; keep soil evenly moist but never soggy. Reduce watering in winter",
                    Soil = "Loose, well-draining, slightly acidic potting mix with peat and perlite or sand",
                    FertilizationMethod = "General-purpose houseplant fertilizer monthly during the growing season; reduce or skip in winter",
                    TrimmingInstructions = "Trim brown tips and remove old leaves.",
                    TrimmingPeriod = "As needed",
                    TemperatureRangeMinimum = 15,
                    TemperatureRangeMaximum = 25
                }
,
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
                    ImagePath = diskLocationImages + "Lonicera_Lonicera_sp_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Dense, bushy",
                    FullGrownHeight = 150,
                    FullGrownWidth = 120,
                    // New plant care properties:
                    Light = "Full sun to partial shade; tolerates a range but best growth and color in full sun",
                    Water = "Moderate; water regularly during establishment, then deeply once a week in dry periods. Keep soil moist but not waterlogged",
                    Soil = "Moist but well-drained, fertile soil; tolerates a wide range including clay, loam, or sand. Neutral to slightly alkaline pH preferred",
                    FertilizationMethod = "Light fertilizer in spring; use slow-release or organic fertilizer if soil is poor",
                    TrimmingInstructions = "Trim regularly to maintain shape.",
                    TrimmingPeriod = "Spring and summer",
                    TemperatureRangeMinimum = -15,
                    TemperatureRangeMaximum = 30
                }
,
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
                    ImagePath = diskLocationImages + "GrijsKattenkruid_Nepeta_x_faassenii_Base01.png",
                    PlantType = PlantType.Herb,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = true,
                    Color = "Green (leaves), White/Lavender (flowers)",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Upright, bushy herb",
                    FullGrownHeight = 90,
                    FullGrownWidth = 60,
                    // New plant care properties:
                    Light = "Full sun is best; tolerates partial shade, especially in hot climates",
                    Water = "Average; drought-tolerant once established. Water seedlings regularly, mature plants only during prolonged drought",
                    Soil = "Well-drained, sandy or loamy soil; tolerates poor and rocky soils; pH 6.1–7.8 (slightly acidic to slightly alkaline)",
                    FertilizationMethod = "Minimal; mix compost into soil in spring. Additional feeding rarely needed",
                    TrimmingInstructions = "Cut back after flowering to promote bushiness.",
                    TrimmingPeriod = "Late summer",
                    TemperatureRangeMinimum = -30,
                    TemperatureRangeMaximum = 35
                }
,
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
                    ImagePath = diskLocationImages + "EchteLavendel_Lavandula_angustifolia_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = true,
                    Color = "Purple (flowers), Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Compact, bushy",
                    FullGrownHeight = 60,
                    FullGrownWidth = 80,
                    // New plant care properties:
                    Light = "Full sun (at least 6–8 hours daily); tolerates light shade but best flowering in sun",
                    Water = "Water regularly during the first growing season. Once established, drought-tolerant; water only during prolonged dry spells. Allow soil to dry between waterings",
                    Soil = "Very well-drained, sandy or gritty soil; neutral to slightly alkaline (pH 6.5–7.5); avoid rich, damp, or clay soils",
                    FertilizationMethod = "Low-nutrient soil; avoid over-fertilizing. If needed, use a slow-release, low-nitrogen fertilizer in early spring",
                    TrimmingInstructions = "Prune lightly after flowering.",
                    TrimmingPeriod = "Late summer or early fall",
                    TemperatureRangeMinimum = -15,
                    TemperatureRangeMaximum = 30
                }
,
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
                    ImagePath = diskLocationImages + "Pioenroos_Paeonia_lactiflora_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Pink, White, Red (flowers), Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Bushy, upright",
                    FullGrownHeight = 100,
                    FullGrownWidth = 90,
                    // New plant care properties:
                    Light = "Full sun (at least 6 hours per day); tolerates light shade but best flowering in sun",
                    Water = "Water regularly during dry spells in the first year and in spring when buds form. Once established, water deeply only during prolonged drought",
                    Soil = "Loose, fertile, well-drained soil; neutral to slightly alkaline (pH 6.5–7.5). Enrich with compost or well-rotted manure in spring",
                    FertilizationMethod = "Apply general-purpose or low-nitrogen fertilizer and mulch with compost in early spring; avoid covering the crown",
                    TrimmingInstructions = "Remove spent flowers and cut back in autumn.",
                    TrimmingPeriod = "After flowering and in autumn",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 30
                }
,
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
                    ImagePath = diskLocationImages + "Gele_klaproos_Papaver_cambrica_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Embryophyta"),
                    IsEatable = false,
                    Color = "Yellow (flowers), Green (foliage)",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = true,
                    Shape = "Clumping, upright",
                    FullGrownHeight = 50,
                    FullGrownWidth = 30,
                    // New plant care properties:
                    Light = "Full sun to partial shade; best flowering in full sun",
                    Water = "Keep soil evenly moist but not soggy; water at the base and avoid overhead watering. Once established, water during dry spells",
                    Soil = "Rich, well-drained, light or sandy soil; avoid heavy, wet, or clay soils",
                    FertilizationMethod = "Light, balanced fertilizer in spring; in rich soil, fertilize once or twice per season, otherwise feed every 2–3 weeks during growth",
                    TrimmingInstructions = "Remove spent flowers to prolong blooming.",
                    TrimmingPeriod = "During flowering season",
                    TemperatureRangeMinimum = -40,
                    TemperatureRangeMaximum = 25
                }
,
                // Lesser Periwinkle
               new Plant
                {
                    Id = 23,
                    LocalName = "Lesser Periwinkle",
                    CommonName = "Lesser Periwinkle",
                    Family = "Apocynaceae",
                    Genus = "Vinca",
                    Species = "minor",
                    Description = "A low-growing, evergreen groundcover with trailing stems and glossy dark green leaves. Produces small, star-shaped blue-violet flowers from spring to early summer, with occasional blooms in autumn. Excellent for covering ground in shady areas and suppressing weeds. Tolerates a wide range of soil types and is easy to maintain.",
                    ImagePath = diskLocationImages + "KleineMaagdenpalm_Vinca_minor_Base01.png",
                    PlantType = PlantType.GroundCover,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Dark green foliage; blue-violet flowers",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = true,
                    Shape = "Spreading groundcover with trailing stems and star-shaped flowers",
                    FullGrownHeight = 15,
                    FullGrownWidth = 100,
                    // New plant care properties:
                    Light = "Full sun to full shade; best flowering in partial sun to partial shade",
                    Water = "Water regularly during establishment; once established, drought-tolerant and only needs watering during prolonged dry spells",
                    Soil = "Well-drained, fertile to poor soil; tolerates a wide range including sandy, loamy, or clay soils. Avoid very dry or waterlogged conditions",
                    FertilizationMethod = "Generally does not require fertilization. If growth is poor, apply a balanced fertilizer in spring or add compost",
                    TrimmingInstructions = "Trim after flowering to control growth and shape. Can be cut back hard in early spring if needed.",
                    TrimmingPeriod = "After flowering or early spring if rejuvenation is required",
                    TemperatureRangeMinimum = -25,
                    TemperatureRangeMaximum = 30
                }
,
                // Blue Gum Eucalyptus
               new Plant
                {
                    Id = 24,
                    LocalName = "Blue Gum",
                    CommonName = "Eucalyptus",
                    Family = "Myrtaceae",
                    Genus = "Eucalyptus",
                    Species = "globulus",
                    Description = "A fast-growing evergreen tree with smooth, peeling bark and aromatic, bluish-green leaves. Young leaves are round and silvery-blue, while mature leaves are long, lance-shaped, and dark green. Known for its strong menthol fragrance and used widely for essential oils and medicinal purposes. Prefers full sun and well-drained soil.",
                    ImagePath = diskLocationImages + "EucalyptusBoom_Eucalyptus_gunnii_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Bluish-green to dark green foliage; white to cream-colored flowers",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = true,
                    Shape = "Tall tree with upright growth, smooth bark, and elongated leaves",
                    FullGrownHeight = 5000,
                    FullGrownWidth = 2000,
                    // New plant care properties:
                    Light = "Full sun (at least 6 hours of direct sunlight daily)",
                    Water = "Water regularly during establishment; once established, drought-tolerant but water during prolonged dry spells. Keep soil moist but not soggy",
                    Soil = "Well-drained, slightly acidic to neutral soil (pH 5.5–7.0); tolerates most soil types except heavy clay or waterlogged soils",
                    FertilizationMethod = "Requires little fertilization; in poor soils, apply a balanced, low-nitrogen fertilizer in early spring. Container plants benefit from monthly feeding during the growing season",
                    TrimmingInstructions = "Prune in late winter or early spring to maintain shape or remove dead/damaged branches. Can be coppiced for shrub-like growth.",
                    TrimmingPeriod = "Late winter to early spring",
                    TemperatureRangeMinimum = -5,
                    TemperatureRangeMaximum = 40
                }
,
                // Photinia 'Red Robin'
               new Plant
                {
                    Id = 25,
                    LocalName = "Photinia 'Red Robin'",
                    CommonName = "Photinia",
                    Family = "Rosaceae",
                    Genus = "Photinia",
                    Species = "× fraseri",
                    Description = "An attractive evergreen shrub prized for its bright red new foliage that matures to glossy dark green. Produces small white flower clusters in late spring, though flowering is often secondary to its foliage appeal. Commonly used as a hedge or feature plant. Tolerates pruning well and thrives in full sun to partial shade.",
                    ImagePath = diskLocationImages + "Photinia_Photinia_fraseri_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Bright red new leaves turning glossy dark green; white flowers in spring",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Dense, upright shrub with oval leaves and a bushy form",
                    FullGrownHeight = 300,
                    FullGrownWidth = 250,
                    // New plant care properties:
                    Light = "Full sun to partial shade; best color and growth with at least 6 hours of sunlight daily. Shelter from cold winds if possible",
                    Water = "Water regularly during the first year; once established, drought-tolerant but water during prolonged dry spells. Avoid waterlogging",
                    Soil = "Moist, well-drained, humus-rich soil; tolerates a wide range, but prefers slightly alkaline to neutral pH. Avoid heavy, wet, or compacted soils",
                    FertilizationMethod = "Feed in spring with a general-purpose fertilizer or compost. Mulch annually to retain moisture and improve soil",
                    TrimmingInstructions = "Prune after flowering or in late spring to maintain shape and encourage new red growth. Can be hard pruned if necessary.",
                    TrimmingPeriod = "Late spring or after flowering",
                    TemperatureRangeMinimum = -10,
                    TemperatureRangeMaximum = 35
                }
,
                // Cherry Laurel
               new Plant
                {
                    Id = 26,
                    LocalName = "Cherry Laurel",
                    CommonName = "Prunus laurocerasus",
                    Family = "Rosaceae",
                    Genus = "Prunus",
                    Species = "laurocerasus",
                    Description = "A fast-growing, dense evergreen shrub or small tree with large, glossy dark green leaves. Produces upright clusters of small white flowers in spring, followed by small black berries. Commonly used for hedging and screening due to its dense foliage. Tolerant of shade and pruning, and adaptable to various soil types.",
                    ImagePath = diskLocationImages + "PrunusLaurocerasus_Prunus_laurocerasus_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Glossy dark green leaves; white flower spikes; black berries in autumn",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = true,
                    Shape = "Dense, bushy shrub with broad, leathery leaves and upright flower spikes",
                    FullGrownHeight = 400,
                    FullGrownWidth = 300,
                    // New plant care properties:
                    Light = "Full sun to full shade; tolerates a wide range but best growth in sun or partial shade", // [3][7][8]
                    Water = "Water regularly during establishment; keep soil consistently moist but not waterlogged. Once established, water deeply during dry spells", // [2][3][4][5][7][8]
                    Soil = "Moist, well-drained, fertile soil; tolerates a range from slightly acidic to slightly alkaline. Avoid heavy, waterlogged soils", // [1][3][4][6][7][8]
                    FertilizationMethod = "Apply a balanced slow-release fertilizer in early spring. Mulch annually with organic matter to retain moisture and improve soil", // [4][5][6][7][8]
                    TrimmingInstructions = "Trim after flowering or in late summer to maintain shape and size. Can be hard pruned if overgrown.",
                    TrimmingPeriod = "Late spring to late summer",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 35
                }
               ,
                // Male Fern 'Linearis Polydactyla'
             new Plant
            {
                Id = 27,
                LocalName = "Male Fern 'Linearis Polydactyla'",
                CommonName = "Male Fern",
                Family = "Dryopteridaceae",
                Genus = "Dryopteris",
                Species = "filix-mas",
                Description = "A deciduous fern forming large, shuttlecock-like clumps of erect to arching, mid-green fronds. The fronds are finely divided, giving it a delicate and airy appearance. Ideal for shaded gardens and woodland settings.",
                ImagePath = diskLocationImages + "Mannetjesvaren_Dryopteris_flix-mas_Base01.png",
                PlantType = PlantType.Fern,
                PlantClassification = PlantClassification.Pteridophytes,
                PhylumInfo = (Phylum)GetPhylumByName(phyla, "Polypodiophyta"),
                IsEatable = false,
                Color = "Mid-green fronds",
                IsFlowering = false,
                IsEvergreen = false,
                IsPoisonous = false, // No reported toxicity to humans or pets[2]
                Shape = "Clump-forming with arching fronds",
                FullGrownHeight = 80,
                FullGrownWidth = 60,
                // New plant care properties:
                Light = "Partial to full shade; tolerates dappled shade and can grow in full sun if soil is kept moist", // [2][4][5][7]
                Water = "Prefers consistently moist, well-drained soil; water regularly in dry periods, especially in first season. Drought-tolerant once established but best with even moisture", // [4][5][7]
                Soil = "Moist, well-drained, humus-rich soil; adaptable to a range of soil types and pH, including clay, loam, sandy, acidic, neutral, or alkaline", // [2][4][5][7][8]
                FertilizationMethod = "Fertilizing is not necessary, but you can apply a balanced, slow-release fertilizer once in spring if desired. Mulch annually to conserve moisture", // [5][8]
                TrimmingInstructions = "Remove old fronds in early spring before new growth appears.",
                TrimmingPeriod = "Early spring",
                TemperatureRangeMinimum = -40,
                TemperatureRangeMaximum = 30
            }
,
                // Snowberry (Symphoricarpos × chenaultii)
               new Plant
                {
                    Id = 28,
                    LocalName = "Snowberry",
                    CommonName = "Chenault Coralberry",
                    Family = "Caprifoliaceae",
                    Genus = "Symphoricarpos",
                    Species = "× chenaultii",
                    Description = "A dense, deciduous shrub with arching branches and small oval leaves. Produces small pink flowers in summer followed by clusters of white or pale pink berries in autumn, which persist into winter. Commonly used for groundcover, hedging, or wildlife gardens. Tolerates poor soils and urban conditions well.",
                    ImagePath = diskLocationImages + "Symphoricarpos_orbiculatus_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green foliage; pink flowers; white or pink berries",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = true,
                    Shape = "Arching shrub with spreading habit and clusters of berries",
                    FullGrownHeight = 150,
                    FullGrownWidth = 200,
                    // New plant care properties:
                    Light = "Full sun to partial shade; best flowering and berry production in full sun",
                    Water = "Water regularly during the first growing season. Once established, drought-tolerant; water during prolonged dry spells but avoid overwatering",
                    Soil = "Well-drained, fertile to poor soils; tolerates clay, sandy, and rocky soils. Prefers reasonably moist but not waterlogged soil",
                    FertilizationMethod = "Rarely needs fertilization; apply compost or a balanced fertilizer in spring if growth is weak or soil is poor",
                    TrimmingInstructions = "Prune in late winter or early spring to maintain shape and encourage dense growth. Can tolerate hard pruning.",
                    TrimmingPeriod = "Late winter to early spring",
                    TemperatureRangeMinimum = -25,
                    TemperatureRangeMaximum = 30
                }
               ,
                // Coconut Palm
             new Plant
                {
                    Id = 29,
                    LocalName = "Coconut Palm",
                    CommonName = "Coconut Tree",
                    Family = "Arecaceae",
                    Genus = "Cocos",
                    Species = "nucifera",
                    Description = "A tall, tropical palm tree with a slender, ringed trunk and large, feathery fronds. It produces coconuts, which are used for food, oil, fiber, and water. The coconut palm thrives in sandy, well-drained soils in coastal areas and requires full sun and high humidity.",
                    ImagePath = diskLocationImages + "Kokospalm_Cocos_nucifera_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true,
                    Color = "Green fronds; brown, fibrous coconuts",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Tall single trunk with a crown of large, arching fronds",
                    FullGrownHeight = 3000,
                    FullGrownWidth = 600,
                    // New plant care properties:
                    Light = "Bright, indirect light to full sun; needs at least 6-8 hours of sunlight daily. Avoid harsh, direct midday sun indoors to prevent leaf scorch.",
                    Water = "Keep soil consistently moist but not soggy. Water deeply when the top few centimeters of soil are dry. Reduce watering in winter but do not let the soil fully dry out.",
                    Soil = "Well-draining, sandy or loamy soil. Mix in coarse sand or perlite to improve drainage. Avoid heavy, compacted, or waterlogged soils.",
                    FertilizationMethod = "Apply a palm-specific fertilizer rich in potassium and magnesium every 3-4 weeks during the growing season. Reduce or stop feeding in fall and winter.",
                    TrimmingInstructions = "Remove dead or damaged fronds regularly to maintain appearance and prevent pests. Harvest coconuts when mature.",
                    TrimmingPeriod = "Year-round as needed",
                    TemperatureRangeMinimum = 18,
                    TemperatureRangeMaximum = 38
                }
,
                // Dieffenbachia amoena
              new Plant
                {
                    Id = 30,
                    LocalName = "Dieffenbachia amoena",
                    CommonName = "Dumb Cane",
                    Family = "Araceae",
                    Genus = "Dieffenbachia",
                    Species = "amoena",
                    Description = "A tropical evergreen perennial with large, broad leaves marked with creamy white or light green patterns. It is a popular indoor plant due to its attractive foliage and tolerance of low light conditions. Requires warm, humid environments and regular watering.",
                    ImagePath = diskLocationImages + "GrootbladigeDieffenbachia_Dieffenbachia_amoena_Base01.png",
                    PlantType = PlantType.Houseplant,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Green leaves with white or cream variegation",
                    IsFlowering = false,
                    IsEvergreen = true,
                    IsPoisonous = true,
                    Shape = "Upright clumping plant with large variegated leaves",
                    FullGrownHeight = 120,
                    FullGrownWidth = 60,
                    // New plant care properties:
                    Light = "Bright, indirect light is best; tolerates light shade but avoid direct sun. Rotate regularly for even growth.",
                    Water = "Water when the top 2–3 cm of soil is dry. Keep soil consistently and lightly moist, but not soggy. Reduce watering in winter.",
                    Soil = "Well-draining, fertile potting mix with peat, coco coir, and perlite or bark for aeration.",
                    FertilizationMethod = "Feed monthly during the growing season with a balanced liquid fertilizer diluted to half strength. Avoid fertilizing dry soil.",
                    TrimmingInstructions = "Remove yellowing or damaged leaves to maintain appearance. Prune leggy stems to encourage bushier growth.",
                    TrimmingPeriod = "Year-round as needed",
                    TemperatureRangeMinimum = 15,
                    TemperatureRangeMaximum = 30
                }
              ,
                // Yellow Horned Poppy (Glaucium flavum)
              new Plant
                {
                    Id = 31,
                    LocalName = "Yellow Horned Poppy",
                    CommonName = "Horned Poppy",
                    Family = "Papaveraceae",
                    Genus = "Glaucium",
                    Species = "flavum",
                    Description = "A hardy perennial coastal plant with gray-green, lobed leaves and large, bright yellow cup-shaped flowers. It produces distinctive long, curved seed pods resembling horns. Thrives in sandy, well-drained soils, often found on dunes and seaside cliffs.",
                    ImagePath = diskLocationImages + "Gele_klaproos_Papaver_cambrica_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Bright yellow flowers; gray-green foliage",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = true,
                    Shape = "Bushy, low-growing plant with lobed leaves and upright flower stems",
                    FullGrownHeight = 60,
                    FullGrownWidth = 45,
                    // New plant care properties:
                    Light = "Full sun; requires at least 6 hours of direct sunlight daily and does not tolerate shade.",
                    Water = "Water sparingly; allow soil to dry almost completely between waterings. Drought-tolerant once established.",
                    Soil = "Well-drained, sandy or chalky soil; tolerates poor, nutrient-deficient soils. Avoid heavy or waterlogged soils.",
                    FertilizationMethod = "Generally low maintenance; does not require regular fertilization. Apply a light, balanced fertilizer in spring only if growth is poor.",
                    TrimmingInstructions = "Cut back dead foliage in late winter or early spring. Remove spent flowers to encourage more blooms.",
                    TrimmingPeriod = "Late winter to early spring",
                    TemperatureRangeMinimum = -15,
                    TemperatureRangeMaximum = 30
                }
,
                // Paeonia edulis
                new Plant
                {
                    Id = 32,
                    LocalName = "Paeonia edulis",
                    CommonName = "Edulis Peony",
                    Family = "Paeoniaceae",
                    Genus = "Paeonia",
                    Species = "edulis",
                    Description = "A deciduous perennial peony native to China, known for its large, showy flowers that range in colors from white to pink. Prefers well-drained soil and a sunny to partially shaded location. Blooms in late spring to early summer.",
                    ImagePath = diskLocationImages + "Pioenroos_Paeonia_edulis_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Flower colors vary: white, pink, or red hues",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Bushy herbaceous perennial with large, rounded flowers",
                    FullGrownHeight = 80,
                    FullGrownWidth = 70,
                    Light = "Full sun to partial shade; best flowering with at least 6 hours of sunlight daily and shelter from strong winds.",
                    Water = "Water deeply every 7–10 days during dry spells, especially in the first year. Keep soil moist but never soggy. Once established, water only during prolonged drought.",
                    Soil = "Fertile, humus-rich, moist but well-drained soil with a slightly acidic to neutral pH (6.0–7.0). Avoid planting in heavy, waterlogged, or compacted soils.",
                    FertilizationMethod = "Apply a balanced fertilizer in early spring and again after flowering to encourage strong growth. Avoid over-fertilizing; mature peonies generally need little feeding.",
                    TrimmingInstructions = "Cut back stems after flowering to ground level in late autumn. Remove dead foliage in early spring.",
                    TrimmingPeriod = "Late autumn and early spring",
                    TemperatureRangeMinimum = -30,
                    TemperatureRangeMaximum = 30
                }
,
                new Plant
                {
                    Id = 33,
                    LocalName = "Spathiphyllum wallisii",
                    CommonName = "Peace Lily",
                    Family = "Araceae",
                    Genus = "Spathiphyllum",
                    Species = "wallisii",
                    Description = "A popular evergreen perennial valued for its lush green foliage and striking white spathes. Native to tropical regions of the Americas and Southeast Asia. Thrives as a houseplant and is known for its air-purifying qualities.",
                    ImagePath = diskLocationImages + "PeaceLily_Spathiphyllum_wallisii_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "White spathes with green foliage",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = true, // Note: Spathiphyllum is toxic to pets and humans if ingested
                    Shape = "Clumping, upright perennial with lance-shaped leaves",
                    FullGrownHeight = 60,
                    FullGrownWidth = 60,
                    // New plant care properties:
                    Light = "Bright, indirect light. Can tolerate lower light but may flower less.",
                    Water = "Keep soil evenly moist but not soggy. Water when the top inch of soil feels dry. Avoid letting the plant sit in water.",
                    Soil = "Well-draining, peat-based potting mix with good moisture retention.",
                    FertilizationMethod = "Feed monthly during spring and summer with a balanced liquid fertilizer. Reduce feeding in winter.",
                    TrimmingInstructions = "Remove yellow or brown leaves as needed. Cut off spent flowers to encourage new blooms.",
                    TrimmingPeriod = "As needed, throughout the year",
                    TemperatureRangeMinimum = 16,
                    TemperatureRangeMaximum = 30
                }
                ,
                // Stargazer Lily (Lilium 'Stargazer')
                new Plant
                {
                    Id = 34,
                    LocalName = "Stargazer Lily",
                    CommonName = "Stargazer Lily",
                    Family = "Liliaceae",
                    Genus = "Lilium",
                    Species = "'Stargazer'",
                    Description = "A vibrant, fragrant oriental lily cultivar featuring large, upward-facing pink flowers with white edges and dark spots. Blooms in mid to late summer and is widely grown for cut flowers and garden display. Prefers well-drained soil and full sun to partial shade.",
                    ImagePath = diskLocationImages + "StargazerLelie_Lilium_orientalis_Stargazer_Base01.png",
                    PlantType = PlantType.Bulb,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Pink flowers with white margins and dark spots",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = true,
                    Shape = "Erect stems with large trumpet-shaped flowers",
                    FullGrownHeight = 90,
                    FullGrownWidth = 30,
                    // New plant care properties:
                    Light = "Full sun to partial shade; best flowering with at least 6 hours of direct sunlight daily. Prefers morning sun and some afternoon shade in hot climates.",
                    Water = "Keep soil consistently moist but not waterlogged. Water deeply when the top inch of soil is dry and avoid overhead watering to protect blooms. Mulch to retain moisture and keep roots cool.",
                    Soil = "Well-drained, fertile soil with average to slightly acidic pH (6.3–6.8). Enrich with compost or organic matter before planting. Avoid heavy, soggy, or compacted soils.",
                    FertilizationMethod = "Feed with a balanced, all-purpose or bulb fertilizer every 4–6 weeks during the growing season. Top dress with organic fertilizer at planting, when shoots emerge, and after flowering.",
                    TrimmingInstructions = "Cut back flower stems after blooming. Remove yellow or dead foliage to maintain plant health.",
                    TrimmingPeriod = "After flowering",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 30
                }
                ,
                // Clematis armandii
               new Plant
                {
                    Id = 35,
                    LocalName = "Clematis armandii",
                    CommonName = "Evergreen Clematis",
                    Family = "Ranunculaceae",
                    Genus = "Clematis",
                    Species = "armandii",
                    Description = "An evergreen climbing vine with leathery dark green leaves and fragrant white flowers that bloom in early spring. It thrives in well-drained soil with full sun to partial shade and is often used to cover walls, fences, or trellises.",
                    ImagePath = diskLocationImages + "Clematis_Clematis_sp_Base01.png",
                    PlantType = PlantType.Climber,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Dark green foliage; white fragrant flowers",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Climbing vine with dense foliage and clusters of flowers",
                    FullGrownHeight = 600,
                    FullGrownWidth = 150,
                    // New plant care properties:
                    Light = "Full sun to partial shade; prefers its roots in shade and top growth in sun. Provide shelter from cold, drying winds.",
                    Water = "Water regularly during the first growing season to establish a deep root system. Once established, water during dry spells. Keep soil evenly moist but not waterlogged.",
                    Soil = "Well-drained, fertile soil enriched with organic matter. Prefers neutral to slightly alkaline pH. Avoid heavy clay or waterlogged soils.",
                    FertilizationMethod = "Apply a balanced fertilizer in early spring and again in mid-summer for best growth and flowering.",
                    TrimmingInstructions = "Prune lightly after flowering to maintain shape and remove dead or weak stems.",
                    TrimmingPeriod = "After flowering in late spring",
                    TemperatureRangeMinimum = -15,
                    TemperatureRangeMaximum = 35
                }
,
               //lithodora diffusa
               new Plant
                {
                    Id = 36,
                    LocalName = "Lithodora diffusa",
                    CommonName = "Lithodora, Creeping Gromwell",
                    Family = "Boraginaceae",
                    Genus = "Lithodora",
                    Species = "diffusa",
                    Description = "A prostrate, multi-branched evergreen ground cover native to southwestern Europe and the Mediterranean. Known for its intense blue, star-shaped flowers and dense, hairy, dark green foliage. Ideal for rock gardens, slopes, and as a ground cover.",
                    ImagePath = diskLocationImages + "Lithodora_diffusa_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Intense blue flowers, dark green foliage",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Mat-forming, prostrate, trailing",
                    FullGrownHeight = 15,
                    FullGrownWidth = 60,
                    // New plant care properties:
                    Light = "Full sun to partial shade. Best flowering in full sun.",
                    Water = "Keep soil moist but well-drained. Water regularly after planting; established plants are fairly drought tolerant.",
                    Soil = "Well-drained, acidic to neutral soil. Avoid heavy, waterlogged soils.",
                    FertilizationMethod = "Light feeding with a balanced fertilizer in early spring. Avoid over-fertilizing.",
                    TrimmingInstructions = "Not required, but old or unsightly foliage can be trimmed as needed. Remove dead material in spring.",
                    TrimmingPeriod = "As needed, preferably in spring",
                    TemperatureRangeMinimum = -23,
                    TemperatureRangeMaximum = 30
                }
               ,
               //Salix integra
               new Plant
                {
                    Id = 35,
                    LocalName = "Salix integra",
                    CommonName = "Japanese Willow, Hakuro Nishiki",
                    Family = "Salicaceae",
                    Genus = "Salix",
                    Species = "integra",
                    Description = "A deciduous shrub or small tree prized for its vibrant, variegated foliage and attractive habit. Native to Japan and Korea. Often used as a specimen plant or in mixed borders for its colorful leaves and graceful form.",
                    ImagePath = diskLocationImages + "Salix_integra_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Pink, white, and green variegated leaves; brown/gray bark",
                    IsFlowering = true, // Note: Salix species have inconspicuous catkins
                    IsEvergreen = false,
                    IsPoisonous = false,
                    Shape = "Bushy shrub or small tree, often with a rounded or upright habit",
                    FullGrownHeight = 200,
                    FullGrownWidth = 150,
                    // New plant care properties:
                    Light = "Full sun to partial shade. Best foliage color in full sun.",
                    Water = "Keep soil consistently moist, especially in hot weather. Prefers damp conditions but avoid waterlogging.",
                    Soil = "Moist, well-drained, fertile soil. Tolerates a range of soil types including clay, loam, and sand.",
                    FertilizationMethod = "Apply a balanced fertilizer in early spring. Mulch around the base to retain moisture.",
                    TrimmingInstructions = "Prune hard in late winter or early spring to encourage vibrant new growth. Remove dead or crossing branches.",
                    TrimmingPeriod = "Late winter or early spring",
                    TemperatureRangeMinimum = -30,
                    TemperatureRangeMaximum = 35
                }
               ,
               // Vicia villosa
                new Plant
                {
                    Id = 36,
                    LocalName = "Vicia villosa",
                    CommonName = "Hairy Vetch",
                    Family = "Fabaceae",
                    Genus = "Vicia",
                    Species = "villosa",
                    Description = "A vigorous annual or biennial legume valued as a cover crop for its ability to fix nitrogen, improve soil structure, and suppress weeds. Recognized by its trailing, climbing habit and hairy stems and leaves. Produces purple to violet pea-like flowers.",
                    ImagePath = diskLocationImages + "Vicia_villosa_Base01.png",
                    PlantType = PlantType.Herb, // Annual/biennial legume
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false, // Not typically eaten by humans; used as forage/green manure
                    Color = "Purple to violet flowers; green hairy foliage",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = false, // Generally safe for livestock, but excessive consumption can cause issues
                    Shape = "Trailing or climbing vine, often sprawling over the ground or other plants",
                    FullGrownHeight = 60, // Typically 30–90 cm, can climb higher if supported
                    FullGrownWidth = 120, // Can spread widely as a ground cover
                    // Plant care properties:
                    Light = "Full sun to partial shade. Prefers open, sunny locations for best growth.",
                    Water = "Prefers moist, well-drained soils but is drought-tolerant once established.",
                    Soil = "Tolerates a range of soils, including sandy, loamy, and clay soils. Prefers neutral to slightly acidic pH.",
                    FertilizationMethod = "Usually no fertilizer needed due to nitrogen fixation. In poor soils, a balanced starter fertilizer may help establishment.",
                    TrimmingInstructions = "Mow or cut back before seed set to prevent self-seeding if used as a cover crop. Incorporate into soil as green manure at flowering.",
                    TrimmingPeriod = "Late spring to early summer (at flowering stage for green manure)",
                    TemperatureRangeMinimum = -20, // Hardy, tolerates frost
                    TemperatureRangeMaximum = 30
                }
,
                // Heuchera 'Mulberry'
                new Plant
                {
                    Id = 38,
                    LocalName = "Heuchera 'Mulberry'",
                    CommonName = "Purperklokje Mulberry",
                    Family = "Saxifragaceae",
                    Genus = "Heuchera",
                    Species = "Mulberry", // Cultivar
                    Description = "Compacte, halfwintergroene vaste plant met opvallend glanzend paars blad en donkerpaarse nerven. In de zomer verschijnen op donkere stelen kleine, lichtroze bloemen. Ideaal voor borders, rotstuinen en potten.",
                    ImagePath = diskLocationImages + "Heuchera_Mulberry_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Paars blad met donkerpaarse nerven; lichtroze bloemen",
                    IsFlowering = true,
                    IsEvergreen = false, // Halfwintergroen: behoudt deels blad in milde winters[2][8]
                    IsPoisonous = false,
                    Shape = "Compacte, polvormende groei",
                    FullGrownHeight = 40, // ca. 40 cm hoog[8]
                    FullGrownWidth = 30,  // ca. 30 cm breed[8]
                    // Plant care properties:
                    Light = "Halfschaduw tot zon. Beste bladkleur in lichte schaduw.",
                    Water = "Normale waterbehoefte; goed doorlatende, humusrijke grond. Niet te nat in de winter.",
                    Soil = "Vochtige, goed doorlatende, humusrijke bodem. Verdraagt geen zware klei of natte voeten.",
                    FertilizationMethod = "Voorzichtig bemesten in het voorjaar met organische mest.",
                    TrimmingInstructions = "Verwijder uitgebloeide bloemstelen en lelijk blad om nieuwe groei te stimuleren.",
                    TrimmingPeriod = "Voorjaar en na de bloei",
                    TemperatureRangeMinimum = -20, // Winterhard tot ca. -20 °C[6]
                    TemperatureRangeMaximum = 30
                }
                ,
                // Sedum 'Crystal Pink'
                new Plant
                {
                    Id = 39,
                    LocalName = "Sedum 'Crystal Pink'",
                    CommonName = "Crystal Pink Stonecrop",
                    Family = "Crassulaceae",
                    Genus = "Sedum",
                    Species = "spectabile", // Cultivar: 'Crystal Pink'
                    Description = "A low-growing, clump-forming, deciduous perennial with thick, fleshy, bright blue-green leaves. In late summer and fall, it produces large clusters of star-shaped icy pink flowers on sturdy stems. Drought-tolerant and highly attractive to butterflies, it is ideal for borders, rock gardens, and containers.",
                    ImagePath = diskLocationImages + "Sedum_CrystalPink_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Bright blue-green foliage; icy pink flowers",
                    IsFlowering = true,
                    IsEvergreen = false, // Deciduous perennial[1][7]
                    IsPoisonous = false,
                    Shape = "Low, mounding clump with upright, sturdy flowering stems",
                    FullGrownHeight = 40, // 30-40 cm (12-16 inches)[1][3][5]
                    FullGrownWidth = 40,  // 30-40 cm (12-16 inches)[1][3][5]
                    // Plant care properties:
                    Light = "Full sun. Tolerates some light shade but best flowering and color in full sun.",
                    Water = "Low to moderate. Drought-tolerant once established. Requires well-drained soil.",
                    Soil = "Chalk, loam, or sand; neutral to alkaline pH. Must be well-drained.",
                    FertilizationMethod = "Generally not needed. If desired, apply a balanced, slow-release fertilizer in early spring.",
                    TrimmingInstructions = "Remove spent flower heads and dead foliage in late fall or early spring to maintain appearance.",
                    TrimmingPeriod = "Late fall or early spring",
                    TemperatureRangeMinimum = -30, // USDA zone 4 hardy[1][3]
                    TemperatureRangeMaximum = 35
                }
                ,


                //NOTE JCO --> from here is Dutch, we can make a Dutch and English seeding code

                // Erica carnea (Winterheide)
                new Plant
                {
                    Id = 40,
                    LocalName = "Erica carnea",
                    CommonName = "Winterheide, Schneeheide",
                    Family = "Ericaceae",
                    Genus = "Erica",
                    Species = "carnea",
                    Description = "Laagblijvende, wintergroene heester met naaldachtig blad en klokvormige bloemen. Bloeit van de winter tot het vroege voorjaar in kleuren van wit tot roze en paars. Geschikt als bodembedekker, voor rotstuinen en wintertuinen.",
                    ImagePath = diskLocationImages + "Erica_carnea_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Groen blad; bloemen wit, roze of paars",
                    IsFlowering = true,
                    IsEvergreen = true, // Wintergroen
                    IsPoisonous = false,
                    Shape = "Laag, kussenvormig, bodembedekkend",
                    FullGrownHeight = 25, // 15-30 cm
                    FullGrownWidth = 40,  // 30-50 cm
                    // Plant care properties:
                    Light = "Volle zon tot lichte schaduw; beste bloei in de zon.",
                    Water = "Matig, bestand tegen droogte zodra gevestigd. Jonge planten regelmatig water geven.",
                    Soil = "Goed doorlatende, bij voorkeur zure grond. Verdraagt lichte kalk.",
                    FertilizationMethod = "Voorzichtig bemesten in het voorjaar met organische meststoffen.",
                    TrimmingInstructions = "Na de bloei uitgebloeide bloemen en wildgroei wegknippen voor compacte groei.",
                    TrimmingPeriod = "Direct na de bloei (lente)",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 30
                 }
                ,
                // Carex morrowii (Japanse zegge)
                new Plant
                {
                    Id = 41,
                    LocalName = "Carex morrowii",
                    CommonName = "Japanse zegge",
                    Family = "Cyperaceae",
                    Genus = "Carex",
                    Species = "morrowii",
                    Description = "Wintergroene, polvormende siergrasachtige plant met smal, overhangend blad. Populair vanwege het decoratieve, vaak bontgevlekte blad. Geschikt als bodembedekker, voor schaduwrijke borders en onderbeplanting.",
                    ImagePath = diskLocationImages + "Carex_morrowii_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Groen of groen-wit bont blad; onopvallende bruine bloeiaren",
                    IsFlowering = true, // Bloeit met kleine aren, niet opvallend
                    IsEvergreen = true, // Blad blijft in milde winters groen
                    IsPoisonous = false,
                    Shape = "Polvormend, overhangend blad, bodembedekkend",
                    FullGrownHeight = 30, // 25-40 cm
                    FullGrownWidth = 40,  // 30-50 cm
                    // Plant care properties:
                    Light = "Halfschaduw tot schaduw; verdraagt ook zon mits voldoende vochtig.",
                    Water = "Vochtige, goed doorlatende grond. Verdraagt geen langdurige droogte.",
                    Soil = "Humusrijk, vochthoudend, licht zuur tot neutraal.",
                    FertilizationMethod = "Voorzichtig bemesten in het voorjaar met organische mest of compost.",
                    TrimmingInstructions = "Verwijder in het voorjaar oud of lelijk blad om nieuwe groei te stimuleren.",
                    TrimmingPeriod = "Vroege voorjaar",
                    TemperatureRangeMinimum = -20,
                    TemperatureRangeMaximum = 30
                }
                ,
                // Campanula poscharskyana (Servisch klokje)
                new Plant
                {
                    Id = 42,
                    LocalName = "Campanula poscharskyana",
                    CommonName = "Servisch klokje",
                    Family = "Campanulaceae",
                    Genus = "Campanula",
                    Species = "poscharskyana",
                    Description = "Laagblijvende, kruipende vaste plant met stervormige paarsblauwe bloemen. Ideaal als bodembedekker, voor rotstuinen, muurtjes of randen. Bloeit langdurig in de zomer en is zeer onderhoudsarm.",
                    ImagePath = diskLocationImages + "Campanula_poscharskyana_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Paarsblauwe bloemen; donkergroen blad",
                    IsFlowering = true,
                    IsEvergreen = false, // Half-wintergroen: blad blijft deels in milde winters[5][6]
                    IsPoisonous = false,
                    Shape = "Kruipende, bodembedekkende groei, vormt tapijt van bloemen",
                    FullGrownHeight = 20, // 15-20 cm hoog[5][6]
                    FullGrownWidth = 60,  // Kan breed uitlopen als bodembedekker
                    // Plant care properties:
                    Light = "Zon tot halfschaduw; groeit ook in lichte schaduw[2][5][6]",
                    Water = "Vochtige, goed doorlatende bodem; droogtetolerant zodra gevestigd[1][5][7]",
                    Soil = "Voedselrijke, humusrijke, kalkrijke, goed doorlatende grond[2][5][6]",
                    FertilizationMethod = "In het voorjaar bemesten met organische meststof; op arme zandgrond eventueel herhalen tijdens de bloei[5].",
                    TrimmingInstructions = "Na de bloei of in het najaar tot 20 cm boven de grond terugsnoeien voor verjonging en compacte groei[1][5][6].",
                    TrimmingPeriod = "Najaar of direct na de bloei",
                    TemperatureRangeMinimum = -20, // Goed winterhard[5][6]
                    TemperatureRangeMaximum = 30
                }
                ,
                // Campanula garganica (Gargano klokje)
                new Plant
                {
                    Id = 43,
                    LocalName = "Campanula garganica",
                    CommonName = "Gargano klokje",
                    Family = "Campanulaceae",
                    Genus = "Campanula",
                    Species = "garganica",
                    Description = "Laagblijvende, bodembedekkende vaste plant met stervormige, lichtblauwe tot violetblauwe bloemen aan kruipende stengels. Ideaal voor rotstuinen, randen en potten. Bloeit rijk in de zomer en trekt bijen en vlinders aan.",
                    ImagePath = diskLocationImages + "Campanula_garganica_Base01.png",
                    PlantType = PlantType.Perennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Lichtblauwe tot violetblauwe bloemen; frisgroen blad",
                    IsFlowering = true,
                    IsEvergreen = true, // Bladhoudend in milde winters[2][5]
                    IsPoisonous = false,
                    Shape = "Laag, kruipend, bodembedekkend tapijt",
                    FullGrownHeight = 20, // 10-25 cm[2][5]
                    FullGrownWidth = 40,  // Kan breed uitlopen als bodembedekker
                    // Plant care properties:
                    Light = "Volle zon tot halfschaduw; beste bloei in de zon[1][2][4][5][6]",
                    Water = "Regelmatig water geven, vooral bij droogte; verdraagt korte periodes van droogte maar niet natte grond in de winter[1][5][3]",
                    Soil = "Voedselrijke, humusrijke, goed doorlatende grond; neutraal tot licht zuur[1][2][6]",
                    FertilizationMethod = "Voorjaar licht bemesten met organische mest of compost; bij aanplant universele aanplantgrond gebruiken[1]",
                    TrimmingInstructions = "Verwijder uitgebloeide bloemen voor een tweede bloei. Knip in het vroege voorjaar verdorde bladeren weg[1][5].",
                    TrimmingPeriod = "Na de bloei en in het vroege voorjaar",
                    TemperatureRangeMinimum = -25, // Goed winterhard[1][2]
                    TemperatureRangeMaximum = 30
                }
                ,
                // Fargesia rufa (Dragon Head Bamboo)
                new Plant
                {
                    Id = 44,
                    LocalName = "Fargesia rufa",
                    CommonName = "Dragon Head Bamboo, Niet-woekerende bamboe",
                    Family = "Poaceae",
                    Genus = "Fargesia",
                    Species = "rufa",
                    Description = "Compacte, niet-woekerende bamboe met sierlijk, frisgroen blad en opgaande, licht overhangende stengels. Ideaal als haag, solitair of in pot. Zeer winterhard, snelgroeiend en bestand tegen ziekten. Geschikt voor zon, halfschaduw en schaduw.",
                    ImagePath = diskLocationImages + "Fargesia_rufa_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Frisgroen blad; groene tot roodachtige stengels",
                    IsFlowering = false, // Bamboe bloeit zelden en sterft daarna vaak af
                    IsEvergreen = true,
                    IsPoisonous = false,
                    Shape = "Polvormend, opgaand met licht overhangende stengels",
                    FullGrownHeight = 300, // 2,5-3 meter[6]
                    FullGrownWidth = 150,  // 1-1,5 meter[6]
                    // Plant care properties:
                    Light = "Volle zon tot schaduw; beste groei in halfschaduw tot lichte zon[1][3][6]",
                    Water = "Regelmatig water geven, vooral bij droogte en in potten. Houd de grond vochtig maar niet nat.[3][5][7]",
                    Soil = "Luchtige, vruchtbare, goed doorlatende grond. Voorkeur voor licht vochtige bodem, niet te nat of te droog.[1][3][6]",
                    FertilizationMethod = "Bemest in het voorjaar en eventueel in de zomer met organische mest of speciale bamboemest.[3][5][6]",
                    TrimmingInstructions = "Verwijder dode of beschadigde stengels in het voorjaar. Eventueel uitdunnen voor luchtigheid.[3][6]",
                    TrimmingPeriod = "Vroege voorjaar of na de winter",
                    TemperatureRangeMinimum = -25, // Zeer winterhard[1][6]
                    TemperatureRangeMaximum = 35
                }
                ,
                // Digitalis purpurea (Vingerhoedskruid, Foxglove)
                new Plant
                {
                    Id = 45,
                    LocalName = "Digitalis purpurea",
                    CommonName = "Vingerhoedskruid, Foxglove",
                    Family = "Plantaginaceae",
                    Genus = "Digitalis",
                    Species = "purpurea",
                    Description = "Tweejarige of kortlevende vaste plant met een bladrozet in het eerste jaar en een hoge, opgaande bloeistengel in het tweede jaar. De buisvormige bloemen zijn meestal paars, maar kunnen ook roze, wit of geel zijn, vaak met opvallende vlekken aan de binnenzijde. Bekend als sierplant én als bron van de hartmedicatie digoxine. Alle delen zijn giftig.",
                    ImagePath = diskLocationImages + "Digitalis_purpurea_Base01.png",
                    PlantType = PlantType.Biennial, // Of Perennial voor sommige cultivars
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false, // Zeer giftig!
                    Color = "Paars, roze, wit, geel; bloemen met vlekken aan de binnenzijde",
                    IsFlowering = true,
                    IsEvergreen = false,
                    IsPoisonous = true, // Alle delen zijn giftig[1][2][5][6]
                    Shape = "Bladrozet in jaar één, daarna een hoge, opgaande bloeistengel (1–2 meter) met aarvormige bloeiwijze",
                    FullGrownHeight = 150, // 100–200 cm[1][6]
                    FullGrownWidth = 40,   // 30–50 cm
                    // Plant care properties:
                    Light = "Volle zon tot halfschaduw; beste bloei in gefilterd zonlicht[2][3]",
                    Water = "Voorkeur voor gelijkmatig vochtige, goed doorlatende, humusrijke grond[2]",
                    Soil = "Tolerant, maar liefst lichtzure, humusrijke, losse grond[2]",
                    FertilizationMethod = "Matig bemesten in het voorjaar met organische meststof.",
                    TrimmingInstructions = "Verwijder uitgebloeide bloemstengels om zaadzetting te voorkomen of laat staan voor natuurlijke uitzaaiing.",
                    TrimmingPeriod = "Na de bloei (zomer)",
                    TemperatureRangeMinimum = -25, // Winterhard tot ca. -25°C[2]
                    TemperatureRangeMaximum = 30
                }
                ,
                // Elaeagnus × ebbingei (Olijfwilg, Ebbing’s silverberry)
                new Plant
                {
                    Id = 46,
                    LocalName = "Elaeagnus × ebbingei",
                    CommonName = "Olijfwilg, Ebbing’s silverberry",
                    Family = "Elaeagnaceae",
                    Genus = "Elaeagnus",
                    Species = "ebbingei",
                    Description = "Sterke, snelgroeiende, wintergroene struik of haagplant met glanzend donkergroen blad en zilvergrijze onderzijde. In het najaar verschijnen sterk geurende crèmekleurige bloemen, gevolgd door oranje tot roodbruine eetbare bessen in het voorjaar. Zeer geschikt voor hagen, windsingels en kusttuinen vanwege de hoge tolerantie voor wind, zout en arme grond.",
                    ImagePath = diskLocationImages + "Elaeagnus_ebbingei_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true, // Vruchten zijn eetbaar, maar met mate consumeren[1][3][6]
                    Color = "Donkergroen blad met zilvergrijze onderzijde; crèmekleurige bloemen; oranje/roodbruine bessen",
                    IsFlowering = true,
                    IsEvergreen = true, // Wintergroen in milde winters, soms semi-wintergroen bij strenge vorst[1][3][6]
                    IsPoisonous = false, // Niet giftig, maar bessen in grote hoeveelheden kunnen lichte maagklachten geven[2]
                    Shape = "Breed, ovaal, dicht vertakt; geschikt als haag of solitair",
                    FullGrownHeight = 400, // 3-4 meter, soms tot 5 meter[2][3][5][7]
                    FullGrownWidth = 300,  // 2-3,5 meter[2][3][5][7]
                    // Plant care properties:
                    Light = "Volle zon tot halfschaduw; groeit ook in schaduw maar langzamer[2][3][5][6]",
                    Water = "Drought-tolerant als volwassen, maar geef jonge planten regelmatig water tot ze goed geworteld zijn[2][3][5][6]",
                    Soil = "Goed doorlatende grond; verdraagt arme, droge, zanderige, kalkrijke en zelfs zoute kustgrond[2][3][5][6]",
                    FertilizationMethod = "Voorjaar bemesten met organische meststof of compost voor extra groei[2][3]",
                    TrimmingInstructions = "Snoei in de zomer of na de winter om de vorm te behouden en wildgroei te voorkomen. Kan hard teruggesnoeid worden indien nodig[2][3][5]",
                    TrimmingPeriod = "Zomer of direct na de winter",
                    TemperatureRangeMinimum = -15, // Volledig winterhard in Nederland en UK[2][3][5][7]
                    TemperatureRangeMaximum = 35
                }
                ,
                // Sedum oreganum (Oregon stonecrop)
                new Plant
                {
                    Id = 47,
                    LocalName = "Sedum oreganum",
                    CommonName = "Oregon stonecrop",
                    Family = "Crassulaceae",
                    Genus = "Sedum",
                    Species = "oreganum",
                    Description = "Laaggroeiende, winterharde vetplant afkomstig uit het westen van Noord-Amerika. Vormt dichte matten met kleine, vlezige, groene bladeren en gele bloemen in de zomer. Ideaal als bodembedekker of in rotstuinen.",
                    ImagePath = diskLocationImages + "Sedum_oreganum_Base01.png",
                    PlantType = PlantType.Succulent,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Groene bladeren; gele bloemen",
                    IsFlowering = true,
                    IsEvergreen = true, // Blijft groen in milde winters[1]
                    IsPoisonous = false,
                    Shape = "Laag, bodembedekkend, spreidend",
                    FullGrownHeight = 10,  // 5-15 cm[1]
                    FullGrownWidth = 30,   // 20-40 cm[1]
                    Light = "Volle zon tot lichte schaduw[1]",
                    Water = "Droogtebestendig, matig water geven[1]",
                    Soil = "Goed doorlatende, arme grond[1]",
                    FertilizationMethod = "Niet noodzakelijk, eventueel lichte bemesting in voorjaar[1]",
                    TrimmingInstructions = "Verwijder uitgebloeide bloemen en dode bladeren indien nodig[1]",
                    TrimmingPeriod = "Na de bloei of in het voorjaar",
                    TemperatureRangeMinimum = -20, // Winterhard[1]
                    TemperatureRangeMaximum = 35
                },

                // Sedum palmeri (Palmer’s stonecrop)
                new Plant
                {
                    Id = 48,
                    LocalName = "Sedum palmeri",
                    CommonName = "Palmer’s stonecrop",
                    Family = "Crassulaceae",
                    Genus = "Sedum",
                    Species = "palmeri",
                    Description = "Sierlijke, semi-wintergroene vetplant met lichtgroene, rozetvormige bladeren en gele bloemen in het vroege voorjaar. Geschikt voor potten, rotstuinen en als kamerplant in koudere klimaten.",
                    ImagePath = diskLocationImages + "Sedum_palmeri_Base01.png",
                    PlantType = PlantType.Succulent,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Lichtgroene bladeren; gele bloemen",
                    IsFlowering = true,
                    IsEvergreen = true, // Semi-wintergroen, afhankelijk van vorst[2]
                    IsPoisonous = false,
                    Shape = "Compact, rozetvormig, spreidend",
                    FullGrownHeight = 20,  // 10-25 cm[2]
                    FullGrownWidth = 30,   // 20-40 cm[2]
                    Light = "Volle zon tot halfschaduw[2]",
                    Water = "Matig water geven; verdraagt droogte[2]",
                    Soil = "Goed doorlatende, lichte grond[2]",
                    FertilizationMethod = "Lichte bemesting in het voorjaar[2]",
                    TrimmingInstructions = "Verwijder uitgebloeide bloemen en beschadigde bladeren[2]",
                    TrimmingPeriod = "Na de bloei of voorjaar",
                    TemperatureRangeMinimum = -5, // Matig winterhard, bescherming bij strenge vorst[2]
                    TemperatureRangeMaximum = 30
                },

                // Sedum sarmentosum (Stringy stonecrop)
                new Plant
                {
                    Id = 49,
                    LocalName = "Sedum sarmentosum",
                    CommonName = "Stringy stonecrop",
                    Family = "Crassulaceae",
                    Genus = "Sedum",
                    Species = "sarmentosum",
                    Description = "Sterk groeiende, bodembedekkende vetplant met dunne, liggende stengels en heldergele bloemen in de zomer. Zeer geschikt voor groene daken, rotstuinen en als bodembedekker.",
                    ImagePath = diskLocationImages + "Sedum_sarmentosum_Base01.png",
                    PlantType = PlantType.Succulent,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true, // Jonge scheuten soms gebruikt in Aziatische keuken, matig consumeren[3]
                    Color = "Groene bladeren; gele bloemen",
                    IsFlowering = true,
                    IsEvergreen = true, // Blijft groen in milde winters[3]
                    IsPoisonous = false,
                    Shape = "Uitlopervormend, bodembedekkend",
                    FullGrownHeight = 10,  // 5-15 cm[3]
                    FullGrownWidth = 60,   // 50-80 cm, sterk spreidend[3]
                    Light = "Volle zon tot halfschaduw[3]",
                    Water = "Droogtebestendig, weinig water nodig[3]",
                    Soil = "Lichte, goed doorlatende grond[3]",
                    FertilizationMethod = "Niet noodzakelijk, eventueel lichte bemesting in voorjaar[3]",
                    TrimmingInstructions = "Terugknippen indien te uitbundig groeit[3]",
                    TrimmingPeriod = "Voorjaar of na de bloei",
                    TemperatureRangeMinimum = -20, // Winterhard[3]
                    TemperatureRangeMaximum = 35
                }
                ,
                // Humulus japonicus (Japanese hop)
                new Plant
                {
                    Id = 50,
                    LocalName = "Humulus japonicus",
                    CommonName = "Japanese hop",
                    Family = "Cannabaceae",
                    Genus = "Humulus",
                    Species = "japonicus",
                    Description = "Krachtig groeiende, eenjarige klimplant met ruwe stengels en diep ingesneden, handvormige bladeren. Wordt soms als sierplant gebruikt, maar kan invasief zijn. Bloeit met kleine, groenachtige bloemen in de zomer.",
                    ImagePath = diskLocationImages + "Humulus_japonicus_Base01.png",
                    PlantType = PlantType.Climber,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Groene bladeren; groen-witte bloemen",
                    IsFlowering = true,
                    IsEvergreen = false,  // Eenjarige plant
                    IsPoisonous = false,  // Niet eetbaar maar niet giftig
                    Shape = "Klimplant, sterkgroeiend met uitlopers",
                    FullGrownHeight = 500,  // Kan 4 tot 6 meter hoog klimmen
                    FullGrownWidth = 100,   // Brede groei, afhankelijk van ondersteuning
                    Light = "Volle zon tot halfschaduw",
                    Water = "Normale vochtigheid; verdraagt geen langdurige droogte",
                    Soil = "Voedzame, goed doorlatende grond",
                    FertilizationMethod = "Bij rijke grond niet noodzakelijk; anders lichte bemesting in groeifase",
                    TrimmingInstructions = "Verwijder uitgebloeide stengels aan einde zomer; kan gesnoeid worden om controle te houden",
                    TrimmingPeriod = "Einde zomer of vroege herfst",
                    TemperatureRangeMinimum = -5,  // Zaad is winterhard; plant zelf is eenjarig
                    TemperatureRangeMaximum = 35
                }
                ,
                // Fuchsia magellanica (Hardy Fuchsia, Magellan Fuchsia)
                new Plant
                {
                    Id = 51,
                    LocalName = "Fuchsia magellanica",
                    CommonName = "Hardy Fuchsia",
                    Family = "Onagraceae",
                    Genus = "Fuchsia",
                    Species = "magellanica",
                    Description =
                        "Sterk groeiende, bladverliezende struik met sierlijk overhangende takken. Heeft smalle, groene bladeren met gezaagde rand en bloeit langdurig met talrijke, opvallende, langwerpige rood-paarse bloemen die hangend aan de stengels verschijnen van de vroege zomer tot aan de eerste nachtvorst. Aantrekkelijk voor bijen en kolibries. Zeer winterhard voor een Fuchsia.",
                    ImagePath = diskLocationImages + "Fuchsia_magellanica_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true, // Vruchten zijn eetbaar, maar weinig smaakvol[3]
                    Color = "Groene bladeren; rood met paarse bloemen",
                    IsFlowering = true,
                    IsEvergreen = false, // Bladverliezend, soms half-wintergroen in milde winters[5]
                    IsPoisonous = false,
                    Shape = "Opgaand, overhangend, breed spreidend",
                    FullGrownHeight = 300,  // Typisch 1-3 meter; tot 3,6 m bij gunstige omstandigheden[2][3][4][5]
                    FullGrownWidth = 200,   // Tot 2-3 meter breed[1][5]
                    Light = "Half-schaduw tot zon, verdraagt ook schaduw[5][4]",
                    Water = "Regelmatig water geven, matig vochtige grond[5]",
                    Soil = "Voedzame, goed doorlatende leem, zand of klei; pH neutraal tot licht zuur/alkalisch[5][7]",
                    FertilizationMethod = "Lichte bemesting in het voorjaar, compost kan de groei stimuleren",
                    TrimmingInstructions = "In het voorjaar oude en dode takken verwijderen, eventueel na vorst tot op korte stomp terugsnoeien voor compacte groei[5]",
                    TrimmingPeriod = "Vroeg voorjaar of na de bloei",
                    TemperatureRangeMinimum = -15, // Winterhard tot -15°C à -17°C[5]
                    TemperatureRangeMaximum = 35
                }
                ,
                // Callistemon citrinus (Crimson Bottlebrush)
                new Plant
                {
                    Id = 52,
                    LocalName = "Callistemon citrinus",
                    CommonName = "Crimson Bottlebrush",
                    Family = "Myrtaceae",
                    Genus = "Callistemon",
                    Species = "citrinus",
                    Description = "Decoratieve, groenblijvende struik met lancetvormige, aromatische bladeren en opvallende felrode, borstelvormige bloeiwijzen die verschijnen van het late voorjaar tot de nazomer. Bladeren verspreiden een citroengeur bij kneuzen. Wordt vaak als kuipplant gehouden in Nederland vanwege beperkte winterhardheid.",
                    ImagePath = diskLocationImages + "Callistemon_citrinus_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,
                    Color = "Groene aromatische bladeren; felrode bloemen",
                    IsFlowering = true,
                    IsEvergreen = true, // In warm klimaat; in koudere streken bladsemiwintergroen
                    IsPoisonous = false,
                    Shape = "Opgaande, bossige struik tot kleine boom",
                    FullGrownHeight = 300,  // Typisch 1–3 meter als struik
                    FullGrownWidth = 250,   // Tot 2-4 meter breed mogelijk
                    Light = "Volle zon, licht beschut",
                    Water = "Gemiddeld, geen natte grond, matig droogtetolerant na vestiging",
                    Soil = "Goed doorlatende, humusrijke, licht zure tot neutrale grond",
                    FertilizationMethod = "Lichte bemesting in het voorjaar; zuurminnende plantenvoeding aanbevolen",
                    TrimmingInstructions = "Direct na de bloei licht snoeien om compacte groei en rijke bloei te bevorderen; dode takken verwijderen",
                    TrimmingPeriod = "Na de bloei (late zomer of nazomer)",
                    TemperatureRangeMinimum = -5,   // Niet volledig winterhard, beschermen onder 0 °C 
                    TemperatureRangeMaximum = 40
                }
                ,
                // Nerium oleander (Oleander, Rosebay)
                new Plant
                {
                    Id = 53,
                    LocalName = "Nerium oleander",
                    CommonName = "Oleander",
                    Family = "Apocynaceae",
                    Genus = "Nerium",
                    Species = "oleander",
                    Description = "Wintergroene, sterk vertakte struik of kleine boom met leerachtige, lancetvormige, donkergroene bladeren. Bloeit in de zomer met opvallende trompetvormige bloemen in schermvormige trossen. Kleur varieert van wit tot roze, rood of soms geel. Zeer populair als sierstruik in mediterrane tuinen, parken en openbaar groen. Kan in een milde winter buiten overleven, maar is bij strenge vorst niet volledig winterhard.",
                    ImagePath = diskLocationImages + "Nerium_oleander_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false,  // Alle delen zijn giftig [1][2][3][6][8]
                    Color = "Groen blad; witte, roze, rode of geelachtige bloemen",
                    IsFlowering = true,
                    IsEvergreen = true,
                    IsPoisonous = true, // Sterk giftig bij inname en sappen kunnen huid irriteren [1][2][6][8]
                    Shape = "Bossige, opgaande struik, tot kleine boom te leiden",
                    FullGrownHeight = 600, // 2–6 m (7–20 ft), soms hoger in beschermde gebieden [1][2][3][7][8]
                    FullGrownWidth = 400,  // 2–4 m breed (kan net zo breed als hoog worden)
                    Light = "Volle zon tot lichte schaduw; beste bloei in volle zon",
                    Water = "Zeer droogte- en hittebestendig, maar groeit krachtiger bij regelmatige watergift",
                    Soil = "Goed doorlatende, humusrijke grond; verdraagt arme, zoute of kalkrijke bodem",
                    FertilizationMethod = "Voorjaarsmest (universeel of bloeiende planten); niet overbemesten",
                    TrimmingInstructions = "Regelmatig (licht) snoeien na de bloei voor compacte groei en vorm—draag handschoenen door giftige sap. Dode of bevroren takken in het voorjaar verwijderen.",
                    TrimmingPeriod = "Na de bloei, of vroege voorjaar (na kans op vorst)",
                    TemperatureRangeMinimum = -5, // Niet volledig winterhard, kan lichte nachtvorst aan
                    TemperatureRangeMaximum = 40
                }
                ,
                // Passiflora caerulea (Blue Passionflower)
                new Plant
                {
                    Id = 54,
                    LocalName = "Passiflora caerulea",
                    CommonName = "Blue Passionflower",
                    Family = "Passifloraceae",
                    Genus = "Passiflora",
                    Species = "caerulea",
                    Description = "Sterke, winterharde klimplant met diep ingesneden, handvormige bladeren en opvallende blauw-witte bloemen met een paars kroonkrans. Bloeit van zomer tot herfst. Vormt eetbare maar weinig smakelijke oranje bessen als de zomer warm genoeg is. Geschikt voor pergola's, muren en schuttingen.",
                    ImagePath = diskLocationImages + "Passiflora_caerulea_Base01.png",
                    PlantType = PlantType.Climber,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true, // Vrucht is eetbaar maar flauw; bladeren zijn niet eetbaar
                    Color = "Groene bladeren; blauw, wit en paars-blauwige bloemen; oranje vrucht",
                    IsFlowering = true,
                    IsEvergreen = false, // Meestal bladverliezend in NL
                    IsPoisonous = false, // Rijpe vrucht eetbaar, onrijpe en plantdelen liefst niet consumeren
                    Shape = "Klimplant met ranken, snelgroeiend",
                    FullGrownHeight = 600,  // Kan tot 6-10 meter hoog klimmen bij voldoende ondersteuning
                    FullGrownWidth = 300,   // Kan breed uitgroeien afhankelijk van steun en snoei
                    Light = "Zonnige, warme standplaats; verdraagt lichte schaduw",
                    Water = "Regelmatig water geven, goed doorlatende grond",
                    Soil = "Voedzame, humusrijke, goed doorlatende grond",
                    FertilizationMethod = "Voor- en najaarsbemesting voor uitbundige bloei",
                    TrimmingInstructions = "Terugsnoeien in het voorjaar, dode of zwakke takken verwijderen; groeit snel opnieuw uit.",
                    TrimmingPeriod = "Vroege voorjaar (maart-april)",
                    TemperatureRangeMinimum = -10, // Winterhard tot ca -10°C
                    TemperatureRangeMaximum = 35
                }
                ,
                // Hydrangea serrata (Mountain hydrangea, Tellar)
                new Plant
                {
                    Id = 55,
                    LocalName = "Hydrangea serrata",
                    CommonName = "Mountain hydrangea, Tellar",
                    Family = "Hydrangeaceae",
                    Genus = "Hydrangea",
                    Species = "serrata",
                    Description = "Compacte bladverliezende struik met ovaal tot eirond, gekarteld blad. Vormt prachtige, vlakke schermen met fijne, blauw, lavendel, roze tot rood gekleurde lacecap bloemen vanaf vroege zomer tot de herfst, afhankelijk van de zuurgraad van de grond. Goed winterhard, geschikt voor kleine tuinen, borders en potten. Van oorsprong uit de bergbossen van Japan en Korea. Bekend als 'tea of heaven', bladeren worden daar soms gebruikt voor zoete thee.",
                    ImagePath = diskLocationImages + "Hydrangea_serrata_Base01.png",
                    PlantType = PlantType.Shrub,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false, // Let op: alle plantdelen zijn licht giftig bij inname[1]
                    Color = "Groene bladeren; bloemen blauw, lavendel, roze of rood afhankelijk van pH",
                    IsFlowering = true,
                    IsEvergreen = false, // Bladverliezend
                    IsPoisonous = true, // Alle delen, inname geeft maagklachten[1]
                    Shape = "Rond, bossig, compact, laagblijvend",
                    FullGrownHeight = 120, // 60-150 cm (2-5 feet)[1][2][3][6]
                    FullGrownWidth = 120,  // 60-180 cm (2-6 feet)[1][2][3][6]
                    Light = "Halfschaduw tot zon (liefst ochtendzon, middag beschut tegen felle zon)",
                    Water = "Gemiddeld water, zorg voor vochtige, goed doorlatende grond",
                    Soil = "Kleigrond, leem of zand, humusrijk, licht zuur tot neutraal; geen natte voeten",
                    FertilizationMethod = "Voorjaarsbemesting; mulch van bladeren of schors houdt vocht vast",
                    TrimmingInstructions = "Na de bloei uitgebloeide bloemstengels terugsnoeien tot paar gezonde knoppen; dood of zwak hout in het vroege voorjaar verwijderen",
                    TrimmingPeriod = "Na de bloei of vroeg voorjaar",
                    TemperatureRangeMinimum = -25, // Winterhard tot -25°C (USDA 5-9)[1][6]
                    TemperatureRangeMaximum = 35
                }
                ,
                // Alnus glutinosa (Black Alder, Common Alder, European Alder)
                new Plant
                {
                    Id = 56,
                    LocalName = "Alnus glutinosa",
                    CommonName = "Black Alder, Common Alder, European Alder",
                    Family = "Betulaceae",
                    Genus = "Alnus",
                    Species = "glutinosa",
                    Description = "Middelgrote bladverliezende boom tot 30 meter hoog met een kegelvormige kroon en vaak meerdere stammen. De jonge twijgen en knoppen zijn kleverig, volwassen schors is donker en diep gegroefd. Ovaalronde, donkergroene bladeren met een getande rand; blijft opvallend lang groen in het najaar. Mannelijke (hangende) en vrouwelijke (staande, kegelvormige) katjes verschijnen vóór het uitlopen van het blad in het vroege voorjaar. Vruchtjes lijken op kleine kegeltjes die de hele winter aan de boom blijven. Bekend als pioniersboom op natte standplaatsen (oevers, moeras, beekdalen), waar hij o.a. stikstof bindende wortelknobbeltjes vormt.",
                    ImagePath = diskLocationImages + "Alnus_glutinosa_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false, // Niet eetbaar en licht toxisch bij inname
                    Color = "Donkergroene bladeren; purperen knoppen; bruinzwarte schors; katjes wisselend groen, rood tot bruin",
                    IsFlowering = true,  // Bloeit voor het uitlopen van het blad
                    IsEvergreen = false, // Bladverliezend
                    IsPoisonous = false, // Niet eetbaar, maar niet als sterk giftig beschreven
                    Shape = "Kegelvormige of brede boom met losse kroon; vaak meerstammig",
                    FullGrownHeight = 3000,  // 20–30 meter (soms tot 35 meter)[1][4][5]
                    FullGrownWidth = 1500,   // Kroon tot 10–15 meter breed[4]
                    Light = "Zon tot halfschaduw",
                    Water = "Vochtig tot nat; verdraagt tijdelijke overstromingen; groeit slecht op droge gronden",
                    Soil = "Vochtig, voedselrijk; klei, leem, veen, moeras; pH-neutraal tot licht zuur",
                    FertilizationMethod = "Geen bemesting nodig; fixeert zelf stikstof via wortelknobbeltjes",
                    TrimmingInstructions = "Snoei is meestal niet nodig; eventueel te lage of zieke takken in de winter weghalen",
                    TrimmingPeriod = "Late herfst of winter indien nodig",
                    TemperatureRangeMinimum = -35, // Winterhard tot USDA zone 3[6]
                    TemperatureRangeMaximum = 40
                }
                ,
                // Prunus armeniaca (Apricot, Armenian Plum)
                new Plant
                {
                    Id = 57,
                    LocalName = "Prunus armeniaca",
                    CommonName = "Apricot, Armenian Plum",
                    Family = "Rosaceae",
                    Genus = "Prunus",
                    Species = "armeniaca",
                    Description = "Kleine tot middelgrote, bladverliezende boom met een ronde, brede kroon en glanzend donkergroen, eirond blad met fijn gezaagde rand. Bloeit in het vroege voorjaar vóór het uitlopen van het blad met geurende witte tot roze bloemen. Later verschijnen eetbare, geel-oranje, soms rood getinte vruchten met sappig, zoet vlees. De boom is gevoelig voor vroege vorst vanwege de vroege bloei. Geschikt voor voedselbossen en (sier)tuinen met zonnige, beschutte standplaats.",
                    ImagePath = diskLocationImages + "Prunus_armeniaca_Base01.png",
                    PlantType = PlantType.Tree,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true, // Vrucht en (in kleine hoeveelheid, indien zoet) zaad eetbaar, let op bittere variant
                    Color = "Groen blad; witte tot roze bloemen; geel-oranje vruchten",
                    IsFlowering = true,
                    IsEvergreen = false, // Bladverliezend
                    IsPoisonous = true, // Zaden (pitten) bevatten amygdaline, giftig bij hoge inname[2][4]
                    Shape = "Rond tot breed spreidend, kleine tot middelgrote boom",
                    FullGrownHeight = 800,  // 4-8 (tot 12) meter[1][3][5][8]
                    FullGrownWidth = 600,   // 4-6 (tot 8) meter[3][8]
                    Light = "Volle zon; beste productie op open, zonnige plek",
                    Water = "Voorkeur voor vochtige maar goed doorlatende, enigszins kalkrijke grond; gevoelig voor staand water",
                    Soil = "Zand, leem of lichte klei, goed gedraineerd, matig voedselrijk, neutraal tot licht alkalisch",
                    FertilizationMethod = "Bemest met compost of organische mest in het vroege voorjaar",
                    TrimmingInstructions = "Regelmatig uitdunnen en vormsnoei na de oogst of in het voorjaar. Dood hout verwijderen. Let op kwetsbaarheid voor snoeiwonden.",
                    TrimmingPeriod = "Late zomer (na oogst) of vroege voorjaar (voor sapstroom)",
                    TemperatureRangeMinimum = -25, // Winterhard tot ca. -25 °C; vroege bloei kwetsbaar voor late nachtvorst[5][6]
                    TemperatureRangeMaximum = 40
                }
                ,
                // Acanthus mollis (Bear's breeches, Oyster plant)
                new Plant
                {
                    Id = 58,
                    LocalName = "Acanthus mollis",
                    CommonName = "Bear's breeches, Oyster plant",
                    Family = "Acanthaceae",
                    Genus = "Acanthus",
                    Species = "mollis",
                    Description = "Clump-forming, perennial herb native to the Mediterranean. Forms a bold rosette of large, glossy, dark green, lobed leaves up to 50cm long. Erect flowering spikes carry striking purplish and white tubular flowers in summer, sometimes reaching 1–2 meters tall. Valued as an architectural foliage plant and for its historical use in Greek and Roman sculpture. Spreads by creeping roots, can be long-lived and vigorous when established.",
                    ImagePath = diskLocationImages + "Acanthus_mollis_Base01.png",
                    PlantType = PlantType.HerbaceousPerennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false, // Ornamental; not considered edible
                    Color = "Glossy dark green leaves; flower spikes purple and white",
                    IsFlowering = true,
                    IsEvergreen = false, // Usually deciduous in colder climates, evergreen in mild ones[4][5]
                    IsPoisonous = false, // Not known as poisonous for humans or animals
                    Shape = "Clump-forming basal rosette; upright flower spikes",
                    FullGrownHeight = 120,  // 0.9–2 meters (usually 1–1.5 m)[2][3][4][7]
                    FullGrownWidth = 100,   // 0.5–1.5 meters, forms wide clumps[2][3][4][7]
                    Light = "Full sun to part shade; tolerates light shade",
                    Water = "Prefers moist but well-drained soil; avoid waterlogged soils",
                    Soil = "Fertile, humus-rich, well-drained soil; tolerates a range of soils except very wet or poor drainage",
                    FertilizationMethod = "Mulch in spring, light fertilizing in early growth. No special needs.",
                    TrimmingInstructions = "Remove spent flower spikes and dead leaves after flowering or in autumn. Divide clumps every few years to control spread.",
                    TrimmingPeriod = "Late summer to autumn; division in early spring",
                    TemperatureRangeMinimum = -10, // Hardy to approx. -10°C (USDA zone 7–10)[4]
                    TemperatureRangeMaximum = 35
                }
                ,
                // Hemerocallis (Daylily)
                new Plant
                {
                    Id = 59,
                    LocalName = "Hemerocallis",
                    CommonName = "Daylily",
                    Family = "Asphodelaceae",
                    Genus = "Hemerocallis",
                    Species = "", // Overkoepelende soort, vul specifieke soort/cultivar in indien gewenst
                    Description = "Sterk groeiende, bladverliezende vaste plant met breed uitlopende pollen van langwerpige, grasachtige bladeren. Bloeit van de vroege zomer tot in de herfst met opvallende, trechter- of stervormige bloemen in vele kleuren. Elke bloem bloeit slechts één dag, maar de bloei zet door dankzij voortdurende knopvorming. Zeer betrouwbaar, weinig eisend en zeer geschikt voor border, oever, talud en grote pot.",
                    ImagePath = diskLocationImages + "Hemerocallis_Base01.png",
                    PlantType = PlantType.HerbaceousPerennial,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true, // Bloemen en knoppen van veel soorten kunnen met mate gegeten worden, rauw, gefrituurd of geblancheerd[4]
                    Color = "Groene bladeren; bloemen in geel, oranje, rood, roze, paars, wit (afhankelijk van cultivar)",
                    IsFlowering = true,
                    IsEvergreen = false, // Meestal bladverliezend of half-wintergroen
                    IsPoisonous = false, // Niet giftig maar matig eten aanbevolen (laxeert)[4]
                    Shape = "Polvormende vaste plant met boogvormig afhangend loof en rechtopstaande bloeistengels",
                    FullGrownHeight = 90,   // 40–120 cm afhankelijk van soort/cultivar[2][3][7][10]
                    FullGrownWidth = 80,    // 50–100 cm in volwassen pol
                    Light = "Volle zon tot lichte schaduw (minimaal 6 uur zon voor beste bloei)[5][9][11][15]",
                    Water = "Vochtige, goed doorlatende bodem; niet nat of langdurig droog",
                    Soil = "Niet kieskeurig: leem, zand of klei, liefst voedzaam, pH neutraal tot lichtzuur",
                    FertilizationMethod = "Lichte bemesting in het voorjaar; organisch materiaal in border houden voor vitaliteit",
                    TrimmingInstructions = "Verwijder uitgebloeide bloemen en bloemstengels voor langere bloei; deel pollen elke 4–5 jaar",
                    TrimmingPeriod = "Na de bloei of vroege voorjaar (verdelen en opschonen)",
                    TemperatureRangeMinimum = -30, // Zeer winterhard, tot USDA zone 4–5[10]
                    TemperatureRangeMaximum = 35
                }
                ,
                // Portulaca oleracea (Common Purslane, Little Hogweed)
                new Plant
                {
                    Id = 60,
                    LocalName = "Portulaca oleracea",
                    CommonName = "Common Purslane, Little Hogweed, Pursley",
                    Family = "Portulacaceae",
                    Genus = "Portulaca",
                    Species = "oleracea",
                    Description = "A fast-growing, low, mat-forming annual succulent with smooth, reddish, often prostrate stems and fleshy, spoon-shaped green leaves. Produces small, yellow, five-petaled flowers (3–6 mm wide) and many-seeded capsules splitting open at maturity. Highly drought-tolerant and can thrive in poor soil; edible parts are tart and nutritious.",
                    ImagePath = diskLocationImages + "Portulaca_oleracea_Base01.png",
                    PlantType = PlantType.Succulent,
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = true, // Young stems, leaves, and seeds are edible, rich in omega-3 and vitamins[1][2][3]
                    Color = "Green succulent leaves; yellow flowers; reddish stems",
                    IsFlowering = true,
                    IsEvergreen = false, // Annual in most climates; can be perennial in frost-free zones[1]
                    IsPoisonous = false, // Not poisonous; widely eaten as salad/herb[1][3]
                    Shape = "Mat-forming, prostrate to ascending herb",
                    FullGrownHeight = 15,  // Typical height: 5–16 cm[1][3][8]
                    FullGrownWidth = 90,   // Can spread up to 30–90 cm (1–3 ft), forming wide mats[3][8][9]
                    Light = "Full sun (minimum 6 hours direct light)[2]",
                    Water = "Drought-tolerant; prefers well-drained soils but adapts to various moisture levels[1][2][3]",
                    Soil = "Not fussy—grows in clay, sand, loam, shallow and rocky soil with good drainage[2]",
                    FertilizationMethod = "Rarely needs fertilizer; will thrive on poor soils",
                    TrimmingInstructions = "Can be lightly trimmed to contain spread or harvest edible parts. Remove before seed set to control as a weed.",
                    TrimmingPeriod = "Anytime during rapid growth period, best before flowering for culinary use",
                    TemperatureRangeMinimum = 2,   // Hardy to about 2°C (frost will kill)[2][3]
                    TemperatureRangeMaximum = 40   // Grows best in warm, sunny locations[1][10]
                }
                ,
                // Calibrachoa 'Jaune' (Yellow Million Bells, Mini-petunia)
                new Plant
                {
                    Id = 63,
                    LocalName = "Calibrachoa 'Jaune'",
                    CommonName = "Yellow Million Bells, Mini-petunia",
                    Family = "Solanaceae",
                    Genus = "Calibrachoa",
                    Species = "", // Cultivar/hybride, soort kan leeg blijven voor cultivars
                    Description = "Compacte, eenjarige of kortlevende vaste plant met overhangende, licht rankende groeiwijze. Deze rijkbloeiende 'mini-petunia' produceert van het late voorjaar tot de eerste vorst talloze kleine, trompetvormige, helder gele bloemen. Door zijn standvastige bloei en compacte groei ideaal voor hangmanden, potten, balkonbakken en randen. Bladeren elliptisch tot ovaal, frisgroen, glad. Trekt bijen en vlinders.",
                    ImagePath = diskLocationImages + "Calibrachoa_Jaune_Base01.png",
                    PlantType = PlantType.HerbaceousPerennial, // Vaak als eenjarige gekweekt in NL
                    PlantClassification = PlantClassification.Angiosperms,
                    PhylumInfo = (Phylum)GetPhylumByName(phyla, "Magnoliophyta"),
                    IsEatable = false, // Niet eetbaar, uitsluitend sierwaarde[3]
                    Color = "Groene bladeren; felgele, kleine bloemen",
                    IsFlowering = true,
                    IsEvergreen = false, // Wordt in koud klimaat als eenjarige gekweekt[3]
                    IsPoisonous = false, // Niet giftig voor mens of huisdier[3]
                    Shape = "Compact opgaande tot breed overhangende pol; vaak kussen- of hangvormig",
                    FullGrownHeight = 25,  // Typisch 10–30 cm[1][3][9]
                    FullGrownWidth = 60,   // 30–60 cm spreiding (soms meer in pot/hanger)[1][9]
                    Light = "Volle zon tot lichte schaduw; beste bloei bij minimaal 6 uur zonlicht[2][7][17]",
                    Water = "Lichtvochtig tot matig droog; niet te nat, goed drainerend substraat[1][2][4][5]",
                    Soil = "Potgrond of tuingrond; liefst humusrijk, luchtig en goed doorlatend (liefst licht zuur tot neutraal)[1][2][3]",
                    FertilizationMethod = "Voor de uitplant een langwerkende meststof; daarna elke 2 weken vloeibare voeding voor bloeiende planten voor doorbloei[2][4][5]",
                    TrimmingInstructions = "Niet nodig; uitgebloeide bloemen vallen vanzelf af. Bij slap of langgroeiend exemplaar licht terugknippen voor vollere groei.[4][5]",
                    TrimmingPeriod = "Tijdens of direct na de bloeiperiode, indien nodig",
                    TemperatureRangeMinimum = 5, // Alleen perennif in zachte winters (zone 9+), niet winterhard in NL[1][3]
                    TemperatureRangeMaximum = 35
                }



            };
        }

        /// <summary>
        /// generate seeding in Dutch
        /// </summary>
        /// <param name="phyla"></param>
        /// <returns></returns>
        public static List<Plant> GetAllPlantsDutch(IEnumerable<Phylum> phyla)
        {

            return new List<Plant>
            {



            };
        }

        /// <summary>
        /// procedure that checks the genus, species, family of a plant and gets a set of example data
        /// --> this allows adding problems that are common for the family (e.g. if genus and species are left alone)
        /// --> or add for specic genus or plant
        /// </summary>
        /// <param name="genus"></param>
        /// <param name="species"></param>
        /// <param name="family"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal static List<PlantProblem> GetAllProblems(string family, string genus, string species)
        {

            List<PlantProblem> ListProblems = new List<PlantProblem>();

            // Example: Check if the genus is "Hydrangea" (Hortensia)
            if (genus == "Hydrangea" || (family == "Hydrangeaceae" && genus == string.Empty))
            {

                // Add the most common problems for Hortensia (Hydrangea genus)
                ListProblems.Add(new PlantProblem
                {
                    Id = 1,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery spots on leaves.",
                    Symptoms = "White powdery coating on leaves.",
                    Causes = "High humidity, poor air circulation.",
                    Solutions = "Improve air circulation, avoid overhead watering, use fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 2,
                    Name = "Aphids",
                    Description = "Sap-sucking insects that distort leaves and reduce flowering.",
                    Symptoms = "Distorted leaves, sticky residue (honeydew).",
                    Causes = "Warm weather, new growth.",
                    Solutions = "Spray with insecticidal soap or neem oil, encourage beneficial insects.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 3,
                    Name = "Leaf Spot (Cercospora)",
                    Description = "Fungal disease causing brown or black spots on leaves.",
                    Symptoms = "Brown or black spots, leaf drop.",
                    Causes = "Wet foliage, high humidity.",
                    Solutions = "Remove affected leaves, avoid wetting foliage, apply fungicide if severe.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 4,
                    Name = "Root Rot",
                    Description = "Fungal infection due to soggy soil.",
                    Symptoms = "Wilting, yellowing, stunted growth.",
                    Causes = "Poor drainage, overwatering.",
                    Solutions = "Improve drainage, avoid overwatering, repot if needed.",
                    Severity = "High",
                    Category = "Disease"
                });
                ListProblems.Add(new PlantProblem
                {
                    Id = 5,
                    Name = "Incorrect Pruning",
                    Description = "Pruning at the wrong time or in the wrong way can result in little to no flowering.",
                    Symptoms = "Few or no flowers, abnormal growth, loss of flower buds.",
                    Causes = "Pruning too hard on species that flower on old wood, or pruning at the wrong time of year.",
                    Solutions = "Only prune if necessary and always at the right time. Lightly correct old wood bloomers in spring. Cut back new wood bloomers to a few buds above the ground in early spring.",
                    Severity = "Medium",
                    Category = "Maintenance"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 6,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients can lead to poor growth and flowering.",
                    Symptoms = "Yellowing leaves, poor growth, small or few flowers.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer regularly, preferably in spring.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 7,
                    Name = "Nutrient Excess (Overfertilization)",
                    Description = "Overfertilization can damage roots and weaken the plant.",
                    Symptoms = "Leaf burn, poor growth, discolored leaves.",
                    Causes = "Too much fertilizer or the wrong type.",
                    Solutions = "Fertilize less, always according to the package instructions.",
                    Severity = "Medium",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 8,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth, diseases, and little flowering.",
                    Symptoms = "Weak growth, few flowers, susceptibility to diseases and pests.",
                    Causes = "Too little water, too much or too little pruning, no fertilization, not removing dead wood.",
                    Solutions = "Water regularly, prune at the right time, fertilize, remove dead wood, and check for diseases and pests.",
                    Severity = "Low",
                    Category = "Maintenance"
                });


            }

            // Example: Check if the genus is "Nandina" (Heavenly Bamboo)
            if (genus == "Nandina" || (family == "Berberidaceae" && genus == string.Empty))
            {
                // Add the most common problems for Nandina domestica
                ListProblems.Add(new PlantProblem
                {
                    Id = 9,
                    Name = "Leaf Spot Diseases",
                    Description = "Fungal or bacterial leaf spots can occur on Nandina.",
                    Symptoms = "Brown or black spots on leaves, yellowing, leaf drop.",
                    Causes = "High humidity, wet foliage, poor air circulation.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if severe.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 10,
                    Name = "Root Rot",
                    Description = "Fungal infection due to soggy soil.",
                    Symptoms = "Wilting, yellowing, stunted growth.",
                    Causes = "Poor drainage, overwatering.",
                    Solutions = "Improve drainage, avoid overwatering, repot if needed.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 11,
                    Name = "Aphids",
                    Description = "Sap-sucking insects that distort leaves and reduce plant vigor.",
                    Symptoms = "Distorted leaves, sticky residue (honeydew), sooty mold.",
                    Causes = "Warm weather, new growth.",
                    Solutions = "Spray with insecticidal soap or neem oil, encourage beneficial insects.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 12,
                    Name = "Scale Insects",
                    Description = "Scale insects can infest stems and leaves of Nandina.",
                    Symptoms = "Brown or white bumps on stems and leaves, yellowing, leaf drop.",
                    Causes = "Poor plant health, lack of natural predators.",
                    Solutions = "Remove with a soft brush or cotton swab dipped in alcohol, apply horticultural oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 13,
                    Name = "Incorrect Pruning",
                    Description = "Pruning at the wrong time or too hard can damage the plant and reduce fruiting.",
                    Symptoms = "Poor growth, reduced fruiting, irregular shape.",
                    Causes = "Pruning too hard or at the wrong time of year.",
                    Solutions = "Prune lightly after flowering, avoid heavy pruning, shape in late winter if needed.",
                    Severity = "Low",
                    Category = "Maintenance"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 14,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients can lead to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer in spring, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 15,
                    Name = "Drought Stress",
                    Description = "Nandina can tolerate some drought but prolonged dry periods cause stress.",
                    Symptoms = "Wilting, leaf drop, brown leaf edges.",
                    Causes = "Lack of water, hot weather.",
                    Solutions = "Water deeply during dry periods, mulch to retain soil moisture.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 16,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, few flowers or fruits, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead wood.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Carpinus" and species is "betulus" (Hornbeam)
            if (genus == "Carpinus" && species == "betulus")
            {
                // Add the most common problems for Carpinus betulus (Hornbeam)
                ListProblems.Add(new PlantProblem
                {
                    Id = 17,
                    Name = "Leaf Spot (Fungal Disease)",
                    Description = "Fungal leaf spots can occur, especially in wet conditions.",
                    Symptoms = "Brown or black spots on leaves, yellowing, premature leaf drop.",
                    Causes = "High humidity, wet foliage, poor air circulation.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if severe.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 18,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves.",
                    Symptoms = "White powdery spots on leaves, stunted growth.",
                    Causes = "Poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 19,
                    Name = "Aphids",
                    Description = "Sap-sucking insects that can distort new growth.",
                    Symptoms = "Distorted leaves, sticky residue (honeydew), sooty mold.",
                    Causes = "Warm weather, new growth.",
                    Solutions = "Spray with insecticidal soap or neem oil, encourage beneficial insects.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 20,
                    Name = "Root Rot",
                    Description = "Fungal infection due to soggy soil.",
                    Symptoms = "Wilting, yellowing, stunted growth.",
                    Causes = "Poor drainage, overwatering.",
                    Solutions = "Improve drainage, avoid overwatering, repot if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 21,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients can lead to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer in spring, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 22,
                    Name = "Drought Stress",
                    Description = "Hornbeam prefers consistent moisture; prolonged dry periods can cause stress.",
                    Symptoms = "Wilting, leaf drop, brown leaf edges.",
                    Causes = "Lack of water, hot weather.",
                    Solutions = "Water deeply during dry periods, mulch to retain soil moisture.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 23,
                    Name = "Mechanical Injury",
                    Description = "Damage from lawn mowers, trimmers, or animals.",
                    Symptoms = "Wounds on trunk or branches, bark damage.",
                    Causes = "Physical impact, improper equipment use.",
                    Solutions = "Protect trunk with guards, avoid close mowing, proper pruning techniques.",
                    Severity = "Low",
                    Category = "Physical Damage"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 24,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, few flowers or fruits, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead wood.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Fagus" and species is "sylvatica" (European Beech)
            if (genus == "Fagus" && species == "sylvatica")


            {
                // Add the most common problems for Fagus sylvatica (European Beech)
                ListProblems.Add(new PlantProblem
                {
                    Id = 25,
                    Name = "Beech Woolly Aphid (Phyllaphis fagi)",
                    Description = "Sap-sucking aphid specific to beech, causes white fluffy patches on leaves and exudes honeydew.",
                    Symptoms = "White, woolly patches on undersides of leaves, sticky honeydew, sooty mold.",
                    Causes = "Presence of the aphid, new growth, lack of natural predators.",
                    Solutions = "Encourage natural predators, wash off with water, use insecticidal soap if severe.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 26,
                    Name = "Beech Bark Disease",
                    Description = "Complex involving scale insects and fungal pathogens, leading to cankers and dieback.",
                    Symptoms = "White woolly patches on trunk, cankers, dieback, 'beech snap' in wind.",
                    Causes = "Infestation by beech scale (Cryptococcus fagisuga), followed by Nectria fungi infection.",
                    Solutions = "Maintain tree health, avoid wounds, monitor for scale, use preventive treatments if available.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 27,
                    Name = "Beech Leaf Disease (BLD)",
                    Description = "Disease caused by the foliar nematode Litylenchus crenatae, affecting leaf and bud development.",
                    Symptoms = "Interveinal banding, distorted, leathery or small leaves, thin canopy, bud damage.",
                    Causes = "Infection by Litylenchus crenatae nematode, unknown epidemiology.",
                    Solutions = "Monitor, remove affected material, consult certified arborist for high-value trees.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 28,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves.",
                    Symptoms = "White powdery spots on leaves, stunted growth.",
                    Causes = "Poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 29,
                    Name = "Frost Damage",
                    Description = "Late spring frosts can damage new growth, especially in hedges.",
                    Symptoms = "Brown, shriveled new growth, secondary growth appears later.",
                    Causes = "Late spring frost after leaf emergence.",
                    Solutions = "No direct remedy; new growth usually recovers.",
                    Severity = "Low",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 30,
                    Name = "Honey Fungus (Armillaria mellea)",
                    Description = "Root and butt rot caused by a fungal pathogen.",
                    Symptoms = "Dieback, reduced vigor, white fungal growth under bark, mushrooms at base.",
                    Causes = "Infection by Armillaria mellea, often in stressed trees.",
                    Solutions = "Remove infected material, improve tree health, avoid stress.",
                    Severity = "Medium",
                    Category = "Disease"
                });



                // If you want to support species-specific problems, you can add checks like:
                // if (species == "macrophylla") { ... }

                return ListProblems;
            }

            // Example: Check if the genus is "Platanus" and species is "acerifolia" (London Plane)
            if (genus == "Platanus" && species == "acerifolia")
            {
                // Add the most common problems for Platanus acerifolia (London Plane)
                ListProblems.Add(new PlantProblem
                {
                    Id = 34,
                    Name = "Canker Stain (Ceratocystis platani/fimbriata f.sp. platani)",
                    Description = "A lethal fungal disease causing cankers and rapid decline or death of the tree.",
                    Symptoms = "Sparse foliage, small leaves, elongated cankers on branches and trunk, bluish-black or reddish-brown wood under cankers, water sprouts below cankers, eventual tree death.",
                    Causes = "Fungal infection through wounds, pruning, or mechanical injury.",
                    Solutions = "Avoid pruning in active infection periods, sterilize tools, remove and destroy infected material, monitor for symptoms.",
                    Severity = "High",
                    Category = "Disease",
                    ImagePath = diskLocationImages + "PlantProblems\\" + "Platanus_acerifolia_Canker_Stain_01.png"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 35,
                    Name = "Massaria Disease (Splanchnonema platani)",
                    Description = "Fungal disease causing large lesions on upper branches, leading to branch dieback.",
                    Symptoms = "Large lesions on upper branches, sometimes with orange spore masses, branch dieback.",
                    Causes = "Fungal infection, often in urban environments.",
                    Solutions = "Regular tree inspection, remove affected branches, maintain tree health.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 36,
                    Name = "Anthracnose (Apiognomonia veneta)",
                    Description = "Fungal disease causing leaf and twig blight, more severe in cool, wet springs.",
                    Symptoms = "Twig blight, bud blight, shoot blight, leaf blight, crinkling and browning of leaves, witches' broom growth.",
                    Causes = "Fungal spores spread by rain and wind, survives on fallen leaves and twigs.",
                    Solutions = "Improve air circulation, remove fallen leaves and twigs, apply fungicide if severe.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 37,
                    Name = "Powdery Mildew (Erysiphe platani)",
                    Description = "Fungal disease affecting young leaves and shoots, causing white powdery coating.",
                    Symptoms = "White powdery mat on leaves, desiccation and death of new growth.",
                    Causes = "Fungal infection, especially in humid conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 38,
                    Name = "Sycamore Lace Bug",
                    Description = "Insect pest feeding on leaf undersides, causing stippling and discoloration.",
                    Symptoms = "Yellow stippling on upper leaf surfaces, black spots of excrement on undersides, leaf drop in severe cases.",
                    Causes = "Infestation by Corythucha ciliata.",
                    Solutions = "Encourage natural predators, wash off with water, use insecticidal soap if severe.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 39,
                    Name = "Borers and Scales",
                    Description = "Various borers and scale insects can infest the tree, causing localized damage.",
                    Symptoms = "Holes in bark, oozing sap, weakened branches, scale insects visible on bark.",
                    Causes = "Infestation by borers or scale insects, often in stressed trees.",
                    Solutions = "Maintain tree health, remove affected branches, use insecticidal treatments if severe.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 40,
                    Name = "Drought Stress",
                    Description = "Extended dry periods can stress the tree, especially young specimens.",
                    Symptoms = "Wilting, leaf drop, reduced growth.",
                    Causes = "Insufficient water, hot weather.",
                    Solutions = "Water deeply during dry periods, mulch to retain soil moisture.",
                    Severity = "Low",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 41,
                    Name = "Mechanical Injury",
                    Description = "Damage from lawn mowers, trimmers, or vehicles can cause wounds and invite disease.",
                    Symptoms = "Wounds on trunk or branches, bark damage.",
                    Causes = "Physical impact, improper equipment use.",
                    Solutions = "Protect trunk with guards, avoid close mowing, proper pruning techniques.",
                    Severity = "Low",
                    Category = "Physical Damage"
                });
            }

            // Example: Check if the genus is "Malus" and species is "domestica" (Apple)
            if (genus == "Malus" && species == "domestica")
            {
                // Add the most common problems for Malus domestica (Apple tree)
                ListProblems.Add(new PlantProblem
                {
                    Id = 42,
                    Name = "Apple Scab",
                    Description = "Fungal disease causing dark, scabby lesions on leaves and fruit.",
                    Symptoms = "Dark spots on leaves, fruit; premature leaf drop, fruit deformation.",
                    Causes = "Fungus (Venturia inaequalis), wet conditions.",
                    Solutions = "Remove fallen leaves, use resistant varieties, apply fungicide if needed.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 43,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves and shoots.",
                    Symptoms = "White powdery spots on leaves, distorted growth.",
                    Causes = "Fungus (Podosphaera leucotricha), humid conditions.",
                    Solutions = "Improve air circulation, prune infected shoots, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 44,
                    Name = "Fire Blight",
                    Description = "Bacterial disease causing wilting, blackening of shoots and branches.",
                    Symptoms = "Blackened, wilted shoots; oozing from infected areas.",
                    Causes = "Bacteria (Erwinia amylovora), warm wet weather.",
                    Solutions = "Prune out infected branches, sterilize tools, use resistant varieties.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 45,
                    Name = "Cedar Apple Rust",
                    Description = "Fungal disease causing yellow-orange spots on leaves and fruit.",
                    Symptoms = "Yellow-orange spots on leaves, fruit; premature leaf drop.",
                    Causes = "Fungus (Gymnosporangium juniperi-virginianae), requires juniper as alternate host.",
                    Solutions = "Remove nearby junipers, use resistant varieties, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 46,
                    Name = "Rosy Apple Aphid",
                    Description = "Aphid pest causing curled, distorted leaves and reduced growth.",
                    Symptoms = "Curled, yellow-green leaves, sticky honeydew, sooty mold.",
                    Causes = "Infestation by Dysaphis plantaginea.",
                    Solutions = "Encourage natural predators, spray with insecticidal soap if severe.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 47,
                    Name = "Bitter Rot",
                    Description = "Fungal disease causing sunken, brown lesions on fruit.",
                    Symptoms = "Sunken brown spots on fruit, often with concentric rings.",
                    Causes = "Fungus (Glomerella cingulata, Colletotrichum gloeosporioides), warm wet weather.",
                    Solutions = "Remove infected fruit, improve air circulation, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 48,
                    Name = "Crown Gall",
                    Description = "Bacterial disease causing tumor-like growths on roots and trunk.",
                    Symptoms = "Round, rough swellings on roots and lower trunk.",
                    Causes = "Bacteria (Agrobacterium tumefaciens), enters through wounds.",
                    Solutions = "Remove infected plants, avoid wounding, use disease-free stock.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 49,
                    Name = "Codling Moth",
                    Description = "Insect pest causing wormy apples.",
                    Symptoms = "Larvae tunnel into fruit, leaving brown excrement at entry hole.",
                    Causes = "Infestation by larvae of Cydia pomonella.",
                    Solutions = "Monitor with traps, apply insecticides at appropriate times, remove infested fruit.",
                    Severity = "High",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 50,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients can lead to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer in spring, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 51,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead wood.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Alnus" and species is "glutinosa" (Common Alder)
            if (genus == "Alnus" && species == "glutinosa")
            {
                // Add the most common problems for Alnus glutinosa (Common Alder)
                ListProblems.Add(new PlantProblem
                {
                    Id = 52,
                    Name = "Phytophthora Root and Collar Rot (Phytophthora × alni)",
                    Description = "A devastating waterborne disease causing root and collar rot, bark necrosis, and dieback.",
                    Symptoms = "Small, yellow, sparse leaves; premature leaf fall; branch dieback; bark necrosis; bleeding cankers; increased cone production; tree mortality.",
                    Causes = "Infection by Phytophthora × alni, especially in wet soils or near water.",
                    Solutions = "Remove infected trees; avoid planting in waterlogged areas; monitor for symptoms; consider resistant varieties if available.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 53,
                    Name = "Alder Yellows (Phytoplasma)",
                    Description = "Bacterial disease causing yellowing, stunted growth, and dieback.",
                    Symptoms = "Yellowing leaves, stunted growth, reduced leaf size and number, dieback, death.",
                    Causes = "Infection by phytoplasma bacterial parasite.",
                    Solutions = "Remove infected trees; monitor for symptoms; no effective chemical control.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 54,
                    Name = "Alder Tongue Gall (Taphrina alni)",
                    Description = "Fungal disease causing tongue-like galls on female catkins.",
                    Symptoms = "Green-red elongated galls on female catkins.",
                    Causes = "Infection by Taphrina alni fungus.",
                    Solutions = "Remove and destroy affected catkins if severe; generally not harmful to the tree.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 55,
                    Name = "Leaf Spot and Stem Canker (Septoria alnifolia)",
                    Description = "Fungal disease causing leaf spots, stem cankers, and stem breakage.",
                    Symptoms = "Leaf spots, stem cankers, stem breakage.",
                    Causes = "Infection by Septoria alnifolia fungus.",
                    Solutions = "Remove and destroy affected parts; improve air circulation.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 56,
                    Name = "Rust (Melampsoridium hiratsukanum)",
                    Description = "Fungal disease causing yellow-brown spots on leaves and early leaf fall.",
                    Symptoms = "Yellow-brown spots on leaves, early leaf fall, crown thinning, death in severe cases.",
                    Causes = "Infection by Melampsoridium hiratsukanum fungus.",
                    Solutions = "Remove and destroy affected leaves; apply fungicide if severe.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 57,
                    Name = "Leaf Blotch (Mycopappus alni)",
                    Description = "Fungal disease causing brown blotches on leaves and defoliation.",
                    Symptoms = "Brown blotches on leaves, defoliation.",
                    Causes = "Infection by Mycopappus alni fungus.",
                    Solutions = "Remove and destroy affected leaves; improve air circulation.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 58,
                    Name = "Bark Canker (Erwinia alni)",
                    Description = "Bacterial disease causing bark cankers, bleeding, and branch or tree death.",
                    Symptoms = "Bark cankers, bleeding, branch or tree death.",
                    Causes = "Infection by Erwinia alni bacteria.",
                    Solutions = "Remove and destroy affected branches; no effective chemical control.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 59,
                    Name = "Waterlogging",
                    Description = "Excessive soil moisture can stress and weaken trees.",
                    Symptoms = "Poor growth, yellowing leaves, root rot, dieback.",
                    Causes = "Prolonged waterlogging or flooding.",
                    Solutions = "Improve drainage; avoid planting in poorly drained sites.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 60,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients can lead to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer in spring, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 61,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead wood.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Tulipa" and species is "gesneriana" (Garden Tulip)
            if (genus == "Tulipa" && species == "gesneriana")
            {
                // Add the most common problems for Tulipa gesneriana (Garden Tulip)
                ListProblems.Add(new PlantProblem
                {
                    Id = 62,
                    Name = "Tulip Fire (Botrytis Blight)",
                    Description = "Fungal disease caused by Botrytis tulipae, attacking all parts of the plant; most common and serious tulip disease.",
                    Symptoms = "Spots on leaves, flowers, and stems; distorted growth; fuzzy gray mold; plant collapse.",
                    Causes = "Fungus spreads by air and water; thrives in cool, damp conditions.",
                    Solutions = "Remove and destroy infected plants; improve air circulation; avoid overhead watering; apply fungicide if needed[1][4][7].",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 63,
                    Name = "Rhizoctonia Disease",
                    Description = "Fungal disease causing bulb and stem rot; leads to bare patches and poor emergence.",
                    Symptoms = "Bare patches in plantings; retarded growth; leaf blight; lesions on stem; bulb rot.",
                    Causes = "Infection by Rhizoctonia solani or R. tuliparum; thrives in cool, wet soils[4].",
                    Solutions = "Remove and destroy infected plants; rotate crops; improve soil drainage; avoid planting in infested soil.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 64,
                    Name = "Tulip Breaking Virus (TBV)",
                    Description = "Viral disease causing color breaking (stripes) in flowers and reduced vigor.",
                    Symptoms = "Striped or mottled flower color; stunted growth; distorted leaves[5][6].",
                    Causes = "Transmitted by aphids; virus infects plant cells.",
                    Solutions = "Remove and destroy infected plants; control aphids; buy virus-free bulbs.",
                    Severity = "Medium",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 65,
                    Name = "Other Viral Diseases",
                    Description = "Includes Tulip Virus X, Tobacco Rattle Virus (TRV), and Tobacco Necrosis Virus (TNV).",
                    Symptoms = "Mosaic, yellowing, malformation of leaves and flowers[4][6].",
                    Causes = "Transmitted by soil-borne fungi, nematodes, or mechanical means.",
                    Solutions = "Remove infected plants; control vectors; use virus-free planting material.",
                    Severity = "Low",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 66,
                    Name = "Fusarium Bulb Rot",
                    Description = "Fungal disease causing bulb rot and plant decline.",
                    Symptoms = "Soft, rotten bulbs; poor growth; wilting; plant collapse.",
                    Causes = "Infection by Fusarium oxysporum f.sp. tulipae; thrives in warm, wet soils[4][7].",
                    Solutions = "Remove and destroy infected bulbs; improve soil drainage; avoid overwatering.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 67,
                    Name = "Pythium Bulb Rot",
                    Description = "Fungal disease causing bulb and root rot.",
                    Symptoms = "Soft, rotten bulbs; poor root development; wilting; plant collapse.",
                    Causes = "Infection by Pythium spp.; thrives in wet, poorly drained soils[4].",
                    Solutions = "Remove and destroy infected bulbs; improve soil drainage; avoid overwatering.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 68,
                    Name = "Penicillium Bulb Rot",
                    Description = "Fungal disease causing bulb rot during storage.",
                    Symptoms = "Soft, rotten bulbs; blue-green mold on bulbs; poor growth.",
                    Causes = "Infection by Penicillium spp.; thrives in humid storage conditions[4].",
                    Solutions = "Store bulbs in cool, dry conditions; discard infected bulbs.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 69,
                    Name = "Poor Flowering",
                    Description = "Reduced or absent flowering, stunted growth.",
                    Symptoms = "No flowers; small or deformed leaves; weak plants[2][3].",
                    Causes = "Poor soil, insufficient chilling, overcrowding, bulb exhaustion, or disease.",
                    Solutions = "Plant in well-drained soil; ensure adequate chilling; avoid overcrowding; replace bulbs every few years.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 70,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients can lead to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer in spring, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 71,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, remove dead foliage, fertilize as needed.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Narcissus" and species is "pseudonarcissus" (Wild Daffodil)
            if (genus == "Narcissus" && species == "pseudonarcissus")
            {
                // Add the most common problems for Narcissus pseudonarcissus (Wild Daffodil)
                ListProblems.Add(new PlantProblem
                {
                    Id = 72,
                    Name = "Narcissus Bulb Fly",
                    Description = "Larvae of the narcissus bulb fly tunnel into bulbs, causing rot and plant death.",
                    Symptoms = "Chewed foliage, stunted growth, soft or rotting bulbs, plant collapse[1][6][5].",
                    Causes = "Infestation by Merodon equestris larvae.",
                    Solutions = "Remove and destroy infested bulbs; use protective mesh; avoid planting near infested sites.",
                    Severity = "High",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 73,
                    Name = "Bulb Rot (Basal Rot)",
                    Description = "Fungal disease causing bulb decay, often in wet conditions.",
                    Symptoms = "Moldy or rotting bulbs, yellowing leaves, stunted growth, plant collapse[1][6][5].",
                    Causes = "Infection by Fusarium oxysporum f. sp. narcissi; thrives in wet, poorly drained soils.",
                    Solutions = "Remove and destroy infected bulbs; improve soil drainage; avoid overwatering.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 74,
                    Name = "Bulb Mites",
                    Description = "Tiny mites that infest bulbs, causing damage and secondary infections.",
                    Symptoms = "Bulb damage, poor growth, secondary fungal or bacterial infections[1][5][6].",
                    Causes = "Infestation by Rhizoglyphus or other bulb mite species.",
                    Solutions = "Remove and destroy infested bulbs; use clean planting material; avoid overcrowding.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 75,
                    Name = "Viral Diseases",
                    Description = "Several viruses can infect daffodils, including Narcissus yellow stripe virus and Narcissus white streak virus.",
                    Symptoms = "Yellow or white streaks on leaves, reduced flower size, stunted growth[3][6].",
                    Causes = "Virus transmission by aphids or handling; slow spread in the field.",
                    Solutions = "Remove and destroy infected plants; control aphids; use virus-free bulbs.",
                    Severity = "Medium",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 76,
                    Name = "Slugs and Snails",
                    Description = "Mollusks that chew on leaves and flowers, especially in damp conditions.",
                    Symptoms = "Chewed foliage, slime trails, reduced vigor[5].",
                    Causes = "Presence of slugs or snails, damp environments.",
                    Solutions = "Handpick at night, use barriers or molluscicides, reduce mulch and debris.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 77,
                    Name = "Contact Dermatitis",
                    Description = "Skin irritation from handling bulbs or foliage, especially for sensitive individuals.",
                    Symptoms = "Dryness, fissures, scaling, erythema of skin; may include vesicles and pustules[2][7].",
                    Causes = "Contact with plant sap containing irritant alkaloids.",
                    Solutions = "Wear gloves and protective clothing when handling; wash skin after contact.",
                    Severity = "Low",
                    Category = "Human Health"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 78,
                    Name = "Poor Flowering",
                    Description = "Reduced or absent flowering, often due to cultural issues.",
                    Symptoms = "No flowers, weak or sparse foliage[1][5].",
                    Causes = "Overcrowding, nutrient deficiency, insufficient chilling, bulb exhaustion.",
                    Solutions = "Divide bulbs every few years; apply balanced fertilizer; ensure proper planting depth.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 79,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients can lead to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer in spring, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 80,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of division, no fertilization.",
                    Solutions = "Water regularly, divide bulbs as needed, fertilize in spring.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Quercus" and species is "robur" (English Oak)
            if (genus == "Quercus" && species == "robur")
            {
                // Add the most common problems for Quercus robur (English Oak)
                ListProblems.Add(new PlantProblem
                {
                    Id = 81,
                    Name = "Oak Wilt",
                    Description = "A deadly fungal disease causing rapid decline and death by blocking the tree’s vascular system.",
                    Symptoms = "Wilting, browning leaves that may fall prematurely, fungal mats beneath the bark, rapid tree death[3][5][6].",
                    Causes = "Infection by Bretziella fagacearum (formerly Ceratocystis fagacearum), spread by beetles or root grafts.",
                    Solutions = "Avoid pruning during the growing season, trench around infected trees to prevent root spread, consult an arborist.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 82,
                    Name = "Acute Oak Decline",
                    Description = "A bacterial disease causing rapid deterioration, often within a few years.",
                    Symptoms = "Weeping lesions from cracks in the bark, rapid dieback, death in 4–5 years[2][7][8].",
                    Causes = "Bacterial infection (multiple species), environmental stress, insect activity.",
                    Solutions = "Monitor for symptoms, maintain tree health, consult professionals for management.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 83,
                    Name = "Chronic Oak Decline",
                    Description = "Progressive deterioration over many years, often linked to multiple factors.",
                    Symptoms = "Twig and branch dieback, pale and smaller leaves, ‘staghead’ effect, slow decline[2][7][8].",
                    Causes = "Multiple pests, diseases, and environmental factors.",
                    Solutions = "Maintain tree health, reduce stress, monitor for symptoms.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 84,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves, reducing photosynthesis.",
                    Symptoms = "White powdery residue on leaves, impaired growth, leaf drop[3][8][1].",
                    Causes = "Infection by Erysiphe spp., thrives in humid conditions.",
                    Solutions = "Improve air circulation, remove affected leaves, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 85,
                    Name = "Oak Anthracnose",
                    Description = "Fungal disease causing dark, sunken lesions on leaves and premature leaf drop.",
                    Symptoms = "Brown spots on leaves, cupping or distortion, leaf drop[5][6][1].",
                    Causes = "Infection by Apiognomonia quercina, thrives in cool, wet weather.",
                    Solutions = "Prune affected branches, ensure good air circulation, remove fallen leaves.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 86,
                    Name = "Armillaria Root Rot (Honey Fungus)",
                    Description = "Fungal disease causing root and lower trunk decay, leading to tree decline.",
                    Symptoms = "White fungal mats under bark, dark shoestring-like rhizomorphs, dead limbs, tree collapse[2][6][1].",
                    Causes = "Infection by Armillaria spp., often in stressed trees.",
                    Solutions = "Remove infected trees, improve drainage, avoid wounding, maintain tree health.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 87,
                    Name = "Phytophthora Root Rot",
                    Description = "Oomycete pathogen causing root rot and tree decline.",
                    Symptoms = "Root decay, reduced vigor, dieback, increased susceptibility to other stresses[2][4][1].",
                    Causes = "Infection by Phytophthora spp., thrives in poorly drained soils.",
                    Solutions = "Improve drainage, avoid overwatering, remove infected material.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 88,
                    Name = "Bacterial Leaf Scorch",
                    Description = "Bacterial disease causing leaf margins to turn brown and dry out.",
                    Symptoms = "Brown, dry leaf margins, premature leaf drop[5][6][1].",
                    Causes = "Infection by Xylella fastidiosa, spread by leafhoppers and spittlebugs.",
                    Solutions = "Promote tree vigor, manage insect vectors, consult professionals for diagnosis.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 89,
                    Name = "Wood-Boring Beetles",
                    Description = "Insect pests that tunnel into wood, weakening branches and trunks.",
                    Symptoms = "Holes in bark, sawdust, branch dieback, structural weakness[2][3][5].",
                    Causes = "Infestation by various beetle species, often in stressed trees.",
                    Solutions = "Maintain tree health, monitor for signs, use pheromone traps if needed.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 90,
                    Name = "Drought and Environmental Stress",
                    Description = "Prolonged dry periods and environmental factors can weaken trees.",
                    Symptoms = "Wilting, leaf scorch, reduced growth, increased susceptibility to pests and diseases[2][3][6].",
                    Causes = "Lack of water, extreme temperatures, soil compaction.",
                    Solutions = "Water deeply during dry periods, mulch to retain moisture, reduce soil compaction.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 91,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead wood.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Fragaria" and species is "ananassa" (Garden Strawberry)
            if (genus == "Fragaria" && species == "ananassa")
            {
                // Add the most common problems for Fragaria × ananassa (Garden Strawberry)
                ListProblems.Add(new PlantProblem
                {
                    Id = 92,
                    Name = "Botrytis Fruit Rot (Gray Mold)",
                    Description = "Fungal disease causing gray mold on flowers, leaves, and fruit.",
                    Symptoms = "Gray fuzzy mold, rotting fruit, flower blight[2][1].",
                    Causes = "Infection by Botrytis cinerea, thrives in cool, humid conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove infected material, apply fungicide if needed.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 93,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves.",
                    Symptoms = "White powdery spots on leaves, reduced growth[2][1].",
                    Causes = "Infection by Podosphaera aphanis, thrives in warm, humid conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 94,
                    Name = "Phytophthora Crown and Root Rot",
                    Description = "Oomycete disease causing crown and root rot, plant collapse.",
                    Symptoms = "Wilting, stunted growth, crown and root rot, plant death[2][1].",
                    Causes = "Infection by Phytophthora cactorum, thrives in wet, poorly drained soils.",
                    Solutions = "Improve soil drainage, avoid overwatering, remove infected plants, use resistant cultivars.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 95,
                    Name = "Verticillium Wilt",
                    Description = "Fungal disease causing wilting and plant decline.",
                    Symptoms = "Wilting, yellowing leaves, stunted growth, plant death[1][3].",
                    Causes = "Infection by Verticillium spp., especially in stressed plants.",
                    Solutions = "Remove infected plants, rotate crops, use resistant cultivars.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 96,
                    Name = "Aphids",
                    Description = "Sap-sucking insects that transmit viruses and weaken plants.",
                    Symptoms = "Curled leaves, sticky honeydew, sooty mold, stunted growth[2].",
                    Causes = "Infestation by various aphid species.",
                    Solutions = "Encourage natural predators, spray with insecticidal soap if severe.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 97,
                    Name = "Spider Mites",
                    Description = "Tiny mites that feed on leaves, causing stippling and discoloration.",
                    Symptoms = "Fine webbing, yellow stippling on leaves, leaf drop[2].",
                    Causes = "Infestation by Tetranychus urticae (two-spotted spider mite), especially in hot, dry conditions.",
                    Solutions = "Increase humidity, encourage natural predators, spray with water or miticide if severe.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 98,
                    Name = "Plant Bugs (Lygus Bugs)",
                    Description = "Piercing-sucking insects causing distorted fruit and stunted growth.",
                    Symptoms = "Cat-faced or deformed fruit, stippling on leaves, reduced yield[2].",
                    Causes = "Infestation by Lygus spp., especially during flowering and fruit set.",
                    Solutions = "Monitor and remove by hand, use insecticidal soap if severe.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 99,
                    Name = "Root-Knot Nematodes",
                    Description = "Microscopic worms that infect roots, causing galls and stunted growth.",
                    Symptoms = "Galls on roots, stunted growth, yellowing leaves[2][1].",
                    Causes = "Infection by Meloidogyne spp.",
                    Solutions = "Use resistant cultivars, rotate crops, solarize soil, apply nematicides if needed.",
                    Severity = "High",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 100,
                    Name = "Viral Diseases (Multiple)",
                    Description = "Various viruses transmitted by aphids, thrips, and nematodes.",
                    Symptoms = "Mottled or distorted leaves, stunted growth, reduced yield[1][2].",
                    Causes = "Infection by viruses such as Strawberry crinkle, mottle, and mild yellow-edge viruses.",
                    Solutions = "Remove infected plants, control vectors, use virus-free stock.",
                    Severity = "Medium",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 101,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients can lead to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 102,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, remove runners and old leaves, fertilize as needed.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Cortaderia" and species is "selloana" (Pampas Grass)
            if (genus == "Cortaderia" && species == "selloana")
            {
                // Add the most common problems for Cortaderia selloana (Pampas Grass)
                ListProblems.Add(new PlantProblem
                {
                    Id = 103,
                    Name = "Overwatering and Root Rot",
                    Description = "Excess moisture leads to yellowing leaves, root rot, and plant decline.",
                    Symptoms = "Yellow or brown leaves, wilting, foul odor from soil, plant collapse[1][2][5].",
                    Causes = "Overwatering, poor drainage, compacted soil.",
                    Solutions = "Let soil dry between waterings, improve drainage, avoid waterlogged conditions.",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 104,
                    Name = "Underwatering",
                    Description = "Insufficient water leads to crispy, dry leaves and poor growth.",
                    Symptoms = "Crispy, brown leaf tips, reduced growth, wilting[1][5].",
                    Causes = "Prolonged drought, insufficient irrigation.",
                    Solutions = "Water thoroughly during dry periods, check soil moisture regularly.",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 105,
                    Name = "Fungal and Mold Infections",
                    Description = "Fungal diseases such as leaf blight, powdery mildew, and leaf rot.",
                    Symptoms = "Powdery white coating, black spots, dull leaf color, wilting, leaf death[3][4][5].",
                    Causes = "High humidity, poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, use fungicides if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 106,
                    Name = "Pests: Aphids, Mealybugs, Spider Mites",
                    Description = "Sap-sucking insects cause discoloration and weaken the plant.",
                    Symptoms = "Discolored spots on leaves, sticky residue, webbing between leaves[1][5].",
                    Causes = "Infestation by aphids, mealybugs, or spider mites.",
                    Solutions = "Wash leaves, use insecticidal sprays, encourage natural predators.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 107,
                    Name = "Nutrient Imbalances",
                    Description = "Excess or deficiency of nutrients affects growth and flowering.",
                    Symptoms = "Fewer flowers, excessive foliage, stunted growth[2][5].",
                    Causes = "Overfertilization, poor soil quality, lack of nutrients.",
                    Solutions = "Use slow-release fertilizer in moderation, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 108,
                    Name = "Abnormal Flower Development",
                    Description = "Poor or absent flowering due to cultural or disease issues.",
                    Symptoms = "Few or no flowers, distorted blooms, reduced vigor[2].",
                    Causes = "Improper pruning, disease, nutrient imbalance.",
                    Solutions = "Prune at the right time and properly, address disease and nutrient issues.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 109,
                    Name = "Extreme Temperature Stress",
                    Description = "Damage from frost or heat can affect plant health.",
                    Symptoms = "Leaf burn, wilting, reduced growth[1][5].",
                    Causes = "Frost, heat waves, sudden temperature changes.",
                    Solutions = "Protect from frost, provide shade in extreme heat, choose appropriate planting locations.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 110,
                    Name = "Invasive Growth and Fire Hazard",
                    Description = "Pampas grass can become invasive, outcompete natives, and increase fire risk.",
                    Symptoms = "Excessive spread, dense clumps, dry leaf buildup, reduced biodiversity[5][8].",
                    Causes = "Rapid growth, prolific seeding, lack of management.",
                    Solutions = "Monitor and control spread, remove seedlings, avoid planting in sensitive areas.",
                    Severity = "High",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 111,
                    Name = "Allergic Reactions",
                    Description = "Pollen can cause respiratory allergies in sensitive individuals.",
                    Symptoms = "Sneezing, runny nose, itchy eyes, respiratory irritation[7].",
                    Causes = "Exposure to airborne pollen.",
                    Solutions = "Limit exposure during flowering, avoid planting near living spaces.",
                    Severity = "Low",
                    Category = "Human Health"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 112,
                    Name = "Physical Injury from Sharp Leaves",
                    Description = "Sharp leaf edges can cause cuts and skin irritation.",
                    Symptoms = "Cuts, skin irritation, discomfort when handling[5][6][8].",
                    Causes = "Contact with sharp-edged leaves.",
                    Solutions = "Wear gloves and protective clothing when handling, plant away from walkways.",
                    Severity = "Low",
                    Category = "Human Health"
                });
            }

            // Example: Check if the genus is "Pennisetum" and species is "alopecuroides" (Fountain Grass)
            if (genus == "Pennisetum" && species == "alopecuroides")
            {
                // Add the most common problems for Pennisetum alopecuroides (Fountain Grass)
                ListProblems.Add(new PlantProblem
                {
                    Id = 113,
                    Name = "Rust and Fungal Diseases",
                    Description = "Occasional fungal infections such as rust and leaf spot can occur.",
                    Symptoms = "Orange or brown spots (rust), black or water-soaked spots (leaf spot), yellowing or wilting leaves[2][4][6].",
                    Causes = "High humidity, poor air circulation, overhead watering.",
                    Solutions = "Improve air circulation, avoid wetting foliage, remove infected leaves, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 114,
                    Name = "Aphids and Spider Mites",
                    Description = "Sap-sucking insects can infest the plant, especially in dry conditions.",
                    Symptoms = "Sticky residue, distorted growth, webbing between leaves, stippling on leaves[4][6].",
                    Causes = "Infestation by aphids or spider mites.",
                    Solutions = "Spray with water, use insecticidal soap or neem oil, encourage natural predators.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 115,
                    Name = "Overwatering and Poor Drainage",
                    Description = "Excess moisture can lead to root rot and yellowing leaves.",
                    Symptoms = "Yellow or brown leaves, wilting, foul odor from soil, mushy roots[3][4].",
                    Causes = "Overwatering, compacted or poorly drained soil.",
                    Solutions = "Let soil dry between waterings, improve drainage, avoid waterlogged conditions.",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 116,
                    Name = "Underwatering and Drought Stress",
                    Description = "Insufficient water can cause leaf tip browning and reduced vigor.",
                    Symptoms = "Brown, crispy leaf tips, wilting, stunted growth[3][4].",
                    Causes = "Prolonged drought, insufficient irrigation.",
                    Solutions = "Water deeply during dry periods, check soil moisture regularly.",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 117,
                    Name = "Grasshoppers",
                    Description = "Grasshoppers may occasionally feed on foliage, especially in late summer.",
                    Symptoms = "Chewed or ragged leaves, visible insects on plant[4].",
                    Causes = "Infestation by grasshoppers.",
                    Solutions = "Handpick larger pests, use protective netting if severe.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 118,
                    Name = "Nutrient Imbalance",
                    Description = "Excess or deficiency of nutrients can affect growth and flowering.",
                    Symptoms = "Fewer flowers, excessive foliage, stunted growth[2][4].",
                    Causes = "Overfertilization, poor soil quality, lack of nutrients.",
                    Solutions = "Use slow-release fertilizer in moderation, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 119,
                    Name = "Leggy or Sparse Growth",
                    Description = "Plants may become leggy or sparse if not pruned regularly.",
                    Symptoms = "Leggy stems, sparse foliage, reduced ornamental value[2][4].",
                    Causes = "Lack of pruning, overcrowding, insufficient light.",
                    Solutions = "Prune back in early spring, ensure adequate sunlight, thin out crowded clumps.",
                    Severity = "Low",
                    Category = "Maintenance"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 120,
                    Name = "Potential Invasiveness",
                    Description = "Some fountain grass species can become invasive, but most ornamental cultivars are sterile and less likely to spread[7][8].",
                    Symptoms = "Excessive self-seeding, unwanted spread in garden or natural areas.",
                    Causes = "Prolific seed production in some species or cultivars.",
                    Solutions = "Choose sterile cultivars, monitor for unwanted seedlings, remove seedlings promptly.",
                    Severity = "Low",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 121,
                    Name = "Winter Dieback or Cold Damage",
                    Description = "In colder climates, foliage may die back in winter or be damaged by frost.",
                    Symptoms = "Brown or dead foliage, reduced vigor after winter[5].",
                    Causes = "Cold temperatures, frost, inadequate winter protection.",
                    Solutions = "Cut back dead foliage in spring, mulch for winter protection if needed.",
                    Severity = "Low",
                    Category = "Environmental"
                });
            }

            // Example: Check if the genus is "Cotoneaster" and species is "horizontalis" (Rock Cotoneaster)
            if (genus == "Cotoneaster" && species == "horizontalis")
            {
                // Add the most common problems for Cotoneaster horizontalis (Rock Cotoneaster)
                ListProblems.Add(new PlantProblem
                {
                    Id = 122,
                    Name = "Fire Blight",
                    Description = "Bacterial disease causing wilting, blackening, and dieback of shoots and branches.",
                    Symptoms = "Blackened, wilted shoots resembling fire damage; sticky fluid may ooze from infected areas[1][2][6].",
                    Causes = "Infection by Erwinia amylovora.",
                    Solutions = "Prune and destroy infected branches, sterilize tools, avoid over-fertilizing, remove susceptible nearby plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 123,
                    Name = "Leaf Spot",
                    Description = "Fungal disease causing dark brown or black spots on leaves, often with yellow halos.",
                    Symptoms = "Brown or black leaf spots, yellowing, premature leaf drop[1][2].",
                    Causes = "Fungal pathogens such as Diplocarpon rosae.",
                    Solutions = "Prune affected areas, improve air circulation, avoid overhead watering, apply fungicides if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 124,
                    Name = "Web Blotch",
                    Description = "Fungal disease causing brownish, web-like patches on leaves.",
                    Symptoms = "Brown, web-like patches on leaves, leaf discoloration[1].",
                    Causes = "Fungal infection by Pleospora herbarum.",
                    Solutions = "Reduce leaf moisture, prune affected areas, improve spacing, apply fungicides if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 125,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white, powdery substance on leaves.",
                    Symptoms = "White powdery coating on leaves, yellowing, leaf drop[1][8].",
                    Causes = "Fungal infection, especially in humid conditions with poor air circulation.",
                    Solutions = "Improve ventilation, reduce overhead watering, apply fungicidal sprays if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 126,
                    Name = "Crown Rot",
                    Description = "Fungal disease causing rotting at the base or crown of the plant.",
                    Symptoms = "Rotting base, yellowing or wilting foliage, plant decline[1][2].",
                    Causes = "Fungal pathogens like Phytophthora spp., often in waterlogged soil.",
                    Solutions = "Ensure well-draining soil, avoid overwatering, use fungicides if needed.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 127,
                    Name = "Scale Insects",
                    Description = "Sap-sucking insects causing yellowing, wilting, and honeydew secretion.",
                    Symptoms = "Small, flat, oval insects on stems and leaves; yellowing or wilting leaves[1][7].",
                    Causes = "Infestation by scale insects such as European fruit lecanium scale.",
                    Solutions = "Introduce natural predators, manually remove, apply horticultural oils.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 128,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth and sooty mold.",
                    Symptoms = "Clusters of small green, black, or white insects on leaves; sticky honeydew; sooty mold[1][7].",
                    Causes = "Infestation by various aphid species.",
                    Solutions = "Release natural predators, spray with water, use insecticidal soap or neem oil if severe.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 129,
                    Name = "Webber Caterpillars",
                    Description = "Moth larvae that feed beneath silk webbing, causing defoliation.",
                    Symptoms = "Silk webbing on foliage, brown and dried leaves, visible caterpillars[5].",
                    Causes = "Caterpillars of Scythropia crataegella or Acrobasis suavella.",
                    Solutions = "Remove affected material, encourage natural predators, use biological controls if needed.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 130,
                    Name = "Mites",
                    Description = "Tiny pests causing speckled, discolored leaves and leaf drop.",
                    Symptoms = "Speckled leaves, browning, leaf drop in severe cases[3].",
                    Causes = "Infestation by spider or other mites.",
                    Solutions = "Increase humidity, spray with water, use miticides if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 131,
                    Name = "Poor Soil or Nutrient Imbalance",
                    Description = "Stunted growth, yellowing leaves, or lack of vigor due to poor soil conditions.",
                    Symptoms = "Stunted growth, yellowing leaves, poor flowering[1].",
                    Causes = "Incorrect pH, poor soil, nutrient deficiency or excess.",
                    Solutions = "Test soil pH, amend with organic matter, fertilize appropriately.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 132,
                    Name = "Extreme Weather Stress",
                    Description = "Damage from cold, heat, or drought causing leaf burn or dieback.",
                    Symptoms = "Burned or scorched leaves, early leaf drop, branch dieback[1].",
                    Causes = "Extreme cold, heat, or drought.",
                    Solutions = "Protect from frost, provide shade in heat, water during drought.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 133,
                    Name = "Invasive Potential",
                    Description = "Can become invasive in some regions, outcompeting native plants.",
                    Symptoms = "Excessive spread, dense growth, reduced biodiversity in surrounding area[4].",
                    Causes = "Prolific seeding, vigorous growth.",
                    Solutions = "Monitor and control spread, remove seedlings, avoid planting near natural areas.",
                    Severity = "Medium",
                    Category = "Environmental"
                });
            }

            // Example: Check if the genus is "Weigela" and species is "florida"
            if (genus == "Weigela" && species == "florida")
            {
                // Add the most common problems for Weigela florida
                ListProblems.Add(new PlantProblem
                {
                    Id = 134,
                    Name = "Aphids",
                    Description = "Sap-sucking insects that cluster on stems and under leaves, causing yellowing and curling.",
                    Symptoms = "Yellowing, curling leaves; sticky residue (honeydew); sooty mold[1][2][5].",
                    Causes = "Infestation by various aphid species.",
                    Solutions = "Knock off with water, use insecticidal soap or neem oil, encourage natural predators.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 135,
                    Name = "Spider Mites",
                    Description = "Tiny spider-like pests causing yellowing and stippling on leaves.",
                    Symptoms = "White dots, yellowing leaves, fine webbing[1][2][5].",
                    Causes = "Infestation by spider mites, especially in hot, dry conditions.",
                    Solutions = "Increase humidity, spray with water, use miticides if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 136,
                    Name = "Scale Insects",
                    Description = "Sap-sucking insects causing discoloration and leaf drop.",
                    Symptoms = "Waxy scales on stems and leaves, yellowing, leaf drop[1][5].",
                    Causes = "Infestation by scale insects.",
                    Solutions = "Manually remove, apply horticultural oil, encourage natural predators.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 137,
                    Name = "Mealybugs",
                    Description = "Fuzzy, white insects causing yellowing and reduced vigor.",
                    Symptoms = "Cottony masses on leaves, stems, and branches; yellowing; reduced vigor[1][2].",
                    Causes = "Infestation by mealybugs.",
                    Solutions = "Remove by hand, use insecticidal soap or neem oil.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 138,
                    Name = "Four-Lined Plant Bugs",
                    Description = "Sap-sucking insects causing irregular tan spots on foliage.",
                    Symptoms = "Irregular tan spots on leaves, stunted growth[1][2].",
                    Causes = "Infestation by four-lined plant bugs.",
                    Solutions = "Remove by hand, use insecticidal soap if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 139,
                    Name = "Leafrollers",
                    Description = "Caterpillars that roll leaves, causing distortion and webbing.",
                    Symptoms = "Curled, rolled leaves with webbing, distorted growth[1][2].",
                    Causes = "Infestation by leafroller caterpillars.",
                    Solutions = "Remove affected leaves, encourage natural predators, use biological controls.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 140,
                    Name = "Root Nematodes",
                    Description = "Microscopic worms feeding on roots, causing stunted growth and yellowing.",
                    Symptoms = "Stunted growth, reddish-yellow leaves, poor vigor[1].",
                    Causes = "Infestation by root nematodes.",
                    Solutions = "Improve soil health, use resistant cultivars, remove and destroy infected plants.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 141,
                    Name = "Black Spot",
                    Description = "Fungal disease causing dark black spots on leaves.",
                    Symptoms = "Black spots on leaves, leaf drop, reduced vigor[1][4][3].",
                    Causes = "Fungal infection, damp conditions, poor air circulation.",
                    Solutions = "Remove infected leaves, improve air circulation, avoid overhead watering.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 142,
                    Name = "Anthracnose",
                    Description = "Fungal disease causing brown spots with purple edges.",
                    Symptoms = "Brown spots with purple edges, leaf drop[1][4][3].",
                    Causes = "Fungal infection, damp conditions, poor air circulation.",
                    Solutions = "Remove infected foliage, improve air circulation, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 143,
                    Name = "Botrytis (Gray Mold)",
                    Description = "Fungal disease causing gray mold on leaves, flowers, and stems.",
                    Symptoms = "Gray mold on foliage, flowers, and stems; wilting[1][4].",
                    Causes = "Fungal infection, damp conditions, poor air circulation.",
                    Solutions = "Remove infected parts, improve air circulation, avoid overhead watering.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 144,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves.",
                    Symptoms = "White powdery coating on leaves, leaf curling, withering[1][4][6].",
                    Causes = "Fungal infection, high humidity, poor air circulation.",
                    Solutions = "Remove infected foliage, improve air circulation, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 145,
                    Name = "Rust",
                    Description = "Fungal disease causing reddish spots on leaves.",
                    Symptoms = "Reddish or orange spots on leaves, leaf drop[1][6].",
                    Causes = "Fungal infection, damp conditions.",
                    Solutions = "Remove infected leaves, improve air circulation, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 146,
                    Name = "Root Rot",
                    Description = "Fungal disease causing yellowing and wilting of foliage.",
                    Symptoms = "Yellowing, wilting, plant collapse[1][4].",
                    Causes = "Fungal infection, waterlogged soil, poor drainage.",
                    Solutions = "Improve drainage, avoid overwatering, remove infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 147,
                    Name = "Crown Galls",
                    Description = "Bacterial disease causing swollen growths at the base of the plant.",
                    Symptoms = "Swollen growths at base of stems or roots, stunted growth[1][4].",
                    Causes = "Bacterial infection, plant injury.",
                    Solutions = "Remove and destroy infected plants, avoid wounding, use disease-free stock.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 148,
                    Name = "Lack of Blossoms",
                    Description = "Poor or absent flowering due to cultural or environmental issues.",
                    Symptoms = "Few or no flowers, reduced vigor[1][5].",
                    Causes = "Improper pruning, late frost, insufficient sunlight, nutrient imbalance.",
                    Solutions = "Prune at the right time, protect from late frost, ensure full sun, fertilize as needed.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 149,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients leading to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 150,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead wood.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Carex" and species is "pendula" (Pendulous Sedge)
            if (genus == "Carex" && species == "pendula")
            {
                // Add the most common problems for Carex pendula (Pendulous Sedge)
                ListProblems.Add(new PlantProblem
                {
                    Id = 151,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery spots on leaves, reducing photosynthesis.",
                    Symptoms = "White powdery coating on leaves, leaf discoloration, reduced vigor[1][4].",
                    Causes = "Fungal infection, poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 152,
                    Name = "Rust",
                    Description = "Fungal disease causing orange or brown spots on leaves.",
                    Symptoms = "Orange or brown spots on leaves, leaf drop in severe cases[1][4].",
                    Causes = "Fungal infection, damp conditions.",
                    Solutions = "Remove infected leaves, improve air circulation, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 153,
                    Name = "Invasive Potential",
                    Description = "Can become invasive in favorable conditions, displacing native and productive plants[6][3][7].",
                    Symptoms = "Excessive spread, dense growth, reduced biodiversity, unpalatable to livestock.",
                    Causes = "High reproductive rate, dispersal by water, human planting as ornamental.",
                    Solutions = "Monitor spread, remove seedlings, avoid planting in sensitive areas, use physical or chemical control if needed.",
                    Severity = "High",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 154,
                    Name = "Drought Stress",
                    Description = "Reduced vigor and leaf browning in dry conditions.",
                    Symptoms = "Brown leaf tips, wilting, reduced growth[5].",
                    Causes = "Insufficient water, dry soil, especially in pots or containers.",
                    Solutions = "Keep soil consistently moist, water more frequently in hot weather, mulch to retain moisture.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 155,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients can lead to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer in spring and summer, improve soil quality[5].",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 156,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune at the end of winter to maintain compactness, fertilize as needed[5].",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Ficus" and species is "lyrata" (Fiddle-Leaf Fig)
            if (genus == "Ficus" && species == "lyrata")
            {
                // Add the most common problems for Ficus lyrata (Fiddle-Leaf Fig)
                ListProblems.Add(new PlantProblem
                {
                    Id = 157,
                    Name = "Root Rot",
                    Description = "Fungal infection caused by overwatering and poor drainage, leading to root decay and plant decline.",
                    Symptoms = "Yellowing leaves, wilting, musty odor from soil, plant collapse[1][5][7].",
                    Causes = "Overwatering, poor drainage, compacted soil.",
                    Solutions = "Allow soil to dry between waterings, ensure proper drainage, repot if necessary.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 158,
                    Name = "Leaf Spot (Fungal or Bacterial)",
                    Description = "Fungal or bacterial infections causing brown or black spots on leaves.",
                    Symptoms = "Brown or black spots, yellow halos, leaf drop[1][3][4].",
                    Causes = "Fungal or bacterial pathogens, excess moisture, poor air circulation.",
                    Solutions = "Improve air circulation, avoid wetting leaves, remove affected leaves, apply fungicide or bactericide if severe.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 159,
                    Name = "Anthracnose",
                    Description = "Fungal disease causing greasy yellow spots that turn brown and necrotic.",
                    Symptoms = "Greasy yellow spots, brown necrotic areas, leaf drop[3].",
                    Causes = "Fungal infection, overhead watering, damp conditions.",
                    Solutions = "Water at the base, avoid misting leaves, remove infected leaves, apply fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 160,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves.",
                    Symptoms = "White powdery spots on leaves, leaf curling, reduced vigor[5].",
                    Causes = "Poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 161,
                    Name = "Edema",
                    Description = "Physiological condition caused by inconsistent watering, leading to cell rupture.",
                    Symptoms = "Tiny red or brown dots on new leaves, especially on the underside[5].",
                    Causes = "Inconsistent watering, overwatering, sudden changes in moisture.",
                    Solutions = "Maintain consistent watering, allow soil to dry slightly between waterings.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 162,
                    Name = "Spider Mites",
                    Description = "Tiny spider-like pests causing stippling, webbing, and leaf drop.",
                    Symptoms = "Fine webbing, yellow stippling on leaves, leaf drop[2][4][7].",
                    Causes = "Low humidity, dry conditions, dust on leaves.",
                    Solutions = "Increase humidity, wipe leaves, spray with water or insecticidal soap, use neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 163,
                    Name = "Mealybugs",
                    Description = "White, cottony sap-sucking insects weakening the plant.",
                    Symptoms = "White cottony masses on leaves and stems, sticky residue, leaf drop[1][2][7].",
                    Causes = "Infestation by mealybugs, often in leaf joints and undersides.",
                    Solutions = "Remove with cotton swab dipped in alcohol, use insecticidal soap or neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 164,
                    Name = "Scale Insects",
                    Description = "Hard, brown, bumpy pests that attach to stems and leaves, secreting honeydew.",
                    Symptoms = "Brown bumps on stems and leaves, sticky residue, yellowing leaves[1][3][4].",
                    Causes = "Infestation by scale insects, often in leaf axils and undersides.",
                    Solutions = "Scrape off gently, wash with water, use insecticidal soap or neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 165,
                    Name = "Thrips",
                    Description = "Tiny insects causing silvering, stippling, or distortion of leaves.",
                    Symptoms = "Silvery or stippled leaves, distorted growth, black fecal spots[1][3][4].",
                    Causes = "Infestation by thrips, especially in warm, dry conditions.",
                    Solutions = "Use insecticidal soap, neem oil, or introduce natural predators.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 166,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing yellowing, curling, and sticky residue.",
                    Symptoms = "Yellowing, curling leaves, sticky honeydew, sooty mold[6][7].",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Wash off with water, use insecticidal soap or neem oil, encourage natural predators.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 167,
                    Name = "Whiteflies and Fungus Gnats",
                    Description = "Flying pests settling around leaves and soil, causing stress and damage.",
                    Symptoms = "Whiteflies: sticky leaves, sooty mold; Fungus gnats: tiny flies near soil, larvae in soil[4].",
                    Causes = "High humidity, overwatering, poor soil drainage.",
                    Solutions = "Reduce watering, improve drainage, use sticky traps or insecticidal soap.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 168,
                    Name = "Leaf Drop",
                    Description = "Sudden loss of leaves due to environmental stress.",
                    Symptoms = "Leaves dropping, especially lower leaves[1][7].",
                    Causes = "Sudden changes in environment, drafts, inconsistent watering, low light.",
                    Solutions = "Maintain consistent watering, avoid drafts, provide bright indirect light.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 169,
                    Name = "Brown Leaf Tips or Edges",
                    Description = "Leaf tips or edges turning brown due to low humidity or underwatering.",
                    Symptoms = "Brown, crispy leaf tips or edges[1][6].",
                    Causes = "Low humidity, underwatering, fertilizer burn.",
                    Solutions = "Increase humidity, water consistently, flush soil if over-fertilized.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 170,
                    Name = "Lopsided Growth",
                    Description = "Uneven growth due to uneven light exposure.",
                    Symptoms = "One side of the plant with more leaves or longer branches[4].",
                    Causes = "Plant not rotated, one-sided light source.",
                    Solutions = "Rotate plant regularly, prune to shape, provide even light.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 171,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients leading to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 172,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead leaves.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Howea" and species is "forsteriana" (Kentia Palm)
            if (genus == "Howea" && species == "forsteriana")
            {
                // Add the most common problems for Howea forsteriana (Kentia Palm)
                ListProblems.Add(new PlantProblem
                {
                    Id = 173,
                    Name = "Root Rot",
                    Description = "Fungal disease resulting from overwatering and poor drainage, leading to root decay and plant decline.",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, plant collapse[1][3][4].",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Allow soil to dry between waterings, ensure good drainage, repot if necessary.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 174,
                    Name = "Leaf Spot Diseases (Fungal/Bacterial)",
                    Description = "Fungal or bacterial infections causing spots on leaves, especially in humid conditions.",
                    Symptoms = "Brown or black spots, yellow halos, leaf drop[1][2][7].",
                    Causes = "Fungal or bacterial pathogens, humid conditions, wet foliage.",
                    Solutions = "Improve air circulation, avoid wetting leaves, remove affected leaves, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 175,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves.",
                    Symptoms = "White powdery spots on leaves, reduced vigor[3].",
                    Causes = "Fungal infection, high humidity, poor air circulation.",
                    Solutions = "Improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 176,
                    Name = "Spider Mites",
                    Description = "Tiny spider-like pests causing stippling, webbing, and leaf drop.",
                    Symptoms = "Fine webbing, yellow stippling on leaves, leaf drop[2][3][4].",
                    Causes = "Infestation by spider mites, especially in dry indoor conditions.",
                    Solutions = "Increase humidity, wipe leaves, spray with water or insecticidal soap, use neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 177,
                    Name = "Mealybugs",
                    Description = "White, cottony sap-sucking insects weakening the plant.",
                    Symptoms = "White cottony masses on leaves and stems, sticky residue, leaf drop[1][2][3].",
                    Causes = "Infestation by mealybugs, often in leaf joints and undersides.",
                    Solutions = "Remove with cotton swab dipped in alcohol, use insecticidal soap or neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 178,
                    Name = "Scale Insects",
                    Description = "Hard, brown, bumpy pests that attach to stems and leaves, secreting honeydew.",
                    Symptoms = "Brown bumps on stems and leaves, sticky residue, yellowing leaves[1][2][5].",
                    Causes = "Infestation by scale insects, often in leaf axils and undersides.",
                    Solutions = "Scrape off gently, wash with water, use insecticidal soap or neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 179,
                    Name = "Potassium Deficiency",
                    Description = "Lack of potassium causing necrosis at the tips of older leaves.",
                    Symptoms = "Leaflet tip necrosis on oldest leaves, little or no yellow spotting[2][5].",
                    Causes = "Insufficient potassium, poor fertilization.",
                    Solutions = "Apply a palm-specific fertilizer with adequate potassium, use controlled-release sources.",
                    Severity = "High",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 180,
                    Name = "Manganese Deficiency",
                    Description = "Lack of manganese causing necrosis at the tips of young leaves.",
                    Symptoms = "Leaflet tip necrosis on youngest leaves, yellowing leaf edges[2][5].",
                    Causes = "Insufficient manganese, alkaline soil.",
                    Solutions = "Apply manganese supplement or micronutrient-rich fertilizer suitable for palms.",
                    Severity = "Medium",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 181,
                    Name = "Boron Deficiency",
                    Description = "Lack of boron causing stunting and distortion of new leaves.",
                    Symptoms = "Stunted or distorted new leaves, incomplete opening of new leaves, horizontal shoot growth[2][5].",
                    Causes = "Insufficient boron, poor fertilization.",
                    Solutions = "Use a fertilizer with a complete micronutrient package that includes boron.",
                    Severity = "Medium",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 182,
                    Name = "Brown Leaf Tips",
                    Description = "Leaf tips turning brown due to low humidity or over-fertilizing.",
                    Symptoms = "Brown, crispy leaf tips, yellow halos[1][3].",
                    Causes = "Low humidity, salt build-up from tap water, over-fertilizing.",
                    Solutions = "Increase humidity, use filtered water, flush soil periodically, reduce fertilizer.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 183,
                    Name = "Yellow Leaves",
                    Description = "Yellowing leaves, especially lower leaves, often due to overwatering or age.",
                    Symptoms = "Yellowing leaves, especially lower, older leaves[1][3][4].",
                    Causes = "Overwatering, natural aging, nutrient deficiency.",
                    Solutions = "Let soil dry between waterings, check for root rot, fertilize appropriately.",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 184,
                    Name = "Slow Growth",
                    Description = "Reduced or stunted growth due to insufficient light or nutrients.",
                    Symptoms = "Little to no new growth, small leaves[1][3][4].",
                    Causes = "Low light, poor fertilization, root-bound conditions.",
                    Solutions = "Provide bright, indirect light, fertilize regularly, repot if root-bound.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 185,
                    Name = "Transplant Shock",
                    Description = "Stress and decline after repotting, especially if roots are disturbed.",
                    Symptoms = "Wilting, yellowing leaves, stunted growth after transplant[3].",
                    Causes = "Root disturbance, improper repotting, sudden changes in environment.",
                    Solutions = "Water well before transplanting, avoid disturbing roots, maintain stable conditions.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 186,
                    Name = "Underwatering",
                    Description = "Insufficient water leading to dehydration and stress.",
                    Symptoms = "Yellow or paled fronds, brown crispy new growth, gradual decline[3][4].",
                    Causes = "Forgetfulness, pot-bound, too much light or heat.",
                    Solutions = "Water when top inch of soil is dry, maintain consistent moisture, avoid direct sunlight.",
                    Severity = "Medium",
                    Category = "Cultural"
                });
            }

            // Example: Check if the genus is "Dracaena" and species is "fragrans" (Corn Plant)
            if (genus == "Dracaena" && species == "fragrans")
            {
                // Add the most common problems for Dracaena fragrans (Corn Plant)
                ListProblems.Add(new PlantProblem
                {
                    Id = 198,
                    Name = "Spider Mites",
                    Description = "Tiny spider-like pests causing yellow stippling, webbing, and leaf drop.",
                    Symptoms = "Fine webbing, yellow or brown stippling on leaves, leaf drop[1][5][7].",
                    Causes = "Dry indoor air, low humidity, dusty conditions.",
                    Solutions = "Increase humidity, wipe leaves, use insecticidal soap or neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 199,
                    Name = "Mealybugs",
                    Description = "Small, white, cottony sap-sucking insects that weaken the plant.",
                    Symptoms = "White cottony masses on leaves and stems, sticky residue, yellowing leaves[1][5][7].",
                    Causes = "Infestation by mealybugs, often in leaf joints and crevices.",
                    Solutions = "Remove with cotton swab dipped in alcohol, use insecticidal soap or neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 200,
                    Name = "Scale Insects",
                    Description = "Hard, brown, bumpy pests that attach to stems and leaves, secreting honeydew.",
                    Symptoms = "Brown bumps on stems and leaves, sticky residue, yellowing leaves[1][5][7].",
                    Causes = "Infestation by scale insects, often in leaf axils and undersides.",
                    Solutions = "Scrape off gently, wash with water, use insecticidal soap or neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 201,
                    Name = "Root Rot",
                    Description = "Fungal disease causing root decay, yellowing, and wilting.",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, plant collapse[1][2][5].",
                    Causes = "Overwatering, poor drainage, compacted soil.",
                    Solutions = "Allow soil to dry between waterings, improve drainage, repot if necessary.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 202,
                    Name = "Leaf Spot (Fungal or Bacterial)",
                    Description = "Fungal or bacterial infections causing brown or black spots on leaves.",
                    Symptoms = "Brown or black spots, yellow halos, leaf drop[1][5][7].",
                    Causes = "Overwatering, poor air circulation, high humidity.",
                    Solutions = "Improve air circulation, avoid wetting leaves, remove affected leaves, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 203,
                    Name = "Soft Rot",
                    Description = "Bacterial disease causing dark, soft, mushy areas on stems and leaves.",
                    Symptoms = "Dark, soft, mushy spots on lower stems and leaves, plant collapse[5][3].",
                    Causes = "Bacterial infection, overwatering, poor drainage.",
                    Solutions = "Remove and destroy affected parts, improve drainage, avoid overwatering.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 204,
                    Name = "Anthracnose",
                    Description = "Fungal disease causing blackened or pinkish water-soaked lesions on leaves.",
                    Symptoms = "Blackened or pinkish water-soaked lesions, rings of brown or black fungal growth, leaf drop[3].",
                    Causes = "Fungal infection, high humidity, wet foliage.",
                    Solutions = "Remove symptomatic leaves, spray with fungicide, improve air circulation.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 205,
                    Name = "Fluoride Toxicity",
                    Description = "Brown leaf tips and margins caused by fluoride in tap water.",
                    Symptoms = "Brown or necrotic leaf tips and margins, leaf drop[3][6].",
                    Causes = "Exposure to fluoride in municipal water.",
                    Solutions = "Use rainwater, filtered, or distilled water.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 206,
                    Name = "Brown Leaf Tips",
                    Description = "Leaf tips turning brown due to low humidity, over-fertilizing, or tap water chemicals.",
                    Symptoms = "Brown, crispy leaf tips, yellow halos[3][6].",
                    Causes = "Low humidity, salt build-up, over-fertilizing, fluoride or chlorine in water.",
                    Solutions = "Increase humidity, use filtered water, flush soil periodically, reduce fertilizer.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 207,
                    Name = "Yellow Leaves",
                    Description = "Yellowing leaves, especially lower leaves, due to overwatering, age, or nutrient deficiency.",
                    Symptoms = "Yellowing leaves, especially lower, older leaves[2][3][6].",
                    Causes = "Overwatering, natural aging, nutrient deficiency.",
                    Solutions = "Let soil dry between waterings, check for root rot, fertilize appropriately.",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 208,
                    Name = "Stunted Growth",
                    Description = "Slow or stunted growth due to lack of nutrients or root-bound conditions.",
                    Symptoms = "Little to no new growth, small leaves[6].",
                    Causes = "Poor fertilization, root-bound conditions, low light.",
                    Solutions = "Fertilize lightly, repot if root-bound, provide bright indirect light.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 209,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients leading to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 210,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases.",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead leaves.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Lonicera" and species is "nitida" (Boxleaf Honeysuckle)
            if (genus == "Lonicera" && species == "nitida")
            {
                // Add the most common problems for Lonicera nitida (Boxleaf Honeysuckle)
                ListProblems.Add(new PlantProblem
                {
                    Id = 211,
                    Name = "Fungal Diseases (Powdery Mildew, Root Rot)",
                    Description = "Fungal infections can occur, especially in overly wet or poorly ventilated conditions.",
                    Symptoms = "White powdery coating on leaves (powdery mildew), yellowing or wilting (root rot), leaf drop[3][4][5].",
                    Causes = "Overwatering, poor drainage, lack of air circulation.",
                    Solutions = "Improve air circulation, avoid overhead watering, use fungicide if needed, ensure good drainage.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 212,
                    Name = "Honey Fungus",
                    Description = "Fungal disease attacking roots and causing plant decline, though Lonicera nitida is considered somewhat resistant[5].",
                    Symptoms = "Wilting, undersized leaves, failure to flower or fruit, white fungal growth at base, golden brown mushrooms[5].",
                    Causes = "Infection by Armillaria spp., often in wet or poorly drained soil.",
                    Solutions = "Remove and destroy infected plants, avoid planting in contaminated soil, use resistant species.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 213,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth and sooty mold.",
                    Symptoms = "Clusters of small insects on leaves, sticky residue, sooty mold[3][6].",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 214,
                    Name = "Spider Mites",
                    Description = "Tiny spider-like pests causing stippling and webbing on leaves.",
                    Symptoms = "Fine webbing, yellow stippling on leaves, leaf drop[3][6].",
                    Causes = "Dry conditions, low humidity, dusty foliage.",
                    Solutions = "Increase humidity, spray with water, use miticides if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 215,
                    Name = "Scale Insects",
                    Description = "Sap-sucking pests causing yellowing and leaf drop.",
                    Symptoms = "Brown bumps on stems and leaves, sticky residue, yellowing leaves[3][6].",
                    Causes = "Infestation by scale insects.",
                    Solutions = "Manually remove, use horticultural oil, encourage natural predators.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 216,
                    Name = "Frost Damage",
                    Description = "Cold weather can cause leaf and stem damage, especially after transplanting or during severe frosts[2][4].",
                    Symptoms = "Blackened or wilted leaves, dieback, reduced vigor.",
                    Causes = "Sudden or severe frost, transplant shock.",
                    Solutions = "Protect young plants in winter, avoid transplanting during frost risk, prune damaged growth in spring.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 217,
                    Name = "Phytophthora Root Rot",
                    Description = "Fungal-like pathogen causing root decay and plant decline, especially in poorly drained soils[5][6].",
                    Symptoms = "Yellowing leaves, wilting, root decay, plant collapse.",
                    Causes = "Waterlogged soil, poor drainage.",
                    Solutions = "Improve drainage, avoid overwatering, remove and destroy infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 218,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular pruning can result in poor shape and increased susceptibility to pests and diseases.",
                    Symptoms = "Leggy growth, susceptibility to diseases and pests.",
                    Causes = "Lack of pruning, irregular watering.",
                    Solutions = "Prune regularly to maintain shape, water as needed, remove dead or diseased material.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Nepeta" and species is "cataria" (Catnip)
            if (genus == "Nepeta" && species == "cataria")
            {
                // Add the most common problems for Nepeta cataria (Catnip)
                ListProblems.Add(new PlantProblem
                {
                    Id = 219,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves.",
                    Symptoms = "White powdery spots on leaves, leaf curling, reduced vigor[1][4][5].",
                    Causes = "High humidity, poor air circulation, crowded plants.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 220,
                    Name = "Leaf Spot (Cercospora, Septoria)",
                    Description = "Fungal diseases causing spots with yellow halos or gray centers on leaves.",
                    Symptoms = "Yellow halos around spots (Cercospora), gray spots with dark edges (Septoria), leaf drop[2][4][5].",
                    Causes = "Wet conditions, poor air circulation, overhead watering.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering, use fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 221,
                    Name = "Root Rot",
                    Description = "Fungal disease causing root decay, yellowing, and wilting.",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, plant collapse[1][2][6].",
                    Causes = "Overwatering, poor drainage, compacted soil.",
                    Solutions = "Plant in well-drained soil, avoid overwatering, remove and destroy infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 222,
                    Name = "Bacterial Leaf Spot",
                    Description = "Bacterial disease causing water-soaked spots with yellow halos on leaves.",
                    Symptoms = "Water-soaked spots with yellow halos, spots darken and may turn black, leaf drop[2][4].",
                    Causes = "Cool, wet weather, poor air circulation, working with wet plants.",
                    Solutions = "Remove infected plants, avoid overhead watering, keep area clean, practice crop rotation.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 223,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth and sooty mold.",
                    Symptoms = "Clusters of small insects on leaves, sticky residue, sooty mold[2][3][5].",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 224,
                    Name = "Spider Mites",
                    Description = "Tiny spider-like pests causing stippling and webbing on leaves.",
                    Symptoms = "Fine webbing, yellow stippling on leaves, leaf drop[2][3][5].",
                    Causes = "Dry conditions, low humidity, dusty foliage.",
                    Solutions = "Increase humidity, spray with water, use miticides if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 225,
                    Name = "Thrips and Whiteflies",
                    Description = "Sap-sucking insects causing discoloration and leaf drop.",
                    Symptoms = "Discolored or distorted leaves, sticky residue, silvering or whiteflies on leaves[2][3][5].",
                    Causes = "Infestation by thrips or whiteflies.",
                    Solutions = "Use insecticidal soap, encourage natural predators, keep area clean.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 226,
                    Name = "Flea Beetles",
                    Description = "Small jumping beetles causing tiny holes in leaves.",
                    Symptoms = "Tiny holes in leaves, reduced vigor[2][3].",
                    Causes = "Infestation by flea beetles.",
                    Solutions = "Use row covers, insecticidal soap, keep area clean.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 227,
                    Name = "Overwatering and Poor Drainage",
                    Description = "Excess water leading to root rot and fungal diseases.",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, plant collapse[3][5][6].",
                    Causes = "Overwatering, poor drainage, compacted soil.",
                    Solutions = "Plant in well-drained soil, let soil dry between waterings, avoid waterlogged conditions.",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 228,
                    Name = "Underwatering and Drought Stress",
                    Description = "Insufficient water causing crispy leaves and stunted growth.",
                    Symptoms = "Crispy, dry leaves, stunted growth, wilting[3][5].",
                    Causes = "Prolonged drought, insufficient irrigation.",
                    Solutions = "Water regularly, especially during dry periods, mulch to retain moisture.",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 229,
                    Name = "Leggy Growth and Pale Leaves",
                    Description = "Weak, stretched growth due to insufficient light.",
                    Symptoms = "Pale, leggy stems, reduced vigor[5].",
                    Causes = "Insufficient sunlight, too much shade.",
                    Solutions = "Provide full sun, prune to encourage bushiness, avoid overcrowding.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 230,
                    Name = "Cat Damage",
                    Description = "Cats attracted to the plant may roll on or break stems and foliage[2][7][8].",
                    Symptoms = "Broken stems, flattened plants, reduced vigor.",
                    Causes = "Cats attracted to the scent of catnip.",
                    Solutions = "Protect plants with fencing or cages, plant in containers, choose less accessible locations.",
                    Severity = "Medium",
                    Category = "Physical Damage"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 231,
                    Name = "Invasive or Weedy Growth",
                    Description = "Can self-seed and spread in the garden if not managed[1][8].",
                    Symptoms = "Excessive spread, unwanted seedlings, reduced space for other plants.",
                    Causes = "Self-seeding, vigorous growth.",
                    Solutions = "Deadhead flowers before seed set, monitor and remove unwanted seedlings, grow in containers.",
                    Severity = "Low",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 232,
                    Name = "Nutrient Imbalance or Poor Soil",
                    Description = "Lack of nutrients or poor soil quality can reduce plant vigor[3][6].",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Amend soil with compost, use balanced fertilizer if needed, ensure proper pH.",
                    Severity = "Low",
                    Category = "Nutrition"
                });
            }

            // Example: Check if the genus is "Lavandula" and species is "angustifolia" (English Lavender)
            if (genus == "Lavandula" && species == "angustifolia")
            {
                // Add the most common problems for Lavandula angustifolia (English Lavender)
                ListProblems.Add(new PlantProblem
                {
                    Id = 233,
                    Name = "Root Rot",
                    Description = "Fungal disease causing root decay, yellowing, and wilting. Often caused by Phytophthora, Fusarium, Pythium, or Rhizoctonia species[2][3][7].",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, plant collapse.",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Plant in well-drained soil, avoid overwatering, remove and destroy infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 234,
                    Name = "Leaf Spot (Septoria)",
                    Description = "Fungal disease causing grey or brown spots with yellow halos on leaves[2][7][8].",
                    Symptoms = "Grey or brown spots on leaves, leaf drop, reduced vigor.",
                    Causes = "High humidity, poor air circulation, wet foliage.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove infected leaves, use fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 235,
                    Name = "Botrytis (Grey Mold)",
                    Description = "Fungal disease causing grey mold and wilting of foliage, especially in humid conditions[2][1][8].",
                    Symptoms = "Grey mold on leaves and stems, wilting, yellowing, plant decline.",
                    Causes = "High humidity, poor air circulation, overwatering.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove infected parts, use fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 236,
                    Name = "Alfalfa Mosaic Virus",
                    Description = "Viral disease causing yellow patches, leaf distortion, and stunted growth. Spread by aphids or contaminated tools[2][3][5].",
                    Symptoms = "Yellow patches or rings, contorted leaves, stunted growth.",
                    Causes = "Aphids, contaminated tools, plant-to-plant contact.",
                    Solutions = "Remove and destroy infected plants, control aphids, sanitize tools.",
                    Severity = "High",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 237,
                    Name = "Lavender Shab (Phomopsis lavandulae)",
                    Description = "Fungal disease causing stem wilt, brown and black patches, and plant death[2][5].",
                    Symptoms = "Sudden wilting, brown and black patches on stems, plant death.",
                    Causes = "Fungal spores spread by wind, contaminated tools, infected plants.",
                    Solutions = "Remove and destroy infected plants, use disease-free stock, sanitize tools.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 238,
                    Name = "Aphids",
                    Description = "Sap-sucking insects that can transmit viruses and weaken the plant[2][3][5].",
                    Symptoms = "Clusters of small insects on leaves, sticky residue, sooty mold.",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 239,
                    Name = "Spittlebugs",
                    Description = "Insects that produce frothy spittle on stems, generally harmless to lavender[1][5].",
                    Symptoms = "Foamy spittle on stems, minor cosmetic damage.",
                    Causes = "Infestation by spittlebug nymphs.",
                    Solutions = "Generally no action needed; remove by hand if desired.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 240,
                    Name = "Garden Weevil",
                    Description = "Beetles that chew on stems and foliage, causing minor damage[1].",
                    Symptoms = "Chewed stems and leaves, minor cosmetic damage.",
                    Causes = "Infestation by garden weevils.",
                    Solutions = "Remove by hand, use barriers if severe.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 241,
                    Name = "Moles and Voles",
                    Description = "Mammals that can uproot or eat roots and lower stems[2].",
                    Symptoms = "Uprooted plants, eaten roots, plant collapse.",
                    Causes = "Tunneling by moles, feeding by voles.",
                    Solutions = "Use physical barriers, traps, or repellents.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 242,
                    Name = "Overwatering and Poor Drainage",
                    Description = "Excess moisture leading to root and fungal diseases[2][3][7].",
                    Symptoms = "Yellowing, wilting, foul odor from soil.",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Plant in well-drained soil, avoid overwatering.",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 243,
                    Name = "Leggy Growth and Reduced Flowering",
                    Description = "Weak, stretched growth and few flowers due to insufficient light or overcrowding[2].",
                    Symptoms = "Leggy stems, sparse flowering, reduced vigor.",
                    Causes = "Insufficient sunlight, overcrowding, lack of pruning.",
                    Solutions = "Provide full sun, prune annually, avoid overcrowding.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 244,
                    Name = "Nutrient Imbalance or Poor Soil",
                    Description = "Lack of nutrients or poor soil quality can reduce plant vigor[7].",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Use well-drained soil, avoid excess fertilizer, amend with compost if needed.",
                    Severity = "Low",
                    Category = "Nutrition"
                });
            }

            // Example: Check if the genus is "Paeonia" and species is "lactiflora" (Common Garden Peony)
            if (genus == "Paeonia" && species == "lactiflora")
            {
                // Add the most common problems for Paeonia lactiflora (Common Garden Peony)
                ListProblems.Add(new PlantProblem
                {
                    Id = 245,
                    Name = "Botrytis Blight (Gray Mold)",
                    Description = "Fungal disease causing rot and dieback of shoots, buds, and flowers; most common disease of garden peonies[2][5][7].",
                    Symptoms = "Young shoots rot at ground level, wilted and toppled stems, brown or blackish fungal spores, gray mold on stems, blackened or withered buds, brown flowers[2][5][7].",
                    Causes = "Botrytis cinerea, thrives in cool, wet conditions.",
                    Solutions = "Remove and destroy infected plant parts, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 246,
                    Name = "Peony Blotch (Measles/Red Spot)",
                    Description = "Fungal disease causing purple-red spots and blotches on leaves, stems, and flowers[2][5].",
                    Symptoms = "Red or purplish spots on leaves (glossy and dark purple on top, chestnut brown underneath), reddish-brown streaks on stems and petioles, coalescing blotches, unsightly foliage[2][5].",
                    Causes = "Graphiopsis chlorocephala (formerly Cladosporium paeoniae), thrives in humid conditions.",
                    Solutions = "Remove infected leaves, improve air circulation, avoid overhead watering, use fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 247,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease producing a light gray or whitish powder on leaves, stems, and flowers[2][4][7].",
                    Symptoms = "White powdery coating on foliage, deformed flowers, leaf drop, mostly cosmetic damage[2][4][7].",
                    Causes = "Various powdery mildew fungi, poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, use fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 248,
                    Name = "Phytophthora Blight and Root Rot",
                    Description = "Fungal disease causing stem, root, and crown rot, especially in wet soils[2][5].",
                    Symptoms = "Darkened, leathery stems at soil line, wilting, root and crown rot, plant collapse[2][5].",
                    Causes = "Phytophthora cactorum, thrives in waterlogged soils.",
                    Solutions = "Improve drainage, avoid overwatering, remove and destroy infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 249,
                    Name = "Leaf Spot (Various Fungal)",
                    Description = "Various fungi cause tan to brown spots with distinct borders, mostly cosmetic[2][5].",
                    Symptoms = "Tan to brown spots on leaves, sometimes merging into blights or blotches, leaf drop in severe cases[2][5].",
                    Causes = "Various fungal pathogens, damp conditions.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 250,
                    Name = "Viral Diseases",
                    Description = "Several viruses cause mottling, yellowing, ringspots, and general plant decline[2][3][7].",
                    Symptoms = "Mottled, yellow, or ring-spotted leaves, stunted growth, plant decline[2][3][7].",
                    Causes = "Peony ringspot virus, mosaic viruses, spread by insects or contaminated tools.",
                    Solutions = "Remove and destroy infected plants, control insect vectors, sanitize tools.",
                    Severity = "Medium",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 251,
                    Name = "Foliar Nematodes",
                    Description = "Nematodes attacking above-ground plant parts, causing angular, water-soaked lesions and leaf drop[2].",
                    Symptoms = "Angular, water-soaked leaf lesions, brown or black spots, stunting, leaf proliferation, plant decline[2].",
                    Causes = "Aphelenchoides spp., spread by water splash, thrives in humid conditions.",
                    Solutions = "Keep foliage dry, remove and destroy infected leaves, avoid overhead watering.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 252,
                    Name = "Bacterial Leaf Spot (Xanthomonas Blight)",
                    Description = "Bacterial disease causing purple leaf spots and blight of shoots[5].",
                    Symptoms = "Purple leaf spots, coalescing blights on shoots, plant decline[5].",
                    Causes = "Xanthomonas spp., thrives in wet conditions.",
                    Solutions = "Remove infected leaves, improve air circulation, avoid overhead watering.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 253,
                    Name = "Anthracnose",
                    Description = "Fungal disease causing brown lesions and dieback[5].",
                    Symptoms = "Brown lesions with concentric rings, dieback of shoots and leaves[5].",
                    Causes = "Various anthracnose fungi, thrives in humid conditions.",
                    Solutions = "Remove affected parts, improve air circulation, avoid overhead watering.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 254,
                    Name = "Moisture Stress and Wilting",
                    Description = "Wilting due to over- or underwatering, or root disease[6][1].",
                    Symptoms = "Wilting, yellowing, leaf drop, plant decline[6][1].",
                    Causes = "Overwatering, underwatering, root rot, poor drainage.",
                    Solutions = "Maintain consistent moisture, improve drainage, avoid waterlogged or dry soil.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 255,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients causing poor growth and leaf discoloration[1].",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, amend soil with compost.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 256,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases[1][8].",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead leaves.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Papaver" and species is "nudicaule" (Iceland Poppy)
            if (genus == "Papaver" && species == "nudicaule")
            {
                // Add the most common problems for Papaver nudicaule (Iceland Poppy)
                ListProblems.Add(new PlantProblem
                {
                    Id = 257,
                    Name = "Root Rot",
                    Description = "Fungal disease causing root decay, yellowing, and wilting.",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, mushy roots, plant collapse[2][4][7].",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Plant in well-drained soil, avoid overwatering, remove and destroy infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 258,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery spots on leaves and stunted growth.",
                    Symptoms = "White powdery spots on leaves, curled leaves, stunted growth[2][4][8].",
                    Causes = "High humidity, poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 259,
                    Name = "Rust",
                    Description = "Fungal disease causing orange or yellow spots on leaves, leading to curling and premature drop.",
                    Symptoms = "Orange or yellow spots on leaves, leaf curling, premature leaf drop[2][8].",
                    Causes = "Fungal infection, damp conditions.",
                    Solutions = "Remove infected leaves, improve air circulation, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 260,
                    Name = "Black Rot and Blight",
                    Description = "Fungal diseases causing dark lesions, wilting, and rapid decay.",
                    Symptoms = "Dark lesions on stems and leaves, wilting, mushy stems, plant decline[2][4][8].",
                    Causes = "Fungal infection, wet conditions, poor air circulation.",
                    Solutions = "Remove and destroy affected plants, improve air circulation, avoid overhead watering, use fungicide if needed.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 261,
                    Name = "Gray Mold (Botrytis)",
                    Description = "Fungal disease causing gray mold on flowers, leaves, and stems.",
                    Symptoms = "Gray mold on flowers and leaves, wilting, plant collapse[4].",
                    Causes = "Cool, wet weather, poor air circulation.",
                    Solutions = "Remove affected plants, improve air circulation, avoid overhead watering, use fungicide if needed.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 262,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth and sooty mold.",
                    Symptoms = "Clusters of small insects on stems and leaves, sticky residue, sooty mold[2][5].",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 263,
                    Name = "Spider Mites",
                    Description = "Tiny spider-like pests causing stippling and webbing on leaves.",
                    Symptoms = "Fine webbing, yellow stippling on leaves, leaf drop[2][5].",
                    Causes = "Dry conditions, low humidity, dusty foliage.",
                    Solutions = "Increase humidity, spray with water, use miticides if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 264,
                    Name = "Slugs and Snails",
                    Description = "Mollusks that chew irregular holes in leaves, especially in damp conditions.",
                    Symptoms = "Irregular holes in leaves, slime trails, reduced vigor[2][5].",
                    Causes = "Presence of slugs or snails, damp environments.",
                    Solutions = "Handpick, use traps, apply diatomaceous earth.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 265,
                    Name = "Leafhoppers, Leafminers, and Thrips",
                    Description = "Sap-sucking or leaf-mining insects causing stippling, discoloration, and reduced vigor.",
                    Symptoms = "Stippling, discoloration, tunnels in leaves, reduced plant vigor[5].",
                    Causes = "Infestation by leafhoppers, leafminers, or thrips.",
                    Solutions = "Monitor regularly, use insecticidal soap or neem oil if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 266,
                    Name = "Incorrect Watering",
                    Description = "Overwatering or underwatering leading to wilting, yellowing, or root rot.",
                    Symptoms = "Wilting, yellowing leaves, mushy stems (overwatering), dry crispy leaves (underwatering)[2][4][7].",
                    Causes = "Overwatering, poor drainage, or insufficient water.",
                    Solutions = "Water when soil is slightly dry, ensure good drainage, maintain consistent moisture.",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 267,
                    Name = "Incorrect Light Conditions",
                    Description = "Too much or too little light affecting growth and flowering.",
                    Symptoms = "Leggy growth, sparse flowers (low light), scorched leaves, faded colors (excess light)[2].",
                    Causes = "Insufficient or excessive sunlight.",
                    Solutions = "Provide partial shade or filtered sunlight, use shade cloth if needed.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 268,
                    Name = "Temperature Stress",
                    Description = "Extreme temperatures causing wilting, leaf drop, or slow growth.",
                    Symptoms = "Wilting, leaf drop, slow growth[2].",
                    Causes = "Extreme heat or frost.",
                    Solutions = "Protect from heat with shade, protect from frost with row covers or mulch.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 269,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients leading to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop[2].",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, improve soil quality.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 270,
                    Name = "Toxicity",
                    Description = "Plant is toxic to humans and animals if ingested.",
                    Symptoms = "Gastrointestinal upset, lethargy, severe symptoms in pets[6].",
                    Causes = "Ingestion of plant material.",
                    Solutions = "Keep out of reach of children and pets, wash hands after handling.",
                    Severity = "High",
                    Category = "Human/Pet Health"
                });
            }

            // Example: Check if the genus is "Vinca" and species is "minor" (Common Periwinkle)
            if (genus == "Vinca" && species == "minor")
            {
                // Add the most common problems for Vinca minor (Common Periwinkle)
                ListProblems.Add(new PlantProblem
                {
                    Id = 271,
                    Name = "Stem Canker (Phoma Blight)",
                    Description = "Fungal disease causing dark brown to black lesions on stems, leading to wilting and dieback[5][8][6].",
                    Symptoms = "Dark brown to black lesions on stems, wilting, dieback, plant collapse.",
                    Causes = "Infection by Phoma exigua or Phomopsis sp., especially in cool, wet weather.",
                    Solutions = "Remove and destroy infected plants, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 272,
                    Name = "Root and Stem Rot (Rhizoctonia)",
                    Description = "Fungal disease causing blackening or rotting of roots and stems near the soil line[6][8].",
                    Symptoms = "Blackening or rotting of roots and stems, wilting, plant death.",
                    Causes = "Infection by Rhizoctonia solani, overwatering, poor drainage.",
                    Solutions = "Improve drainage, avoid overwatering, remove and destroy infected plants, improve air circulation.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 273,
                    Name = "Botrytis Blight (Gray Mold)",
                    Description = "Fungal disease causing stem canker, leaf spot, and blight, especially in humid conditions[6].",
                    Symptoms = "Gray mold on leaves and stems, wilting, plant decline.",
                    Causes = "Infection by Botrytis cinerea, extended humid or wet weather.",
                    Solutions = "Remove affected parts, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 274,
                    Name = "Leaf Spot",
                    Description = "Fungal disease causing dark spots on leaves, leading to browning and death[6][7].",
                    Symptoms = "Dark spots on leaves, browning, leaf death.",
                    Causes = "Fungal infection, damp conditions, poor air circulation.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 275,
                    Name = "Phytophthora Blight",
                    Description = "Fungal disease causing yellow to dark brown leaf spots and root/stem rot[2][6].",
                    Symptoms = "Yellow to dark brown leaf spots, root/stem rot, wilting, plant death.",
                    Causes = "Infection by Phytophthora spp., waterlogged soil.",
                    Solutions = "Improve drainage, avoid overwatering, remove and destroy infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 276,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth and sooty mold[1][7].",
                    Symptoms = "Clusters of small insects on stems and leaves, sticky residue, sooty mold.",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap or neem oil if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 277,
                    Name = "Spider Mites",
                    Description = "Tiny spider-like pests causing stippling and webbing on leaves[1][7].",
                    Symptoms = "Fine webbing, yellow stippling on leaves, leaf drop.",
                    Causes = "Dry conditions, low humidity, dusty foliage.",
                    Solutions = "Increase humidity, spray with water, use miticides if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 278,
                    Name = "Scale Insects",
                    Description = "Sap-sucking pests causing yellowing and leaf drop[1][7].",
                    Symptoms = "Brown bumps on stems and leaves, sticky residue, yellowing leaves.",
                    Causes = "Infestation by scale insects.",
                    Solutions = "Manually remove, use horticultural oil, encourage natural predators.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 279,
                    Name = "Whiteflies",
                    Description = "Small, white, flying insects causing leaf yellowing and plant stress[2][7].",
                    Symptoms = "Tiny white insects on leaf undersides, yellowing leaves, sticky residue.",
                    Causes = "Infestation by whiteflies.",
                    Solutions = "Use sticky traps, spray with water, use insecticidal soap or neem oil.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 280,
                    Name = "Tomato Spotted Wilt Virus (TSWV)",
                    Description = "Viral disease causing black concentric ring spots, yellowing, stunting, and distortion[3].",
                    Symptoms = "Black ring spots or line patterns, yellowing, stunting, distortion.",
                    Causes = "Transmission by thrips, infected plants or weeds.",
                    Solutions = "Remove and destroy infected plants, control weeds, avoid planting near susceptible crops.",
                    Severity = "Medium",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 281,
                    Name = "Overwatering and Poor Drainage",
                    Description = "Excess moisture leading to fungal diseases and root rot[2][6][4].",
                    Symptoms = "Yellowing, wilting, foul odor from soil, plant collapse.",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Plant in well-drained soil, avoid overwatering, improve drainage.",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 282,
                    Name = "Incorrect Light Conditions",
                    Description = "Too much or too little light affecting growth and vigor[4].",
                    Symptoms = "Leggy growth, sparse foliage (low light), scorched leaves (excess light).",
                    Causes = "Insufficient or excessive sunlight.",
                    Solutions = "Provide partial to full shade, avoid direct hot sun.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 283,
                    Name = "Temperature Stress",
                    Description = "Extreme temperatures causing wilting or dieback, especially in colder zones[7][4].",
                    Symptoms = "Wilting, leaf drop, dieback, plant death in severe cold.",
                    Causes = "Extreme heat or frost.",
                    Solutions = "Protect from frost with mulch, provide shade in extreme heat.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 284,
                    Name = "Invasive Growth",
                    Description = "Vinca minor can become invasive, spreading aggressively and outcompeting native plants[7].",
                    Symptoms = "Excessive spread, dense mats, reduced biodiversity.",
                    Causes = "Vigorous growth, self-seeding, lack of management.",
                    Solutions = "Monitor and control spread, remove unwanted runners, avoid planting in sensitive areas.",
                    Severity = "Medium",
                    Category = "Environmental"
                });
            }

            // Example: Check if the genus is "Eucalyptus" and species is "globulus" (Tasmanian Blue Gum)
            if (genus == "Eucalyptus" && species == "globulus")
            {
                // Add the most common problems for Eucalyptus globulus (Tasmanian Blue Gum)
                ListProblems.Add(new PlantProblem
                {
                    Id = 285,
                    Name = "Mycosphaerella Leaf Disease (MLD)/Teratosphaeria Leaf Disease",
                    Description = "Fungal disease causing leaf spots and premature defoliation, severely impacting growth and wood production[5][7][6].",
                    Symptoms = "Leaf spots of varying size, shape, and color; spots enlarge and coalesce; premature leaf drop; reduced photosynthetic capacity.",
                    Causes = "Fungal infection by Mycosphaerella spp. or Teratosphaeria spp., especially in humid or wet conditions.",
                    Solutions = "Plant resistant provenances, improve air circulation, apply fungicides if needed, remove fallen leaves to reduce inoculum.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 286,
                    Name = "Eucalyptus Canker (Botryosphaeria, Diplodia)",
                    Description = "Fungal disease causing sunken, dead areas on bark, leading to dieback and sometimes tree death[2][1][5].",
                    Symptoms = "Sunken, dark lesions on trunk and branches; leaf drop; branch dieback; tree death in severe cases.",
                    Causes = "Fungal infection by Botryosphaeria or Diplodia spp., often associated with stress or offsite planting.",
                    Solutions = "Maintain tree health, prune and destroy infected branches, ensure proper site selection, improve air circulation.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 287,
                    Name = "Leaf Spot Diseases (Various Fungi)",
                    Description = "Multiple fungal pathogens cause leaf spots, leading to reduced vigor and sometimes defoliation[3][6][2].",
                    Symptoms = "Irregular dark spots on leaves with yellow halos; leaf drop; reduced growth.",
                    Causes = "Fungal infection, humid or wet conditions, poor air circulation.",
                    Solutions = "Remove fallen leaves, improve air circulation, apply fungicides for severe infections.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 288,
                    Name = "Armillaria Root Rot",
                    Description = "Fungal disease causing root and lower trunk decay, leading to tree decline[5].",
                    Symptoms = "White fungal mats under bark, dark rhizomorphs, dead limbs, tree collapse.",
                    Causes = "Infection by Armillaria spp., often in stressed or waterlogged trees.",
                    Solutions = "Remove and destroy infected trees, improve drainage, avoid wounding, maintain tree health.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 289,
                    Name = "Red Gum Lerp Psyllid",
                    Description = "Insect pest forming protective waxy covers on leaves, causing leaf curling and reduced photosynthesis[2].",
                    Symptoms = "White, sugary lerps on leaf undersides; leaf curling; sticky residue; reduced growth.",
                    Causes = "Infestation by Glycaspis brimblecombei.",
                    Solutions = "Monitor for early signs, apply insecticidal treatments if needed, encourage natural predators.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 290,
                    Name = "Autumn Gum Moth",
                    Description = "Caterpillar pest feeding on foliage, causing defoliation and reduced growth[5].",
                    Symptoms = "Chewed leaves, defoliation, reduced vigor.",
                    Causes = "Infestation by Mnesampela privata.",
                    Solutions = "Monitor for caterpillars, handpick if possible, use biological controls.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 291,
                    Name = "Christmas Beetle",
                    Description = "Beetle pest feeding on leaves, causing skeletonization and defoliation[5].",
                    Symptoms = "Skeletonized leaves, defoliation, reduced vigor.",
                    Causes = "Infestation by Anoplognathus spp.",
                    Solutions = "Monitor for beetles, use traps or physical removal, encourage natural predators.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 292,
                    Name = "Leafblister Sawfly",
                    Description = "Larvae cause blister-like galls on leaves, reducing photosynthetic area[5].",
                    Symptoms = "Blister-like galls on leaves, leaf distortion, reduced vigor.",
                    Causes = "Infestation by Phylacteophaga froggatti.",
                    Solutions = "Monitor for galls, remove affected leaves, use biological controls.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 293,
                    Name = "Leaf Beetles (Chrysomelidae)",
                    Description = "Beetles feeding on foliage, causing holes and reduced vigor[5].",
                    Symptoms = "Chewed leaves, holes, reduced growth.",
                    Causes = "Infestation by various Chrysomelid beetles.",
                    Solutions = "Monitor for beetles, handpick or use traps, encourage natural predators.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 294,
                    Name = "Scale Insects",
                    Description = "Sap-sucking insects causing yellowing, leaf drop, and sooty mold[5][8].",
                    Symptoms = "Brown or white scales on leaves and stems, sticky residue, sooty mold.",
                    Causes = "Infestation by scale insects such as Eriococcus coriaceus.",
                    Solutions = "Encourage natural predators, use horticultural oil or insecticidal soap.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 295,
                    Name = "Bluegum Psyllid",
                    Description = "Sap-sucking insect causing leaf distortion and reduced growth[5].",
                    Symptoms = "Leaf distortion, sticky residue, reduced vigor.",
                    Causes = "Infestation by Ctenarytaina eucalypti.",
                    Solutions = "Monitor for psyllids, use insecticidal treatments if needed, encourage natural predators.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 296,
                    Name = "Drought Stress",
                    Description = "Water deficit causing wilting, leaf drop, and reduced growth[4][2].",
                    Symptoms = "Wilting, leaf drop, reduced growth, branch dieback.",
                    Causes = "Insufficient water, prolonged drought.",
                    Solutions = "Water deeply during dry periods, mulch to retain moisture, select appropriate planting sites.",
                    Severity = "High",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 297,
                    Name = "Fire Risk",
                    Description = "High flammability and risk of fire damage, especially in Mediterranean climates[4].",
                    Symptoms = "Burned foliage, trunk damage, tree death.",
                    Causes = "High oil content in leaves, drought, high temperatures.",
                    Solutions = "Maintain firebreaks, manage vegetation, plant fire-resistant species nearby.",
                    Severity = "High",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 298,
                    Name = "Poor Site Adaptation",
                    Description = "Stress and reduced growth due to unsuitable climate or soil conditions[1][4].",
                    Symptoms = "Stunted growth, leaf drop, increased susceptibility to pests and diseases.",
                    Causes = "Planting in unsuitable climates or soils, offsite planting.",
                    Solutions = "Select provenances adapted to local conditions, improve soil quality, ensure proper site selection.",
                    Severity = "High",
                    Category = "Environmental"
                });
            }

            // Example: Check if the genus is "Photinia" and species is "× fraseri" (Red Tip Photinia)
            if (genus == "Photinia" && species == "× fraseri")
            {
                // Add the most common problems for Photinia × fraseri (Red Tip Photinia)
                ListProblems.Add(new PlantProblem
                {
                    Id = 299,
                    Name = "Entomosporium Leaf Spot",
                    Description = "Fungal disease causing small, circular, red or brown spots on leaves, which can merge and lead to defoliation[2][4][6].",
                    Symptoms = "Circular red/brown spots on both leaf surfaces, spots with gray centers and reddish halos on mature leaves, premature leaf drop, cankers on twigs[2][6][7].",
                    Causes = "Infection by Entomosporium maculatum, especially in wet or humid conditions.",
                    Solutions = "Remove and destroy affected leaves and twigs, improve air circulation, avoid overhead watering, apply copper-based fungicides, plant in full sun[2][6][7].",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 300,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white, powdery patches on leaves and stems[1][2][5].",
                    Symptoms = "White or grayish powdery coating on leaves and stems, leaf distortion, reduced vigor.",
                    Causes = "Fungal infection, poor air circulation, damp conditions.",
                    Solutions = "Prune to improve air flow, avoid crowding, use fungicides if necessary, remove affected leaves[1][2][5].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 301,
                    Name = "Fireblight",
                    Description = "Bacterial disease causing shoot blight, oozing, and dieback[1][2][5].",
                    Symptoms = "Brown or blackened shoots, scorched appearance, oozing from affected parts, dieback.",
                    Causes = "Bacterial infection (Erwinia amylovora), warm and wet conditions.",
                    Solutions = "Prune infected branches well below affected areas, sterilize tools, apply copper bactericides, ensure good sanitation[1][2][5].",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 302,
                    Name = "Black Rot and Blight",
                    Description = "Fungal and bacterial diseases causing dark lesions and rapid wilting[5].",
                    Symptoms = "Dark lesions on leaves and stems, rapid wilting, plant decline.",
                    Causes = "Fungal or bacterial infection, wet conditions, poor air circulation.",
                    Solutions = "Remove and destroy affected parts, improve air circulation, use appropriate fungicides or bactericides.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 303,
                    Name = "Frost Damage",
                    Description = "Cold weather can cause leaf scorch and dieback, especially in young plants[2][8].",
                    Symptoms = "Blackened or scorched leaves, dieback of shoots, reduced vigor.",
                    Causes = "Sudden frost, exposure to cold winds.",
                    Solutions = "Protect young plants in winter, select sheltered planting sites, avoid late-season pruning[2][8].",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 304,
                    Name = "Pests (Aphids, Scale, Spider Mites)",
                    Description = "Sap-sucking insects causing distorted growth, sooty mold, and reduced vigor[3][5].",
                    Symptoms = "Sticky residue, sooty mold, distorted leaves, webbing (spider mites), yellowing.",
                    Causes = "Infestation by aphids, scale insects, or spider mites.",
                    Solutions = "Encourage natural predators, use insecticidal soap or neem oil, monitor regularly[3][5].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 305,
                    Name = "Physiological Leaf Spot",
                    Description = "Leaf spots caused by environmental stress rather than pathogens[7].",
                    Symptoms = "Irregular leaf spots, no gray centers, often in response to stress.",
                    Causes = "Poor growing conditions, water stress, nutrient imbalance, root damage.",
                    Solutions = "Improve growing conditions, ensure proper watering, correct nutrient deficiencies, avoid root disturbance[7].",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 306,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients leading to poor growth and leaf discoloration.",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, amend soil with compost.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 307,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases[1][8].",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead or diseased material.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Prunus" and species is "laurocerasus" (Cherry Laurel)
            if (genus == "Prunus" && species == "laurocerasus")
            {
                // Add the most common problems for Prunus laurocerasus (Cherry Laurel)
                ListProblems.Add(new PlantProblem
                {
                    Id = 308,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery spots on leaves, leading to distortion and unsightly foliage[1][2][4].",
                    Symptoms = "White powdery coating on leaves, leaf distortion, reduced vigor, leaf drop.",
                    Causes = "Infection by Podosphaera spp., especially in dry or humid conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 309,
                    Name = "Leaf Spot Fungi (Stigmina carpophila, Eupropolella britannica)",
                    Description = "Fungal diseases causing brown or black spots, sometimes with yellow halos, leading to holes and tattering[1][4][7].",
                    Symptoms = "Brown or black spots with yellow halos, spots on leaf edges, holes or tattered leaves as spots fall out.",
                    Causes = "Infection by Stigmina carpophila, Eupropolella britannica, or similar fungi; wet conditions.",
                    Solutions = "Remove fallen leaves, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 310,
                    Name = "Bacterial Shothole (Pseudomonas syringae, Xanthomonas arboricola pv. pruni)",
                    Description = "Bacterial disease causing small, water-soaked spots that become necrotic and fall out, leaving shotholes[1][4][7].",
                    Symptoms = "Small, water-soaked spots, brown/black necrotic areas, holes in leaves as tissue falls out.",
                    Causes = "Infection by Pseudomonas syringae or Xanthomonas arboricola pv. pruni; wet, humid weather.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering, use copper-based sprays if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 311,
                    Name = "Downy Mildew (Peronospora spp.)",
                    Description = "Fungal disease causing yellow/brown blotches on upper leaf surfaces and white cottony growth underneath[4].",
                    Symptoms = "Yellow/brown irregular blotches on upper leaves, whitish growth on undersides, leaf drop.",
                    Causes = "Infection by Peronospora spp.; wet, humid conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 312,
                    Name = "Fungal Shothole (Neofabraea actinidae, Eupropolella britannica)",
                    Description = "Fungal diseases causing greyish-white or dark brown lesions, leading to holes in leaves[4].",
                    Symptoms = "Greyish-white or dark brown patches, necrotic centers, holes as tissue falls out.",
                    Causes = "Infection by Neofabraea actinidae or Eupropolella britannica; wet conditions.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 313,
                    Name = "Vine Weevil",
                    Description = "Beetle larvae feeding on roots, adults feeding on leaves, causing significant damage[2][4].",
                    Symptoms = "Notched leaf edges, skeletonized leaves (adults), root damage, plant decline (larvae).",
                    Causes = "Infestation by Otiorhynchus sulcatus.",
                    Solutions = "Use targeted insecticides, encourage natural predators, monitor regularly.",
                    Severity = "High",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 314,
                    Name = "Scale Insects",
                    Description = "Sap-sucking insects causing yellowing, leaf drop, and reduced vigor[3][4].",
                    Symptoms = "Brown or white scales on stems and leaves, sticky residue, sooty mold, yellowing leaves.",
                    Causes = "Infestation by scale insects.",
                    Solutions = "Encourage natural predators, use horticultural oil or insecticidal soap.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 315,
                    Name = "Leaf Miner (Lyonetia clerkella)",
                    Description = "Larvae tunneling inside leaves, causing visible trails and possible leaf drop[4].",
                    Symptoms = "Long, winding tunnels inside leaves, leaf distortion, minor leaf drop.",
                    Causes = "Infestation by Lyonetia clerkella.",
                    Solutions = "Remove affected leaves, encourage natural predators, monitor regularly.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 316,
                    Name = "Common Green Capsid (Lygocoris pabulinus)",
                    Description = "Sap-sucking insect causing ragged holes in young leaves[4].",
                    Symptoms = "Ragged holes in young leaves, minor distortion.",
                    Causes = "Infestation by Lygocoris pabulinus.",
                    Solutions = "Monitor for damage, encourage natural predators, use insecticidal soap if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 317,
                    Name = "Citrus Red Mite (Panonychus citri)",
                    Description = "Mites causing silvering, yellowing, or speckling on leaves[4].",
                    Symptoms = "Silvering, yellowing, or speckling on leaves, defoliation in severe cases.",
                    Causes = "Infestation by Panonychus citri.",
                    Solutions = "Encourage natural predators, use miticides if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 318,
                    Name = "Poor Drainage",
                    Description = "Waterlogged soil leading to root damage, yellowing, and dieback[5][8].",
                    Symptoms = "Yellowing leaves, browning, dieback, reduced vigor.",
                    Causes = "Heavy clay soil, poor drainage, excess soil moisture.",
                    Solutions = "Improve soil drainage, plant in raised beds, avoid overwatering.",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 319,
                    Name = "Frost Damage",
                    Description = "Cold weather causing leaf browning and scorch, especially in winter or spring[5][6][8].",
                    Symptoms = "Brown or scorched leaves, leaf drop, reduced vigor.",
                    Causes = "Winter winds, low temperatures, late frosts, dehydration.",
                    Solutions = "Water deeply before ground freezes, protect from winds, select sheltered planting sites.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 320,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients leading to poor growth and leaf discoloration[8].",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, amend soil with compost.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 321,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can result in poor growth and increased susceptibility to pests and diseases[8].",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead or diseased material.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Dryopteris" and species is "filix-mas" (Male Fern)
            if (genus == "Dryopteris" && species == "filix-mas")
            {
                // Add the most common problems for Dryopteris filix-mas (Male Fern)
                ListProblems.Add(new PlantProblem
                {
                    Id = 322,
                    Name = "Aphid Infestations",
                    Description = "Occasional infestations by aphids, which can cause leaf curling and reduce vigor[6].",
                    Symptoms = "Clusters of small insects on fronds, sticky residue, sooty mold, leaf curling.",
                    Causes = "Infestation by aphids, especially in crowded or stressed plants.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 323,
                    Name = "Fungal Diseases",
                    Description = "Occasional fungal infections, such as leaf spot or rust, especially in damp conditions[6].",
                    Symptoms = "Spots or discoloration on fronds, leaf drop, reduced vigor.",
                    Causes = "Fungal pathogens, high humidity, poor air circulation.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected fronds, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 324,
                    Name = "Toxicity",
                    Description = "Male fern is highly toxic if ingested, with chemicals that can cause severe poisoning and even death[1][2][6].",
                    Symptoms = "Severe digestive upset, vision disturbances, liver damage, death if ingested.",
                    Causes = "Ingestion of plant material, especially rhizomes and young fronds.",
                    Solutions = "Do not ingest any part of the plant, keep out of reach of children and pets.",
                    Severity = "High",
                    Category = "Human/Pet Health"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 325,
                    Name = "Poor Soil Drainage",
                    Description = "Waterlogged soil can lead to root rot and reduced plant vigor[6].",
                    Symptoms = "Yellowing fronds, wilting, foul odor from soil, plant collapse.",
                    Causes = "Overwatering, heavy clay soil, poor drainage.",
                    Solutions = "Plant in well-drained soil, avoid overwatering, improve soil structure.",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 326,
                    Name = "Nutrient Imbalance",
                    Description = "Too much nitrogen or poor soil nutrition can cause foliage burn or poor growth[6].",
                    Symptoms = "Foliage burn, yellowing, poor growth.",
                    Causes = "Excessive fertilization, nutrient deficiency.",
                    Solutions = "Use slow-release fertilizer with balanced N-P-K, follow package instructions, avoid high nitrogen fertilizers.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 327,
                    Name = "Habitat Loss",
                    Description = "Destruction or alteration of native habitats can threaten wild populations[6].",
                    Symptoms = "Reduced wild populations, loss of genetic diversity.",
                    Causes = "Land use changes, habitat destruction.",
                    Solutions = "Support habitat conservation, avoid overharvesting from the wild.",
                    Severity = "Medium",
                    Category = "Environmental"
                });
            }

            // Example: Check if the genus is "Symphoricarpos" and species is "× chenaultii" (Chenault Snowberry)
            if (genus == "Symphoricarpos" && species == "× chenaultii")
            {
                // Add the most common problems for Symphoricarpos × chenaultii (Chenault Snowberry)
                ListProblems.Add(new PlantProblem
                {
                    Id = 328,
                    Name = "Anthracnose",
                    Description = "Fungal disease causing dark brown lesions on leaves, stems, and fruit; can lead to leaf drop and stunted growth[5][6][3].",
                    Symptoms = "Dark brown or black spots on leaves, stems, and fruit; lesions with greyish centers; leaf drop; blackened or deformed fruit.",
                    Causes = "Infection by Sphaceloma symphoricarpi or related fungi; wet, humid conditions.",
                    Solutions = "Remove and destroy affected plant parts, improve air circulation, avoid overhead watering, apply copper-based fungicide if needed[5][3].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 329,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery patches on leaves and stems[5][6][7].",
                    Symptoms = "White powdery coating on leaves and stems, leaf distortion, reduced vigor.",
                    Causes = "Fungal infection, poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 330,
                    Name = "Leaf Spot (Various Fungi)",
                    Description = "Various fungi cause brown or black spots on leaves, sometimes with yellow halos[5][4].",
                    Symptoms = "Brown or black spots on leaves, sometimes with yellow halos, leaf drop in severe cases.",
                    Causes = "Fungal infection, wet conditions, poor air circulation.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 331,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth and sooty mold[4][6][7].",
                    Symptoms = "Clusters of small insects on leaves and stems, sticky residue, sooty mold.",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap if needed.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 332,
                    Name = "Scale Insects",
                    Description = "Sap-sucking pests causing yellowing and leaf drop[6].",
                    Symptoms = "Brown or white scales on stems and leaves, sticky residue, yellowing leaves.",
                    Causes = "Infestation by scale insects.",
                    Solutions = "Encourage natural predators, use horticultural oil or insecticidal soap.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 333,
                    Name = "Cold Damage",
                    Description = "Leaf discoloration and dieback when temperatures drop below the plant's tolerance[1].",
                    Symptoms = "Leaf discoloration, dieback, reduced vigor.",
                    Causes = "Exposure to temperatures below cold tolerance.",
                    Solutions = "Plant in sheltered locations, protect from cold winds, mulch root zone in winter.",
                    Severity = "Low",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 334,
                    Name = "Moisture Stress",
                    Description = "Underwatering or overwatering leading to wilting, leaf scorch, or root rot[8][5].",
                    Symptoms = "Wilting, leaf scorch, limp or curling leaves, reduced growth.",
                    Causes = "Insufficient or excessive watering, poor drainage.",
                    Solutions = "Water regularly but avoid overwatering, ensure good drainage, mulch to retain moisture.",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 335,
                    Name = "Overcrowding and Poor Air Circulation",
                    Description = "Crowded conditions can increase susceptibility to fungal diseases[5][7].",
                    Symptoms = "Increased fungal disease, reduced vigor.",
                    Causes = "Too dense planting, lack of pruning.",
                    Solutions = "Prune to improve air circulation, avoid overcrowding.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Cocos" and species is "nucifera" (Coconut Palm)
            if (genus == "Cocos" && species == "nucifera")
            {
                // Add the most common problems for Cocos nucifera (Coconut Palm)
                ListProblems.Add(new PlantProblem
                {
                    Id = 336,
                    Name = "Bud Rot",
                    Description = "Fungal disease primarily caused by Phytophthora palmivora, leading to rapid destruction of the bud and eventual death of the palm if untreated[1][5][3].",
                    Symptoms = "Soft, brown to black rot of the bud, wilting of young leaves, foul odor, plant collapse.",
                    Causes = "Infection by Phytophthora palmivora or related species, especially in wet conditions.",
                    Solutions = "Remove and destroy infected palms, improve drainage, avoid overhead watering, apply systemic fungicides if detected early.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 337,
                    Name = "Gray Leaf Spot & Gray Leaf Blight",
                    Description = "Fungal diseases causing gray or brown spots on leaves, leading to defoliation and reduced vigor[1][3][2].",
                    Symptoms = "Gray or brown spots on leaves, coalescing into large blotches, premature leaf drop, reduced growth.",
                    Causes = "Infection by Pestalotiopsis palmarum or related fungi, high humidity.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering, apply fungicides if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 338,
                    Name = "Leaf Rot",
                    Description = "Fungal disease affecting the spear leaf and other fronds, compromising photosynthesis[1][5].",
                    Symptoms = "Rotting of spear leaf and other fronds, yellowing, reduced vigor, plant collapse in severe cases.",
                    Causes = "Infection by multiple fungi, including Colletotrichum gloeosporioides and Exserohilum rostratum.",
                    Solutions = "Remove affected leaves, improve drainage, avoid overhead watering, apply fungicides if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 339,
                    Name = "Stem Bleeding",
                    Description = "Chronic fungal disease causing dark, oozing lesions on the trunk, weakening the palm over time[1][3][5].",
                    Symptoms = "Dark, oozing lesions on trunk, reduced vigor, gradual decline.",
                    Causes = "Infection by Thielaviopsis paradoxa or similar fungi.",
                    Solutions = "Remove infected tissue, apply fungicidal paste to wounds, improve drainage, avoid wounding trunk.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 340,
                    Name = "Lethal Yellowing",
                    Description = "Phytoplasmal disease causing yellowing and premature nut fall, leading to rapid death[4][8].",
                    Symptoms = "Yellowing of lower leaves, premature nut fall, death of the apical meristem, rapid decline.",
                    Causes = "Phytoplasma infection, often spread by insect vectors.",
                    Solutions = "Plant resistant cultivars, remove and destroy infected palms, control insect vectors.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 341,
                    Name = "Red Ring Disease",
                    Description = "Nematode disease causing yellowing, wilting, and death of the palm[5][3].",
                    Symptoms = "Yellow or reddish band inside trunk, wilting, rapid death.",
                    Causes = "Infection by Bursaphelenchus cocophilus.",
                    Solutions = "Remove and destroy infected palms, avoid replanting in contaminated soil, control vector beetles.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 342,
                    Name = "Cadang-cadang Disease",
                    Description = "Viroid disease causing dwarfing, yellow leaf spots, and eventual death[6][3].",
                    Symptoms = "Yellow leaf spots, dwarfing, reduced nut production, gradual death over several years.",
                    Causes = "Infection by coconut cadang-cadang viroid, spread by contaminated tools or plant material.",
                    Solutions = "No cure; avoid importing infected plant material, practice strict sanitation.",
                    Severity = "High",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 343,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery spots on leaves, reducing photosynthesis[7][3].",
                    Symptoms = "White powdery patches on leaves, leaf distortion, reduced growth.",
                    Causes = "Infection by Oidium spp., high humidity, poor air circulation.",
                    Solutions = "Improve air circulation, avoid overhead watering, apply fungicides if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 342, // Note: This ID is a duplicate; should be 344 for uniqueness
                    Name = "Rust",
                    Description = "Fungal disease causing orange or brown pustules on leaf undersides[7][3].",
                    Symptoms = "Orange or brown pustules on leaf undersides, leaf yellowing, premature drop.",
                    Causes = "Infection by rust fungi, high humidity.",
                    Solutions = "Remove affected leaves, improve air circulation, apply fungicides if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                // Correcting the duplicate ID:
                ListProblems.Add(new PlantProblem
                {
                    Id = 344,
                    Name = "Black Rot",
                    Description = "Fungal disease causing dark, sunken lesions on fronds[7].",
                    Symptoms = "Dark, sunken lesions on fronds, leaf die-off, plant decline.",
                    Causes = "Fungal infection, poor drainage, waterlogged soil.",
                    Solutions = "Remove infected fronds, improve drainage, avoid overhead watering, apply fungicides if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 345,
                    Name = "Bacterial Bud Rot",
                    Description = "Bacterial disease causing rot of the apical meristem, leading to plant death[3][5].",
                    Symptoms = "Soft rot of the bud, wilting of young leaves, foul odor, plant collapse.",
                    Causes = "Infection by Erwinia spp., especially in wet conditions.",
                    Solutions = "Remove and destroy infected palms, improve drainage, avoid overhead watering.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 346,
                    Name = "Nutrient Deficiencies",
                    Description = "Lack of essential nutrients causing yellowing, stunting, and reduced nut production[2][7].",
                    Symptoms = "Yellowing or spotting of leaves, stunted growth, reduced yield.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply balanced fertilizer, amend soil as needed, monitor soil pH.",
                    Severity = "Medium",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 347,
                    Name = "Rhinoceros Beetle",
                    Description = "Beetle pest boring into the bud, causing severe damage or death[7].",
                    Symptoms = "Holes in bud, wilting of young leaves, plant decline.",
                    Causes = "Infestation by Oryctes rhinoceros.",
                    Solutions = "Use pheromone traps, remove breeding sites, apply biological controls.",
                    Severity = "High",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 348,
                    Name = "Coconut Mite",
                    Description = "Tiny pest causing browning and deformation of nuts[7].",
                    Symptoms = "Browning, deformation, and premature drop of nuts.",
                    Causes = "Infestation by Aceria guerreronis.",
                    Solutions = "Use resistant cultivars, apply miticides if needed, maintain orchard hygiene.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 349,
                    Name = "Red Palm Weevil",
                    Description = "Beetle larvae boring into trunk, causing rapid decline and death[7].",
                    Symptoms = "Wilting of fronds, holes in trunk, sawdust-like frass, plant collapse.",
                    Causes = "Infestation by Rhynchophorus ferrugineus.",
                    Solutions = "Use pheromone traps, inject insecticides, remove and destroy infested palms.",
                    Severity = "High",
                    Category = "Pest"
                });
            }

            // Example: Check if the genus is "Dieffenbachia" and species is "amoena"
            if (genus == "Dieffenbachia" && species == "amoena")
            {
                // Add the most common problems for Dieffenbachia amoena
                ListProblems.Add(new PlantProblem
                {
                    Id = 350,
                    Name = "Anthracnose",
                    Description = "Fungal disease causing circular to oval brown leaf spots with yellow halos, sometimes with tiny black fungal fruiting structures[1][7][4].",
                    Symptoms = "Brown spots with yellow halos, spots up to 2 inches in diameter, possible black fungal structures.",
                    Causes = "Colletotrichum gloeosporioides, overhead watering, wet foliage.",
                    Solutions = "Avoid overhead watering, apply fungicide to protect healthy plants, remove infected leaves.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 351,
                    Name = "Bacterial Leaf Spot",
                    Description = "Bacterial disease causing small gray or dark green spots that enlarge and become irregularly shaped, tan, dark brown, or black[1][7][4].",
                    Symptoms = "Small gray or dark green spots, irregular tan/dark brown/black lesions, leaf drop.",
                    Causes = "Erwinia carotovora or Erwinia chrysanthemi, wet foliage.",
                    Solutions = "Purchase disease-free plants, remove infected leaves, keep foliage dry, avoid overhead watering.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 352,
                    Name = "Wilt",
                    Description = "Lower leaves yellow, wilt, and die due to drought or inconsistent watering[1][3][2].",
                    Symptoms = "Yellowing and wilting of lower leaves, plant decline.",
                    Causes = "Drought, underwatering, or uneven soil moisture.",
                    Solutions = "Maintain even soil moisture, water regularly but allow soil to dry slightly between waterings.",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 353,
                    Name = "Marginal Leaf Burn",
                    Description = "Margins of leaves turn brown and die, often due to over-fertilization[1][2][3].",
                    Symptoms = "Brown leaf tips and margins, leaf death.",
                    Causes = "Excessive fertilization, salt buildup in soil.",
                    Solutions = "Avoid over-fertilizing, leach potting medium if needed, use slow-release fertilizer.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 354,
                    Name = "Myrothecium Leaf Spot",
                    Description = "Fungal disease causing large gray-brown, oval leaf spots at tips or margins, with concentric fungal rings on the underside[1][7][4].",
                    Symptoms = "Large gray-brown spots at leaf tips or margins, concentric rings on underside, leaf drop.",
                    Causes = "Myrothecium roridum, excessive nitrogen fertilization.",
                    Solutions = "Limit nitrogen fertilizer, apply fungicide, remove affected leaves.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 355,
                    Name = "Nitrogen Deficiency",
                    Description = "Plants show yellowing, smaller leaves, and short internodes due to lack of nitrogen[1][3].",
                    Symptoms = "Yellowing, small leaves, short internodes, reduced growth.",
                    Causes = "Insufficient fertilization, poor soil.",
                    Solutions = "Apply a balanced fertilizer solution, amend soil as needed.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 356,
                    Name = "Virus (Dasheen Mosaic Virus)",
                    Description = "Viral disease causing mosaic patterns, stunting, and deformed leaves[1][7].",
                    Symptoms = "Light green mosaic patterns on leaves, stunting, deformed leaves, plant decline.",
                    Causes = "Dasheen mosaic virus, spread by aphids or contaminated tools.",
                    Solutions = "Discard infected plants, control aphids, disinfect tools.",
                    Severity = "High",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 357,
                    Name = "Root Rot",
                    Description = "Fungal disease causing yellowing, wilting, and plant collapse due to waterlogged soil[5][6][3].",
                    Symptoms = "Yellowing leaves, wilting, mushy roots, plant collapse.",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Allow soil to dry between waterings, ensure good drainage, repot if needed.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 358,
                    Name = "Spider Mites",
                    Description = "Tiny arachnids causing stippling, discoloration, and webbing on leaves[3][5][6].",
                    Symptoms = "Stippling, discoloration, fine webbing, leaf drop.",
                    Causes = "Low humidity, dry conditions, stress.",
                    Solutions = "Increase humidity, spray with water, use insecticidal soap or neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 359,
                    Name = "Mealybugs",
                    Description = "White, cottony insects feeding on sap, causing distortion and sticky residue[3][5][6].",
                    Symptoms = "White cottony masses, sticky residue, distorted leaves.",
                    Causes = "Low humidity, stress, poor plant hygiene.",
                    Solutions = "Remove by hand, use insecticidal soap or neem oil, isolate infected plants.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 360,
                    Name = "Scale Insects",
                    Description = "Sap-sucking insects causing yellowing, leaf drop, and sticky residue[3][5][6].",
                    Symptoms = "Brown or white bumps on stems and leaves, sticky residue, yellowing leaves.",
                    Causes = "Low humidity, stress, poor plant hygiene.",
                    Solutions = "Remove by hand, use insecticidal soap or horticultural oil, isolate infected plants.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 361,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth, yellowing, and sooty mold[5][6].",
                    Symptoms = "Clusters of small insects, sticky residue, sooty mold, distorted leaves.",
                    Causes = "New growth, poor plant hygiene.",
                    Solutions = "Spray with water, use insecticidal soap or neem oil.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 362,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can increase susceptibility to pests and diseases[3][8].",
                    Symptoms = "Weak growth, susceptibility to pests and diseases.",
                    Causes = "Inconsistent watering, lack of fertilization, poor plant hygiene.",
                    Solutions = "Water and fertilize regularly, inspect plants frequently, maintain good plant hygiene.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Glaucium" and species is "flavum" (Yellow Horned Poppy)
            if (genus == "Glaucium" && species == "flavum")
            {
                // Add notable problems and characteristics for Glaucium flavum (Yellow Horned Poppy)
                ListProblems.Add(new PlantProblem
                {
                    Id = 363,
                    Name = "Toxicity to Humans and Animals",
                    Description = "All parts of the plant, especially the latex, contain toxic alkaloids and can cause severe poisoning if ingested or applied improperly[3][1][2].",
                    Symptoms = "Stomachache, nausea, vomiting, thirst, dry mouth, breathing difficulties, decreased heart rate; in severe cases: confusion, numbness, hypotension, respiratory failure, death[3].",
                    Causes = "Ingestion or contact with plant sap; consumption by livestock.",
                    Solutions = "Avoid ingestion and skin contact, keep away from animals, seek medical attention if exposed.",
                    Severity = "High",
                    Category = "Human/Pet Health"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 364,
                    Name = "Skin Irritation and Blistering",
                    Description = "Contact with the latex or sap can cause dermatitis, blistering, and burns[3].",
                    Symptoms = "Redness, irritation, blisters, burns, scabs on skin.",
                    Causes = "Direct contact with plant latex or sap.",
                    Solutions = "Wash affected area immediately, avoid contact, wear gloves when handling.",
                    Severity = "Medium",
                    Category = "Human/Pet Health"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 365,
                    Name = "Eye Irritation",
                    Description = "Plant latex can cause severe irritation, conjunctivitis, or ulcers if it contacts the eyes[3].",
                    Symptoms = "Redness, pain, irritation, conjunctivitis, ulcers.",
                    Causes = "Contact of latex with eyes.",
                    Solutions = "Flush eyes with water immediately, seek medical attention.",
                    Severity = "High",
                    Category = "Human/Pet Health"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 366,
                    Name = "Livestock Poisoning",
                    Description = "Toxic to livestock, causing drowsiness, lack of appetite, excessive salivation, and reduced milk production[3].",
                    Symptoms = "Unsteady gait, drowsiness, loss of appetite, salivation, reduced milk production.",
                    Causes = "Consumption of plant material by animals.",
                    Solutions = "Remove plant from grazing areas, monitor livestock, provide veterinary care if exposed.",
                    Severity = "High",
                    Category = "Animal Health"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 367,
                    Name = "Weedy or Invasive Growth",
                    Description = "Can become invasive in certain regions, displacing native vegetation[8].",
                    Symptoms = "Aggressive spread, dense stands, reduced biodiversity.",
                    Causes = "Vigorous growth, self-seeding, lack of management.",
                    Solutions = "Monitor and control spread, remove unwanted plants, avoid planting in sensitive areas.",
                    Severity = "Medium",
                    Category = "Environmental"
                });
            }

            // Example: Check if the genus is "Paeonia" and species is "lactiflora" (with optional cultivar "Edulis Superba")
            if (genus == "Paeonia" && (species == "lactiflora" || species == "edulis")) // Note: "edulis" is typically a cultivar, not a species
            {
                // Add the most common problems for Paeonia lactiflora (including 'Edulis Superba')
                ListProblems.Add(new PlantProblem
                {
                    Id = 368,
                    Name = "Botrytis Blight (Gray Mold)",
                    Description = "Most common fungal disease, causing blackening of leaves, stems, and flower buds, especially in wet conditions[2][4][7].",
                    Symptoms = "Brown/black spots on shoots, wilting, gray mold on affected parts, collapse of young growth.",
                    Causes = "Botrytis cinerea or Botrytis paeoniae, damp weather, poor air circulation.",
                    Solutions = "Remove and destroy infected parts, avoid overhead watering, improve air circulation, apply fungicide in spring.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 369,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease producing white powdery patches on leaves and stems[2][6][7].",
                    Symptoms = "White powdery coating on foliage, leaf distortion, premature leaf drop.",
                    Causes = "Erysiphe spp., humid conditions, poor air circulation.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide or homemade remedy (baking soda/horticultural oil).",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 370,
                    Name = "Leaf Blotch (Measles)",
                    Description = "Fungal disease causing reddish-purple spots that merge into blotches on leaves and stems[5][6].",
                    Symptoms = "Reddish-purple spots, large blotches, leaf drop.",
                    Causes = "Cladosporium paeoniae, wet conditions.",
                    Solutions = "Remove infected leaves, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 371,
                    Name = "Phytophthora Blight and Root Rot",
                    Description = "Fungal disease causing dark brown to black, leathery lesions on stems and roots, leading to wilting and collapse[2][5][6].",
                    Symptoms = "Dark brown/black lesions, wilting, root and crown rot, plant collapse.",
                    Causes = "Phytophthora spp., waterlogged soil.",
                    Solutions = "Improve drainage, avoid overwatering, remove and destroy infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 372,
                    Name = "Bacterial Blight",
                    Description = "Bacterial disease causing spots with red rings or yellow halos[5].",
                    Symptoms = "Spots with red rings or yellow halos, leaf drop, plant decline.",
                    Causes = "Xanthomonas spp., wet conditions.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 373,
                    Name = "Root Rot (Various Fungi)",
                    Description = "Fungal disease causing yellowing, wilting, and foul odor from roots[2][5][6].",
                    Symptoms = "Yellowing leaves, wilting, foul odor from roots, plant collapse.",
                    Causes = "Fusarium, Rhizoctonia, or Thielaviopsis, waterlogged soil.",
                    Solutions = "Remove infected plants, improve drainage, avoid overwatering.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 374,
                    Name = "Peony Wilt",
                    Description = "Fungal disease causing brown or black streaks on stems, wilting, and sudden collapse[2][6].",
                    Symptoms = "Brown/black streaks on stems, wilting, collapse.",
                    Causes = "Fusarium, Rhizoctonia, or Verticillium, wet conditions.",
                    Solutions = "Remove infected stems, sterilize tools, avoid splashing water on foliage.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 375,
                    Name = "Viral Diseases",
                    Description = "Various viruses causing mottling, ringspots, and stunting[5][8].",
                    Symptoms = "Mottled leaves, ringspots, stunted growth, poor flowering.",
                    Causes = "Tobacco rattle, tomato spotted wilt, alfalfa mosaic viruses, spread by insects or tools.",
                    Solutions = "Remove and destroy infected plants, control insect vectors, sanitize tools.",
                    Severity = "Medium",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 376,
                    Name = "Overwatering and Poor Drainage",
                    Description = "Excess moisture leading to root and fungal diseases[6][5].",
                    Symptoms = "Yellowing, wilting, foul odor from soil, plant collapse.",
                    Causes = "Overwatering, heavy soil, poor drainage.",
                    Solutions = "Improve drainage, avoid overwatering, plant in well-drained soil.",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 377,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients causing poor growth and leaf discoloration[6].",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, amend soil with compost.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 378,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can increase susceptibility to pests and diseases[8].",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, prune as needed, fertilize in spring, remove dead or diseased material.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Spathiphyllum" and species is "wallisii" (Peace Lily)
            if (genus == "Spathiphyllum" && species == "wallisii")
            {
                // Add the most common problems for Spathiphyllum wallisii (Peace Lily)
                ListProblems.Add(new PlantProblem
                {
                    Id = 379,
                    Name = "Cylindrocladium Root Rot",
                    Description = "Fungal disease causing root and stem rot, leading to yellowing and wilting of leaves; petioles may develop dark brown spots[1][4][5].",
                    Symptoms = "Yellowing lower leaves, wilting, dark brown spots on petioles, blackened or mushy roots.",
                    Causes = "Overwatering, poor drainage, infection by Cylindrocladium spathiphylli.",
                    Solutions = "Discard severely infected plants, repot in fresh soil, sterilize pots, improve drainage, avoid overwatering.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 380,
                    Name = "Pythium Root Rot",
                    Description = "Water mold causing root rot, yellowing, and wilting; roots become black and mushy[1][4][5].",
                    Symptoms = "Yellowing leaves, wilting, black and mushy roots.",
                    Causes = "Overwatering, poor drainage, infection by Pythium spp.",
                    Solutions = "Repot in fresh soil, improve drainage, avoid overwatering, use soil drench fungicide if early stage.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 381,
                    Name = "Leaf Blight (Phytophthora)",
                    Description = "Fungal-like disease causing black or brown dead spots on leaves, which may expand into larger lesions[1][2][4].",
                    Symptoms = "Black or brown dead spots on leaves, wet or mushy spots, expanding lesions.",
                    Causes = "Infection by Phytophthora nicotianae or P. parasitica, high humidity, splashing water.",
                    Solutions = "Remove affected leaves, avoid overhead watering, repot in fresh soil, sterilize pots.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 382,
                    Name = "Anthracnose",
                    Description = "Fungal disease causing dark, sunken spots on leaves, often in warm, moist conditions[5].",
                    Symptoms = "Dark, sunken spots on leaves, rapid spread.",
                    Causes = "Infection by Colletotrichum or related fungi, poor air circulation, high humidity.",
                    Solutions = "Prune affected leaves, improve air circulation, apply fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 383,
                    Name = "Dasheen Mosaic Virus",
                    Description = "Viral disease causing yellow to light green mosaic patterns on new leaves[1][5].",
                    Symptoms = "Mosaic patterns (yellow, light green) on leaves, generally mild effect on plant health.",
                    Causes = "Spread by insects, infected tools, or soil.",
                    Solutions = "No cure; remove infected plant to prevent spread, control insect vectors.",
                    Severity = "Low",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 384,
                    Name = "Spider Mites",
                    Description = "Tiny arachnids causing stippling, webbing, and leaf discoloration[3][6][8].",
                    Symptoms = "Fine webbing, stippling, yellowing leaves.",
                    Causes = "Low humidity, dry conditions, stress.",
                    Solutions = "Increase humidity, spray with water, use insecticidal soap or neem oil.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 385,
                    Name = "Mealybugs",
                    Description = "White, cottony insects feeding on sap, causing distortion and sticky residue[6][8].",
                    Symptoms = "White cottony masses, sticky residue, distorted leaves.",
                    Causes = "Low humidity, stress, poor plant hygiene.",
                    Solutions = "Remove by hand, use insecticidal soap or neem oil, isolate infected plants.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 386,
                    Name = "Scale Insects",
                    Description = "Sap-sucking pests causing yellowing, leaf drop, and sticky residue[6][8].",
                    Symptoms = "Brown or white bumps on stems and leaves, sticky residue, yellowing leaves.",
                    Causes = "Low humidity, stress, poor plant hygiene.",
                    Solutions = "Remove by hand, use horticultural oil or insecticidal soap, isolate infected plants.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 387,
                    Name = "Fungus Gnats",
                    Description = "Small flies whose larvae feed on roots, causing stunting and yellowing[6].",
                    Symptoms = "Tiny flies near soil, yellowing leaves, stunted growth.",
                    Causes = "Overwatering, moist soil.",
                    Solutions = "Allow soil to dry between waterings, use yellow sticky traps, apply biological controls.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 388,
                    Name = "Thrips",
                    Description = "Tiny insects causing discolored, distorted leaves[5].",
                    Symptoms = "Discolored, distorted leaves, stippling.",
                    Causes = "Infestation by thrips, especially in dry conditions.",
                    Solutions = "Isolate plant, rinse leaves, use insecticidal soap.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 389,
                    Name = "Magnesium Deficiency",
                    Description = "Nutrient deficiency causing yellowing between leaf veins while veins remain green[6].",
                    Symptoms = "Yellowing between veins (interveinal chlorosis), stunted growth.",
                    Causes = "Insufficient magnesium, poor fertilization.",
                    Solutions = "Apply magnesium sulfate (Epsom salt), use balanced fertilizer.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 390,
                    Name = "Overwatering/Poor Drainage",
                    Description = "Excess moisture leading to root rot, yellowing, and wilting[1][5][6].",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil.",
                    Causes = "Overwatering, poor drainage, heavy soil.",
                    Solutions = "Improve drainage, allow soil to dry between waterings, repot if necessary.",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 391,
                    Name = "Toxicity to Pets and Humans",
                    Description = "Plant contains insoluble calcium oxalate crystals, causing irritation if ingested[8].",
                    Symptoms = "Mouth irritation, vomiting, difficulty swallowing.",
                    Causes = "Ingestion of plant material by pets or children.",
                    Solutions = "Keep out of reach, seek medical attention if ingested.",
                    Severity = "Medium",
                    Category = "Human/Pet Health"
                });
            }

            // Example: Check if the genus is "Lilium" and cultivar is "Stargazer"
            if (genus == "Lilium" && species == "Stargazer")
            {
                // Add the most common problems for Lilium 'Stargazer' (Stargazer Lily)
                ListProblems.Add(new PlantProblem
                {
                    Id = 392,
                    Name = "Botrytis Blight (Gray Mold)",
                    Description = "Fungal disease causing reddish-brown or gray spots on leaves and stems, sometimes leading to collapse[1][3][5].",
                    Symptoms = "Oval or circular reddish-brown spots with pale centers, gray fuzzy growth in humid conditions, spots may merge, leaves and stems may collapse[5][6][7].",
                    Causes = "Botrytis elliptica or Botrytis cinerea, cool and humid weather, crowded conditions.",
                    Solutions = "Remove and destroy infected plant parts, improve air circulation, avoid overhead watering, apply fungicide if needed[1][5][6].",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 393,
                    Name = "Bulb Rot (Fusarium, Rhizoctonia)",
                    Description = "Soil-borne fungal diseases causing yellowing foliage and soft, brown, rotting bulbs[3][5][8].",
                    Symptoms = "Yellowing leaves, brown or soft, rotting bulb tissue, foul odor from soil[2][3][8].",
                    Causes = "Fusarium oxysporum f. sp. lilii, Rhizoctonia solani, overwatering, poor drainage.",
                    Solutions = "Remove and destroy infected bulbs, avoid planting lilies in contaminated soil for several years, buy healthy bulbs, improve drainage[3][5][8].",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 394,
                    Name = "Lily Mosaic Virus",
                    Description = "Viral disease causing yellow streaking and distortion of leaves and flowers[1][3][8].",
                    Symptoms = "Yellow streaks on leaves, distorted or fewer flowers, stunted growth[3][8].",
                    Causes = "Virus spread by aphids or contaminated tools.",
                    Solutions = "Remove and destroy infected plants, control aphids, sanitize tools[1][3][8].",
                    Severity = "Medium",
                    Category = "Virus"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 395,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth, sticky residue, and sooty mold[2][7].",
                    Symptoms = "Clusters of small insects on stems and leaves, sticky residue, distorted leaves.",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators (ladybugs, lacewings), spray with water, use insecticidal soap or neem oil[2][7].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 396,
                    Name = "Spider Mites",
                    Description = "Tiny arachnids causing stippling, webbing, and leaf discoloration[2][7].",
                    Symptoms = "Fine webbing, stippling, yellowing leaves.",
                    Causes = "Low humidity, dry conditions, stress.",
                    Solutions = "Increase humidity, spray with water, use insecticidal soap or neem oil[2][7].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 397,
                    Name = "Mealybugs",
                    Description = "White, cottony insects feeding on sap, causing distortion and sticky residue[2][7].",
                    Symptoms = "White cottony masses, sticky residue, distorted leaves.",
                    Causes = "Low humidity, stress, poor plant hygiene.",
                    Solutions = "Remove by hand, use insecticidal soap or neem oil, isolate infected plants[2][7].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 398,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery patches on leaves[4][7].",
                    Symptoms = "White powdery coating on leaves, leaf distortion, reduced vigor.",
                    Causes = "Fungal infection, poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed[4][7].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 399,
                    Name = "Overwatering and Root Rot",
                    Description = "Excess moisture leading to yellowing, wilting, and root/bulb rot[2][3][8].",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, mushy roots or bulbs.",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Improve drainage, allow soil to dry between waterings, repot if necessary[2][3][8].",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 400,
                    Name = "Inadequate Light",
                    Description = "Too little light can result in weak growth and poor flowering[2][7].",
                    Symptoms = "Leggy stems, weak growth, few or no flowers.",
                    Causes = "Insufficient sunlight, too much shade.",
                    Solutions = "Plant in a location with full sun to partial shade, ensure at least 6 hours of sunlight daily[2][7].",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 401,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients causing poor growth and leaf discoloration[2].",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, amend soil with compost.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 402,
                    Name = "Irregular Maintenance",
                    Description = "Neglect or irregular maintenance can increase susceptibility to pests and diseases[8].",
                    Symptoms = "Weak growth, susceptibility to diseases and pests.",
                    Causes = "Too little water, lack of pruning, no fertilization.",
                    Solutions = "Water regularly, remove spent flowers and foliage, fertilize in spring, monitor for pests and diseases.",
                    Severity = "Low",
                    Category = "Maintenance"
                });
            }

            // Example: Check if the genus is "Clematis" and species is "armandii" (Armand’s Clematis)
            if (genus == "Clematis" && species == "armandii")
            {
                // Add the most common problems for Clematis armandii
                ListProblems.Add(new PlantProblem
                {
                    Id = 403,
                    Name = "Clematis Wilt",
                    Description = "Fungal disease causing rapid wilting, blackening, and collapse of stems and leaves[2][4][5].",
                    Symptoms = "Sudden wilting, blackened and dry stems and leaves, collapse of affected parts.",
                    Causes = "Infection by Phoma clematidina (formerly Ascochyta), mainly in large-flowered hybrids, but can affect all clematis[2][4][5].",
                    Solutions = "Remove and destroy affected stems immediately, improve air circulation, avoid overhead watering, apply fungicide if early stage.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 404,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves and stems, leading to distortion and discoloration[2][6][8].",
                    Symptoms = "White powdery patches on leaves and stems, leaf distortion, reduced vigor.",
                    Causes = "Fungal infection, poor air circulation, water stress.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed[2][6][8].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 405,
                    Name = "Leaf Spot Diseases",
                    Description = "Fungal diseases causing tan or brown spots on leaves, sometimes with yellow halos[2][6].",
                    Symptoms = "Tan or brown spots, sometimes with yellow halos, leaf drop in severe cases.",
                    Causes = "Infection by Botrytis, Cercospora, Cylindrosporium, Phyllosticta, or Septoria spp.[2].",
                    Solutions = "Remove infected leaves, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 406,
                    Name = "Root Rot",
                    Description = "Fungal disease causing root decay, yellowing, and wilting of foliage[6].",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, plant decline.",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Plant in well-draining soil, avoid overwatering, remove and destroy severely infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 407,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth, sticky residue, and sooty mold[3][6][7].",
                    Symptoms = "Clusters of small insects on stems and leaves, sticky residue, distorted leaves.",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap or neem oil[3][6][7].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 408,
                    Name = "Spider Mites",
                    Description = "Tiny arachnids causing stippling, webbing, and leaf discoloration[3][7].",
                    Symptoms = "Fine webbing, stippling, yellowing leaves.",
                    Causes = "Low humidity, dry conditions, stress.",
                    Solutions = "Increase humidity, spray with water, use insecticidal soap or neem oil[3][7].",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 409,
                    Name = "Scale Insects",
                    Description = "Sap-sucking pests causing yellowing, leaf drop, and sticky residue[7].",
                    Symptoms = "Brown or white bumps on stems and leaves, sticky residue, yellowing leaves.",
                    Causes = "Infestation by scale insects.",
                    Solutions = "Remove by hand, use horticultural oil or insecticidal soap.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 410,
                    Name = "Mealybugs",
                    Description = "White, cottony insects feeding on sap, causing distortion and sticky residue[3][7].",
                    Symptoms = "White cottony masses, sticky residue, distorted leaves.",
                    Causes = "Low humidity, stress, poor plant hygiene.",
                    Solutions = "Remove by hand, use insecticidal soap or neem oil, isolate infected plants.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 411,
                    Name = "Fungus Gnats",
                    Description = "Small flies whose larvae feed on roots, causing stunting and yellowing[7].",
                    Symptoms = "Tiny flies near soil, yellowing leaves, stunted growth.",
                    Causes = "Overwatering, moist soil.",
                    Solutions = "Allow soil to dry between waterings, use yellow sticky traps, apply biological controls.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 412,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients causing poor growth and leaf discoloration[6].",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, amend soil with compost.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 413,
                    Name = "Pruning Problems",
                    Description = "Incorrect pruning can result in loss of flowers, as Clematis armandii blooms on old wood[6].",
                    Symptoms = "Reduced or absent flowering.",
                    Causes = "Pruning at wrong time, cutting off flower buds.",
                    Solutions = "Prune immediately after flowering, avoid heavy pruning in spring or autumn.",
                    Severity = "Medium",
                    Category = "Cultural"
                });
            }

            // Example: Check if the genus is "Clematis" and species is "armandii" (Armand’s Clematis)
            if (genus == "Clematis" && species == "armandii")
            {
                // Add the most common problems for Clematis armandii
                ListProblems.Add(new PlantProblem
                {
                    Id = 403,
                    Name = "Clematis Wilt",
                    Description = "Fungal disease causing rapid wilting, blackening, and collapse of stems and leaves[2][4][5].",
                    Symptoms = "Sudden wilting, blackened and dry stems and leaves, collapse of affected parts.",
                    Causes = "Infection by Phoma clematidina (formerly Ascochyta), mainly in large-flowered hybrids, but can affect all clematis[2][4][5].",
                    Solutions = "Remove and destroy affected stems immediately, improve air circulation, avoid overhead watering, apply fungicide if early stage.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 404,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery coating on leaves and stems, leading to distortion and discoloration[2][6][8].",
                    Symptoms = "White powdery patches on leaves and stems, leaf distortion, reduced vigor.",
                    Causes = "Fungal infection, poor air circulation, water stress.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed[2][6][8].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 405,
                    Name = "Leaf Spot Diseases",
                    Description = "Fungal diseases causing tan or brown spots on leaves, sometimes with yellow halos[2][6].",
                    Symptoms = "Tan or brown spots, sometimes with yellow halos, leaf drop in severe cases.",
                    Causes = "Infection by Botrytis, Cercospora, Cylindrosporium, Phyllosticta, or Septoria spp.[2].",
                    Solutions = "Remove infected leaves, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 406,
                    Name = "Root Rot",
                    Description = "Fungal disease causing root decay, yellowing, and wilting of foliage[6].",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, plant decline.",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Plant in well-draining soil, avoid overwatering, remove and destroy severely infected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 407,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth, sticky residue, and sooty mold[3][6][7].",
                    Symptoms = "Clusters of small insects on stems and leaves, sticky residue, distorted leaves.",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap or neem oil[3][6][7].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 408,
                    Name = "Spider Mites",
                    Description = "Tiny arachnids causing stippling, webbing, and leaf discoloration[3][7].",
                    Symptoms = "Fine webbing, stippling, yellowing leaves.",
                    Causes = "Low humidity, dry conditions, stress.",
                    Solutions = "Increase humidity, spray with water, use insecticidal soap or neem oil[3][7].",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 409,
                    Name = "Scale Insects",
                    Description = "Sap-sucking pests causing yellowing, leaf drop, and sticky residue[7].",
                    Symptoms = "Brown or white bumps on stems and leaves, sticky residue, yellowing leaves.",
                    Causes = "Infestation by scale insects.",
                    Solutions = "Remove by hand, use horticultural oil or insecticidal soap.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 410,
                    Name = "Mealybugs",
                    Description = "White, cottony insects feeding on sap, causing distortion and sticky residue[3][7].",
                    Symptoms = "White cottony masses, sticky residue, distorted leaves.",
                    Causes = "Low humidity, stress, poor plant hygiene.",
                    Solutions = "Remove by hand, use insecticidal soap or neem oil, isolate infected plants.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 411,
                    Name = "Fungus Gnats",
                    Description = "Small flies whose larvae feed on roots, causing stunting and yellowing[7].",
                    Symptoms = "Tiny flies near soil, yellowing leaves, stunted growth.",
                    Causes = "Overwatering, moist soil.",
                    Solutions = "Allow soil to dry between waterings, use yellow sticky traps, apply biological controls.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 412,
                    Name = "Nutrient Deficiency",
                    Description = "Lack of essential nutrients causing poor growth and leaf discoloration[6].",
                    Symptoms = "Yellowing leaves, poor growth, leaf drop.",
                    Causes = "Poor soil, insufficient fertilization.",
                    Solutions = "Apply a balanced fertilizer, amend soil with compost.",
                    Severity = "Low",
                    Category = "Nutrition"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 413,
                    Name = "Pruning Problems",
                    Description = "Incorrect pruning can result in loss of flowers, as Clematis armandii blooms on old wood[6].",
                    Symptoms = "Reduced or absent flowering.",
                    Causes = "Pruning at wrong time, cutting off flower buds.",
                    Solutions = "Prune immediately after flowering, avoid heavy pruning in spring or autumn.",
                    Severity = "Medium",
                    Category = "Cultural"
                });
            }

            // Example: Check if the genus is "Lithodora" and species is "diffusa"
            if (genus == "Lithodora" && species == "diffusa")
            {
                // Add the most common problems for Lithodora diffusa
                ListProblems.Add(new PlantProblem
                {
                    Id = 414,
                    Name = "Stem Rot (Phoma)",
                    Description = "Fungal disease causing stem rots, stem cankers, branch dieback, and crown rot[1].",
                    Symptoms = "Stem rots, cankers, branch dieback, crown rot, plant collapse.",
                    Causes = "Infection by Phoma sp., often in wet or poorly drained conditions.",
                    Solutions = "Practice sanitation, avoid wounding plants, dispose of diseased plants and material, clean growing area after production cycle[1].",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 415,
                    Name = "Black Root Rot (Berkeleyomyces, formerly Thielaviopsis basicola)",
                    Description = "Soil-borne fungus causing root rot, chlorosis, stunting, and scattered branch dieback[3].",
                    Symptoms = "Chlorotic and stunted plants, scattered branch dieback, brown to black root lesions.",
                    Causes = "Infection by Berkeleyomyces sp. (formerly Thielaviopsis basicola), especially in neutral to alkaline, moist soils.",
                    Solutions = "Use soilless media, treat field soil with steam or fumigants, dispose of diseased plants, maintain clean propagation and growing areas[3].",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 416,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery patches on leaves and stems[2][5].",
                    Symptoms = "White powdery coating on leaves and stems, leaf distortion, reduced vigor.",
                    Causes = "Fungal infection, poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed[2][5].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 417,
                    Name = "Root and Crown Rot (Phytophthora, Pythium)",
                    Description = "Water molds causing root and crown rot, wilting, and plant death[4].",
                    Symptoms = "Wilting, yellowing leaves, blackened roots, plant collapse.",
                    Causes = "Infection by Phytophthora or Pythium spp., overwatering, poor drainage.",
                    Solutions = "Improve drainage, avoid overwatering, remove and destroy infected plants[4][5].",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 418,
                    Name = "Bacterial Leaf Spot",
                    Description = "Bacterial disease causing translucent spots with yellow edges and reddish centers, disfigured flowers[6].",
                    Symptoms = "Translucent spots with yellow edges, reddish centers, disfigured flower heads.",
                    Causes = "Bacterial infection, cooler temperatures, wet conditions.",
                    Solutions = "Remove infected plants, avoid overhead watering, avoid working with wet plants[6].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 419,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth, sticky residue, and sooty mold[4][5][6].",
                    Symptoms = "Clusters of small insects on stems and leaves, sticky residue, distorted leaves.",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap or neem oil[4][5][6].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 420,
                    Name = "Spider Mites",
                    Description = "Tiny arachnids causing stippling, webbing, and leaf discoloration[4][5][6].",
                    Symptoms = "Fine webbing, stippling, yellowing leaves.",
                    Causes = "Low humidity, dry conditions, stress.",
                    Solutions = "Increase humidity, spray with water, use insecticidal soap or neem oil[4][5][6].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 421,
                    Name = "Whitefly",
                    Description = "Small, white, flying insects causing yellowing and reduced vigor[6].",
                    Symptoms = "Tiny white insects on leaf undersides, yellowing leaves, sticky residue.",
                    Causes = "Infestation by whiteflies.",
                    Solutions = "Use sticky traps, spray with water, use insecticidal soap or neem oil[6].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 422,
                    Name = "Root-Knot Nematodes",
                    Description = "Microscopic worms causing root galls, wilting, and stunting[6].",
                    Symptoms = "Wilting, stunted growth, root galls.",
                    Causes = "Infestation by root-knot nematodes (Meloidogyne spp.).",
                    Solutions = "Remove and discard infected plants, consult local extension service for advice[6].",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 423,
                    Name = "Overwatering/Waterlogged Soil",
                    Description = "Excess moisture leading to root and stem rot, wilting, and plant death[5][7].",
                    Symptoms = "Wilting, yellowing leaves, foul odor from soil, plant collapse.",
                    Causes = "Overwatering, heavy clay soil, poor drainage.",
                    Solutions = "Improve drainage, allow soil to dry between waterings, use well-draining soil[5][7].",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 424,
                    Name = "Poor Soil Quality/Compaction",
                    Description = "Heavy clay or compacted soil can restrict root growth and lead to poor vigor[5][7].",
                    Symptoms = "Stunted growth, poor flowering, chlorosis.",
                    Causes = "Heavy clay soil, compaction, poor aeration.",
                    Solutions = "Amend soil with organic matter, avoid compaction, use well-draining soil[5][7].",
                    Severity = "Medium",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 425,
                    Name = "Failure to Bloom",
                    Description = "Insufficient sunlight, poor soil, or nutrient deficiencies can prevent flowering[5].",
                    Symptoms = "No or few flowers, weak growth.",
                    Causes = "Insufficient light, poor soil, nutrient deficiency.",
                    Solutions = "Provide full sun to partial shade, fertilize appropriately, ensure proper soil pH[5].",
                    Severity = "Medium",
                    Category = "Cultural"
                });
            }

            // Example: Check if the genus is "Salix" and species is "integra" (Dappled Willow)
            if (genus == "Salix" && species == "integra")
            {
                // Add the most common problems for Salix integra (Dappled Willow)
                ListProblems.Add(new PlantProblem
                {
                    Id = 426,
                    Name = "Blights",
                    Description = "Fungal blights can cause rapid wilting and dieback of leaves and shoots[1][2][7].",
                    Symptoms = "Wilting, brown or blackened leaves and shoots, rapid dieback.",
                    Causes = "Fungal infection, often in wet or humid conditions.",
                    Solutions = "Remove and destroy affected parts, improve air circulation, avoid overhead watering[1][2][7].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 427,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white powdery patches on leaves and stems[1][2][7].",
                    Symptoms = "White powdery coating on leaves and stems, leaf distortion, reduced vigor.",
                    Causes = "Fungal infection, poor air circulation, damp conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if needed[1][2][7].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 428,
                    Name = "Leaf Spot and Leaf Blotch",
                    Description = "Fungal diseases causing brown or black spots or blotches on leaves, sometimes leading to severe foliage blight[1][5][8].",
                    Symptoms = "Brown or black spots or blotches on leaves, leaf drop, reduced vigor.",
                    Causes = "Fungal infection, wet conditions, poor air circulation.",
                    Solutions = "Remove infected leaves, improve air circulation, avoid overhead watering, apply fungicide if needed[1][5][8].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 429,
                    Name = "Rust",
                    Description = "Fungal disease causing orange or brown pustules on leaf undersides[1][2][7].",
                    Symptoms = "Orange or brown pustules on leaf undersides, leaf yellowing, premature drop.",
                    Causes = "Fungal infection, high humidity.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering, apply fungicide if needed[1][2][7].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 430,
                    Name = "Cankers",
                    Description = "Fungal disease causing sunken, dead areas on bark and stems[1][5].",
                    Symptoms = "Sunken, dark lesions on bark and stems, dieback, plant decline.",
                    Causes = "Fungal infection, often following injury or stress.",
                    Solutions = "Prune out infected branches, sterilize tools, improve plant vigor[1][5].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 431,
                    Name = "Crown Gall",
                    Description = "Bacterial disease causing swollen growths on roots and stems[1].",
                    Symptoms = "Swollen, woody galls on roots and stems, plant decline.",
                    Causes = "Bacterial infection, often via wounds.",
                    Solutions = "Remove and destroy infected plants, avoid wounding, use disease-free stock[1].",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 432,
                    Name = "Root Rot",
                    Description = "Fungal disease causing root decay, yellowing, and wilting[4][7].",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, plant collapse.",
                    Causes = "Overwatering, poor drainage, waterlogged soil.",
                    Solutions = "Improve drainage, avoid overwatering, remove and destroy severely infected plants[4][7].",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 433,
                    Name = "Aphids",
                    Description = "Sap-sucking insects causing distorted growth, sticky residue, and sooty mold[1][2][7].",
                    Symptoms = "Clusters of small insects on stems and leaves, sticky residue, distorted leaves.",
                    Causes = "Infestation by aphids, especially on new growth.",
                    Solutions = "Encourage natural predators, spray with water, use insecticidal soap or neem oil[1][2][7].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 434,
                    Name = "Scale Insects",
                    Description = "Sap-sucking pests causing yellowing, leaf drop, and sticky residue[1][2].",
                    Symptoms = "Brown or white bumps on stems and leaves, sticky residue, yellowing leaves.",
                    Causes = "Infestation by scale insects.",
                    Solutions = "Remove by hand, use horticultural oil or insecticidal soap.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 435,
                    Name = "Borers",
                    Description = "Larvae that tunnel into stems and trunks, causing dieback and plant decline[1][2].",
                    Symptoms = "Entry holes, sawdust-like frass, wilting, dieback.",
                    Causes = "Infestation by borer larvae.",
                    Solutions = "Prune out infested branches, maintain plant vigor, use appropriate insecticides if severe[1][2].",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 436,
                    Name = "Lace Bugs and Beetles",
                    Description = "Sap-sucking or leaf-chewing insects causing stippling, yellowing, or holes in leaves[1][2].",
                    Symptoms = "Stippling, yellowing, or holes in leaves, reduced vigor.",
                    Causes = "Infestation by lace bugs or beetles.",
                    Solutions = "Encourage natural predators, use insecticidal soap or neem oil if needed[1][2].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 437,
                    Name = "Caterpillars",
                    Description = "Larvae that chew on leaves, causing holes and defoliation[1][2][3].",
                    Symptoms = "Chewed leaves, holes, defoliation.",
                    Causes = "Infestation by caterpillars.",
                    Solutions = "Handpick, encourage natural predators, use biological controls if needed[1][2][3].",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 438,
                    Name = "Goat Moth",
                    Description = "Larvae that bore into bark and wood, causing extensive damage[3].",
                    Symptoms = "Entry holes, sawdust-like frass, wilting, dieback.",
                    Causes = "Infestation by goat moth larvae.",
                    Solutions = "Prune and destroy infested branches, maintain plant vigor[3].",
                    Severity = "High",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 439,
                    Name = "Overwatering and Poor Drainage",
                    Description = "Excess moisture leading to root rot, yellowing, and wilting[4][7].",
                    Symptoms = "Yellowing leaves, wilting, foul odor from soil, plant collapse.",
                    Causes = "Overwatering, heavy clay soil, poor drainage.",
                    Solutions = "Improve drainage, avoid overwatering, use well-draining soil[4][7].",
                    Severity = "High",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 440,
                    Name = "Brown Leaf Tips",
                    Description = "Leaf tips turn brown, often due to water stress or improper watering[3].",
                    Symptoms = "Brown leaf tips, leaf drop.",
                    Causes = "Too much or too little water, drought stress.",
                    Solutions = "Check soil moisture, adjust watering, ensure consistent moisture[3].",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 441,
                    Name = "Leggy Growth or Leaf Scorch",
                    Description = "Weak, elongated growth or scorched leaves due to improper light or water[7].",
                    Symptoms = "Leggy stems, scorched leaves, reduced vigor.",
                    Causes = "Insufficient or excessive light, water stress.",
                    Solutions = "Adjust light conditions, provide consistent moisture, prune as needed[7].",
                    Severity = "Low",
                    Category = "Cultural"
                });
            }

            //paarse wicka
            if (genus == "Vicia" && species == "villosa")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 501,
                    Name = "Root Rot",
                    Description = "Fungal disease affecting roots, leading to poor emergence and establishment, especially under cold and wet conditions.",
                    Symptoms = "Poor seedling emergence, yellowing leaves, wilting, stunted growth.",
                    Causes = "Infection by soil-borne fungi in cold, wet, or waterlogged soils.",
                    Solutions = "Ensure well-drained soil, avoid overwatering, use disease-free seed, rotate crops to reduce pathogen buildup.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 502,
                    Name = "Anthracnose",
                    Description = "Fungal disease causing dark lesions on stems and leaves.",
                    Symptoms = "Dark, sunken lesions on stems and leaves, premature leaf drop.",
                    Causes = "Fungal infection, often promoted by wet and humid conditions.",
                    Solutions = "Use resistant varieties if available, practice crop rotation, remove and destroy infected plant material.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 503,
                    Name = "Leaf Spot",
                    Description = "Fungal or bacterial disease resulting in spots on leaves.",
                    Symptoms = "Brown or black spots on leaves, possible yellowing and premature leaf drop.",
                    Causes = "Fungal or bacterial pathogens, often in wet or humid conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove infected leaves, apply fungicide if necessary.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 504,
                    Name = "Rust",
                    Description = "Fungal disease causing orange or brown pustules on leaf undersides.",
                    Symptoms = "Orange or brown pustules on leaves, leaf yellowing, premature drop.",
                    Causes = "Fungal infection, favored by humid conditions.",
                    Solutions = "Remove affected leaves, improve air circulation, use resistant varieties if available.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 505,
                    Name = "Downy Mildew",
                    Description = "Fungal disease causing yellowing and mottling of leaves.",
                    Symptoms = "Yellow spots or mottling on leaves, fuzzy growth on undersides.",
                    Causes = "Fungal spores in humid, cool conditions.",
                    Solutions = "Ensure good air flow, avoid overhead irrigation, remove affected foliage.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 506,
                    Name = "Nematodes",
                    Description = "Soil-dwelling roundworms (such as soybean cyst and root-knot nematodes) that damage roots.",
                    Symptoms = "Stunted growth, yellowing leaves, poor vigor, root galls or cysts.",
                    Causes = "Infestation by nematodes in the soil.",
                    Solutions = "Rotate crops, use resistant varieties if available, solarize soil before planting.",
                    Severity = "Medium",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 507,
                    Name = "Weediness / Self-seeding",
                    Description = "Hairy vetch can become a problematic weed in subsequent crops or open spaces due to its ability to self-seed and persist.",
                    Symptoms = "Unwanted vetch growth in following crops or garden beds.",
                    Causes = "Self-reseeding and persistence of hard seed in the soil.",
                    Solutions = "Mow or incorporate before seed set, monitor and remove volunteers in following seasons.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 508,
                    Name = "Toxicity to Livestock",
                    Description = "Hairy vetch can cause toxicosis in horses and cattle, especially if large amounts are consumed.",
                    Symptoms = "Weight loss, skin irritation, peeling skin, enlarged lymph nodes, swelling of lower limbs (in horses).",
                    Causes = "Consumption of hairy vetch plants or seeds containing anti-nutritional compounds.",
                    Solutions = "Prevent livestock access to vetch, especially horses; remove vetch from pastures and feed.",
                    Severity = "High",
                    Category = "Toxicity"
                });
            }

            if (genus == "Heuchera" && species == "Mulberry")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 601,
                    Name = "Vine Weevil (Taxuskever)",
                    Description = "Larvae of the vine weevil feed on the roots, causing sudden wilting and plant collapse.",
                    Symptoms = "Sudden wilting, stunted growth, roots with notched edges or missing sections.",
                    Causes = "Infestation by vine weevil larvae, especially in pots or containers.",
                    Solutions = "Remove and destroy affected plants, use nematodes (biological control), inspect roots regularly, use insecticide if needed.",
                    Severity = "High",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 602,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing a white, powdery coating on leaves, especially in humid conditions.",
                    Symptoms = "White powdery patches on leaves, leaf distortion, reduced vigor.",
                    Causes = "Fungal infection, often due to poor air circulation and damp weather.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, use fungicide if necessary.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 603,
                    Name = "Rust",
                    Description = "Fungal disease causing orange or brown pustules on the undersides of leaves.",
                    Symptoms = "Orange or brown spots/pustules on leaves, premature leaf drop.",
                    Causes = "Fungal spores, often spread in moist conditions.",
                    Solutions = "Remove and destroy affected leaves, improve air movement, use fungicide if needed.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 604,
                    Name = "Crown Rot / Root Rot",
                    Description = "Rotting at the base or roots due to waterlogged soil or poor drainage.",
                    Symptoms = "Yellowing leaves, wilting, blackened or mushy crown/roots, plant collapse.",
                    Causes = "Overwatering, heavy or poorly drained soil, fungal pathogens.",
                    Solutions = "Plant in well-drained soil, avoid overwatering, remove and destroy affected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 605,
                    Name = "Leaf Scorch or Sunburn",
                    Description = "Leaf edges turn brown and crispy, especially in hot sun or dry winds.",
                    Symptoms = "Brown, crispy leaf edges, leaf drop, faded foliage color.",
                    Causes = "Excessive sun, hot dry winds, insufficient soil moisture.",
                    Solutions = "Provide light shade in hottest part of day, ensure consistent moisture, mulch to retain soil moisture.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 606,
                    Name = "Leggy Growth / Loss of Color",
                    Description = "Plants become stretched with pale leaves due to too much shade or old foliage.",
                    Symptoms = "Leggy stems, pale or dull leaf color, reduced vigor.",
                    Causes = "Too much shade, aging foliage, overcrowding.",
                    Solutions = "Move to a brighter spot, divide clumps every few years, prune old leaves in spring.",
                    Severity = "Low",
                    Category = "Cultural"
                });
            }

            if (genus == "Sedum" && species == "spectabile")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 701,
                    Name = "Root Rot",
                    Description = "Fungal disease causing root decay, often due to overwatering or poorly drained soil.",
                    Symptoms = "Yellowing leaves, wilting, mushy stems at soil level, plant collapse.",
                    Causes = "Excess moisture, poor drainage, heavy soils.",
                    Solutions = "Plant in well-drained soil, avoid overwatering, remove and destroy affected plants.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 702,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white, powdery coating on leaves and stems.",
                    Symptoms = "White powdery patches on leaves and stems, leaf distortion, reduced vigor.",
                    Causes = "Fungal spores, often in humid or crowded conditions.",
                    Solutions = "Improve air circulation, avoid overhead watering, remove affected leaves, apply fungicide if necessary.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 703,
                    Name = "Aphids",
                    Description = "Sap-sucking insects that cluster on new growth, causing distortion and sticky residue.",
                    Symptoms = "Distorted young shoots, sticky honeydew, possible sooty mold.",
                    Causes = "Infestation by aphids, especially in spring and summer.",
                    Solutions = "Spray with water, use insecticidal soap or neem oil, encourage natural predators like ladybugs.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 704,
                    Name = "Slugs and Snails",
                    Description = "Mollusks that chew holes in leaves, particularly in wet weather or shady locations.",
                    Symptoms = "Irregular holes in leaves, slime trails.",
                    Causes = "Presence of slugs and snails, especially in damp conditions.",
                    Solutions = "Hand-pick at dusk, use slug pellets or traps, keep area around plants clear of debris.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 705,
                    Name = "Leggy Growth / Flopping",
                    Description = "Stems become weak and fall over, especially in too much shade or overly rich soil.",
                    Symptoms = "Tall, weak stems that flop over, sparse growth.",
                    Causes = "Too much shade, over-fertilization, overcrowding.",
                    Solutions = "Grow in full sun, avoid excess fertilizer, divide clumps every few years.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 706,
                    Name = "Leaf Spot",
                    Description = "Fungal or bacterial disease causing brown or black spots on leaves.",
                    Symptoms = "Spots on leaves, possible yellowing or premature leaf drop.",
                    Causes = "Fungal or bacterial pathogens, often in wet or humid conditions.",
                    Solutions = "Remove affected leaves, improve air circulation, avoid overhead watering, apply fungicide if needed.",
                    Severity = "Low",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 707,
                    Name = "Overwatering",
                    Description = "Sedum is drought-tolerant and sensitive to excess moisture.",
                    Symptoms = "Yellowing, mushy leaves, root rot.",
                    Causes = "Watering too frequently or planting in heavy, poorly draining soil.",
                    Solutions = "Allow soil to dry between waterings, plant in sandy or well-drained soil.",
                    Severity = "Medium",
                    Category = "Cultural"
                });
            }

            if (genus == "Erica" && species == "carnea")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 801,
                    Name = "Root Rot (Wortelrot)",
                    Description = "Fungal disease causing decay of roots, often due to waterlogged or poorly drained soil.",
                    Symptoms = "Gele bladeren, verwelking, plant sterft af, bruine of zwarte rotte wortels.",
                    Causes = "Overbewatering, slechte drainage, zware kleigrond.",
                    Solutions = "Plant in goed doorlatende, bij voorkeur zure grond. Vermijd overbewatering. Verwijder aangetaste planten.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 802,
                    Name = "Leaf Spot (Bladvlekkenziekte)",
                    Description = "Fungal or bacterial disease causing brown or black spots on leaves.",
                    Symptoms = "Bruine of zwarte vlekken op bladeren, bladval.",
                    Causes = "Schimmels of bacteriën, vaak bij nat weer of slechte luchtcirculatie.",
                    Solutions = "Verwijder aangetaste bladeren, verbeter luchtcirculatie, vermijd natte bladeren, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 803,
                    Name = "Powdery Mildew (Meeldauw)",
                    Description = "Fungal disease causing white, powdery coating on leaves and stems.",
                    Symptoms = "Witte poederachtige aanslag op bladeren en stengels, groeiremming.",
                    Causes = "Schimmelsporen, vaak bij vochtig en warm weer.",
                    Solutions = "Verbeter luchtcirculatie, verwijder aangetaste delen, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 804,
                    Name = "Winter Damage (Vorstschade)",
                    Description = "Damage to foliage and stems due to severe frost or drying winter winds.",
                    Symptoms = "Bruine, verdroogde bladeren, afgestorven toppen.",
                    Causes = "Strenge vorst, uitdrogende wind, onvoldoende bescherming.",
                    Solutions = "Bescherm planten met vliesdoek bij strenge vorst, plant op beschutte plek.",
                    Severity = "Low",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 805,
                    Name = "Yellowing Leaves (Verkleurde bladeren)",
                    Description = "Leaves turn yellow, often due to unsuitable soil pH or nutrient deficiency.",
                    Symptoms = "Gele bladeren, slechte groei.",
                    Causes = "Te kalkrijke grond (niet zuur genoeg), ijzergebrek.",
                    Solutions = "Plant in zure, humusrijke grond. Voeg turf of speciale heidegrond toe. Gebruik ijzermeststof indien nodig.",
                    Severity = "Medium",
                    Category = "Nutrient"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 806,
                    Name = "Leggy Growth (Slappe groei)",
                    Description = "Plants become leggy and sparse due to lack of pruning or too much shade.",
                    Symptoms = "Lange, slappe stengels, weinig bloemen.",
                    Causes = "Te weinig licht, geen jaarlijkse snoei.",
                    Solutions = "Snoei na de bloei om compacte groei te stimuleren. Plant op lichte plek.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 807,
                    Name = "Aphids (Bladluizen)",
                    Description = "Small sap-sucking insects that can cause distorted growth and sticky residue.",
                    Symptoms = "Kleine insecten op jonge scheuten, plakkerige honingdauw, misvormde bladeren.",
                    Causes = "Bladluizen, vooral in het voorjaar.",
                    Solutions = "Spoel af met water, gebruik natuurlijke vijanden (lieveheersbeestjes), eventueel insecticide.",
                    Severity = "Low",
                    Category = "Pest"
                });
            }

            if (genus == "Carex" && species == "morrowii")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 901,
                    Name = "Root Rot (Wortelrot)",
                    Description = "Fungal disease causing root decay, especially in poorly drained or waterlogged soil.",
                    Symptoms = "Gele bladeren, verwelking, plant sterft af, bruine of rotte wortels.",
                    Causes = "Overbewatering, slechte drainage, zware grond.",
                    Solutions = "Plant in goed doorlatende grond, vermijd overbewatering, verwijder aangetaste planten.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 902,
                    Name = "Rust (Roest)",
                    Description = "Fungal disease causing orange or brown pustules on leaves.",
                    Symptoms = "Oranje of bruine vlekken/pustules op bladeren, bladval.",
                    Causes = "Schimmelsporen, vooral bij vochtig weer.",
                    Solutions = "Verwijder aangetaste bladeren, verbeter luchtcirculatie, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 903,
                    Name = "Leaf Spot (Bladvlekkenziekte)",
                    Description = "Fungal or bacterial disease causing brown or black spots on leaves.",
                    Symptoms = "Bruine of zwarte vlekken op bladeren, mogelijk bladval.",
                    Causes = "Schimmels of bacteriën, vaak bij nat weer of slechte luchtcirculatie.",
                    Solutions = "Verwijder aangetaste bladeren, verbeter luchtcirculatie, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 904,
                    Name = "Slugs and Snails (Slakken en naaktslakken)",
                    Description = "Slugs and snails feed on young leaves, causing holes and ragged edges.",
                    Symptoms = "Gaten in bladeren, rafelige bladranden, slijmsporen.",
                    Causes = "Aanwezigheid van slakken, vooral bij vochtig weer.",
                    Solutions = "Verwijder slakken handmatig, gebruik slakkenkorrels of biologische bestrijding.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 905,
                    Name = "Leaf Tip Browning (Bruine bladpunten)",
                    Description = "Leaf tips turn brown due to drought, salt buildup, or inconsistent watering.",
                    Symptoms = "Bruine bladpunten, soms uitdroging van hele bladeren.",
                    Causes = "Te droge grond, te veel mest of zout, onregelmatig water geven.",
                    Solutions = "Zorg voor gelijkmatige vochtigheid, spoel overtollige mest/zout uit de grond, vermijd uitdroging.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 906,
                    Name = "Leggy Growth (Slappe groei)",
                    Description = "Plants become leggy and sparse due to too much shade or overcrowding.",
                    Symptoms = "Lange, slappe stengels, weinig blad.",
                    Causes = "Te veel schaduw, te dicht op elkaar geplante pollen.",
                    Solutions = "Verdeel pollen om de paar jaar, plant op een lichtere plek.",
                    Severity = "Low",
                    Category = "Cultural"
                });
            }

            if (genus == "Campanula" && species == "poscharskyana")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 1001,
                    Name = "Root Rot (Wortelrot)",
                    Description = "Fungal disease causing root decay, especially in poorly drained or waterlogged soil.",
                    Symptoms = "Gele bladeren, verwelking, plant sterft af, bruine of rotte wortels.",
                    Causes = "Overbewatering, slechte drainage, zware grond.",
                    Solutions = "Plant in goed doorlatende grond, vermijd overbewatering, verwijder aangetaste planten.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1002,
                    Name = "Powdery Mildew (Meeldauw)",
                    Description = "Fungal disease causing a white, powdery coating on leaves and stems, especially in humid conditions.",
                    Symptoms = "Witte poederachtige aanslag op bladeren en stengels, groeiremming.",
                    Causes = "Schimmelsporen, vaak bij vochtig en warm weer.",
                    Solutions = "Verbeter luchtcirculatie, verwijder aangetaste delen, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1003,
                    Name = "Leaf Spot (Bladvlekkenziekte)",
                    Description = "Fungal or bacterial disease causing brown or black spots on leaves.",
                    Symptoms = "Bruine of zwarte vlekken op bladeren, mogelijk bladval.",
                    Causes = "Schimmels of bacteriën, vaak bij nat weer of slechte luchtcirculatie.",
                    Solutions = "Verwijder aangetaste bladeren, verbeter luchtcirculatie, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1004,
                    Name = "Slugs and Snails (Slakken en naaktslakken)",
                    Description = "Slugs and snails feed on young leaves and shoots, causing holes and ragged edges.",
                    Symptoms = "Gaten in bladeren, rafelige bladranden, slijmsporen.",
                    Causes = "Aanwezigheid van slakken, vooral bij vochtig weer.",
                    Solutions = "Verwijder slakken handmatig, gebruik slakkenkorrels of biologische bestrijding.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1005,
                    Name = "Aphids (Bladluizen)",
                    Description = "Small sap-sucking insects that can cause distorted growth and sticky residue.",
                    Symptoms = "Kleine insecten op jonge scheuten, plakkerige honingdauw, misvormde bladeren.",
                    Causes = "Bladluizen, vooral in het voorjaar.",
                    Solutions = "Spoel af met water, gebruik natuurlijke vijanden (lieveheersbeestjes), eventueel insecticide.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1006,
                    Name = "Leggy Growth (Slappe groei)",
                    Description = "Plants become leggy and sparse due to too much shade or overcrowding.",
                    Symptoms = "Lange, slappe stengels, weinig bloemen.",
                    Causes = "Te veel schaduw, te dicht op elkaar geplante pollen.",
                    Solutions = "Verdeel pollen om de paar jaar, plant op een lichtere plek.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1007,
                    Name = "Winter Damage (Vorstschade)",
                    Description = "Damage to foliage and stems due to severe frost or drying winter winds.",
                    Symptoms = "Bruine, verdroogde bladeren, afgestorven toppen.",
                    Causes = "Strenge vorst, uitdrogende wind, onvoldoende bescherming.",
                    Solutions = "Bescherm planten met vliesdoek bij strenge vorst, plant op beschutte plek.",
                    Severity = "Low",
                    Category = "Environmental"
                });
            }

            if (genus == "Campanula" && species == "garganica")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 1101,
                    Name = "Root Rot (Wortelrot)",
                    Description = "Fungal disease causing root decay, especially in poorly drained or waterlogged soil.",
                    Symptoms = "Gele bladeren, verwelking, plant sterft af, bruine of rotte wortels.",
                    Causes = "Overbewatering, slechte drainage, zware grond.",
                    Solutions = "Plant in goed doorlatende grond, vermijd overbewatering, verwijder aangetaste planten.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1102,
                    Name = "Powdery Mildew (Meeldauw)",
                    Description = "Fungal disease causing a white, powdery coating on leaves and stems, especially in humid conditions.",
                    Symptoms = "Witte poederachtige aanslag op bladeren en stengels, groeiremming.",
                    Causes = "Schimmelsporen, vaak bij vochtig en warm weer.",
                    Solutions = "Verbeter luchtcirculatie, verwijder aangetaste delen, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1103,
                    Name = "Leaf Spot (Bladvlekkenziekte)",
                    Description = "Fungal or bacterial disease causing brown or black spots on leaves.",
                    Symptoms = "Bruine of zwarte vlekken op bladeren, mogelijk bladval.",
                    Causes = "Schimmels of bacteriën, vaak bij nat weer of slechte luchtcirculatie.",
                    Solutions = "Verwijder aangetaste bladeren, verbeter luchtcirculatie, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1104,
                    Name = "Slugs and Snails (Slakken en naaktslakken)",
                    Description = "Slugs and snails feed on young leaves and shoots, causing holes and ragged edges.",
                    Symptoms = "Gaten in bladeren, rafelige bladranden, slijmsporen.",
                    Causes = "Aanwezigheid van slakken, vooral bij vochtig weer.",
                    Solutions = "Verwijder slakken handmatig, gebruik slakkenkorrels of biologische bestrijding.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1105,
                    Name = "Aphids (Bladluizen)",
                    Description = "Small sap-sucking insects that can cause distorted growth and sticky residue.",
                    Symptoms = "Kleine insecten op jonge scheuten, plakkerige honingdauw, misvormde bladeren.",
                    Causes = "Bladluizen, vooral in het voorjaar.",
                    Solutions = "Spoel af met water, gebruik natuurlijke vijanden (lieveheersbeestjes), eventueel insecticide.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1106,
                    Name = "Leggy Growth (Slappe groei)",
                    Description = "Plants become leggy and sparse due to too much shade or overcrowding.",
                    Symptoms = "Lange, slappe stengels, weinig bloemen.",
                    Causes = "Te veel schaduw, te dicht op elkaar geplante pollen.",
                    Solutions = "Verdeel pollen om de paar jaar, plant op een lichtere plek.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1107,
                    Name = "Winter Damage (Vorstschade)",
                    Description = "Damage to foliage and stems due to severe frost or drying winter winds.",
                    Symptoms = "Bruine, verdroogde bladeren, afgestorven toppen.",
                    Causes = "Strenge vorst, uitdrogende wind, onvoldoende bescherming.",
                    Solutions = "Bescherm planten met vliesdoek bij strenge vorst, plant op beschutte plek.",
                    Severity = "Low",
                    Category = "Environmental"
                });
            }

            if (genus == "Fargesia" && species == "rufa")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 1201,
                    Name = "Leaf Curling and Browning",
                    Description = "Leaves curl or develop brown edges/tips, often due to drought, wind, or strong sun.",
                    Symptoms = "Opgerolde bladeren, bruine bladpunten of bladranden, soms bladval.",
                    Causes = "Te droge grond, felle zon, uitdrogende wind, of te weinig water.",
                    Solutions = "Zorg voor voldoende water, geef extra water bij droogte, plant op een beschutte plek of geef schaduw tijdens hete periodes.",
                    Severity = "Medium",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1202,
                    Name = "Yellowing Leaves (Chlorosis)",
                    Description = "Leaves turn yellow, often due to nutrient deficiency, compacted soil, or poor drainage.",
                    Symptoms = "Gele bladeren, soms slechte groei.",
                    Causes = "Voedingsgebrek (vooral stikstof), slechte drainage, te natte of te compacte grond.",
                    Solutions = "Verbeter de bodemstructuur, geef organische mest in het voorjaar, zorg voor goede drainage.",
                    Severity = "Low",
                    Category = "Nutrient"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1203,
                    Name = "Root Rot (Wortelrot)",
                    Description = "Fungal disease causing root decay, especially in poorly drained or waterlogged soil.",
                    Symptoms = "Gele bladeren, verwelking, plant sterft af, bruine of rotte wortels.",
                    Causes = "Overbewatering, slechte drainage.",
                    Solutions = "Plant in goed doorlatende grond, vermijd overbewatering, verwijder aangetaste planten.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1204,
                    Name = "Winter Damage (Vorstschade)",
                    Description = "Damage to foliage and stems due to severe frost or drying winter winds.",
                    Symptoms = "Bruine, verdroogde bladeren, afgestorven toppen na strenge vorst.",
                    Causes = "Strenge vorst, uitdrogende wind, onvoldoende bescherming.",
                    Solutions = "Bescherm planten met vliesdoek bij strenge vorst, plant op beschutte plek.",
                    Severity = "Low",
                    Category = "Environmental"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1205,
                    Name = "Spider Mites (Spint)",
                    Description = "Tiny pests that cause stippling and yellowing of leaves, especially in hot, dry conditions.",
                    Symptoms = "Gele stipjes op bladeren, fijne spinnenwebben, bladval.",
                    Causes = "Spintmijt, vooral bij droge lucht en warmte.",
                    Solutions = "Verhoog luchtvochtigheid, spoel bladeren af met water, gebruik biologische of chemische bestrijding indien nodig.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1206,
                    Name = "Pale or Sparse Growth",
                    Description = "Weak, pale, or sparse growth due to insufficient nutrients or light.",
                    Symptoms = "Bleek, dun blad, trage groei.",
                    Causes = "Te weinig voeding, te veel schaduw.",
                    Solutions = "Geef organische mest in het voorjaar, plant op een lichtere plek indien mogelijk.",
                    Severity = "Low",
                    Category = "Cultural"
                });
            }

            if (genus == "Digitalis" && species == "purpurea")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 1301,
                    Name = "Crown Rot / Root Rot",
                    Description = "Fungal disease causing decay at the base or roots, often due to waterlogged or poorly drained soil.",
                    Symptoms = "Gele bladeren, verwelking, zwarte of slijmerige wortels, plant sterft af.",
                    Causes = "Overbewatering, slechte drainage, zware grond.",
                    Solutions = "Plant in goed doorlatende grond, vermijd overbewatering, verwijder aangetaste planten.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1302,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing a white, powdery coating on leaves and stems, especially in humid conditions.",
                    Symptoms = "Witte poederachtige aanslag op bladeren en stengels, groeiremming.",
                    Causes = "Schimmelsporen, vaak bij vochtig en warm weer.",
                    Solutions = "Verbeter luchtcirculatie, verwijder aangetaste delen, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1303,
                    Name = "Leaf Spot",
                    Description = "Fungal or bacterial disease causing brown or black spots on leaves.",
                    Symptoms = "Bruine of zwarte vlekken op bladeren, bladval.",
                    Causes = "Schimmels of bacteriën, vaak bij nat weer of slechte luchtcirculatie.",
                    Solutions = "Verwijder aangetaste bladeren, verbeter luchtcirculatie, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1304,
                    Name = "Aphids (Bladluizen)",
                    Description = "Small sap-sucking insects that can cause distorted growth and sticky residue.",
                    Symptoms = "Kleine insecten op jonge scheuten, plakkerige honingdauw, misvormde bladeren.",
                    Causes = "Bladluizen, vooral in het voorjaar.",
                    Solutions = "Spoel af met water, gebruik natuurlijke vijanden (lieveheersbeestjes), eventueel insecticide.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1305,
                    Name = "Slugs and Snails (Slakken en naaktslakken)",
                    Description = "Slugs and snails feed on young leaves and shoots, causing holes and ragged edges.",
                    Symptoms = "Gaten in bladeren, rafelige bladranden, slijmsporen.",
                    Causes = "Aanwezigheid van slakken, vooral bij vochtig weer.",
                    Solutions = "Verwijder slakken handmatig, gebruik slakkenkorrels of biologische bestrijding.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1306,
                    Name = "Leggy Growth / Flopping",
                    Description = "Stems become weak and fall over, especially in too much shade or overly rich soil.",
                    Symptoms = "Lange, slappe stengels, weinig bloemen, planten vallen om.",
                    Causes = "Te veel schaduw, overbemesting, te rijke grond.",
                    Solutions = "Plant op een lichtere plek, vermijd overbemesting, geef steun indien nodig.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1307,
                    Name = "Toxicity to Humans and Animals",
                    Description = "All parts of Digitalis purpurea are highly poisonous if ingested.",
                    Symptoms = "Misselijkheid, braken, hartritmestoornissen, soms dodelijk bij inname.",
                    Causes = "Inname van bladeren, bloemen of zaden door kinderen, huisdieren of vee.",
                    Solutions = "Waarschuw voor giftigheid, plant buiten bereik van kinderen en dieren.",
                    Severity = "High",
                    Category = "Toxicity"
                });
            }

            if (genus == "Elaeagnus" && species == "ebbingei")
            {
                ListProblems.Add(new PlantProblem
                {
                    Id = 1401,
                    Name = "Leaf Spot",
                    Description = "Fungal or bacterial disease causing brown or black spots on leaves, sometimes leading to leaf drop.",
                    Symptoms = "Bruine of zwarte vlekken op bladeren, soms bladval.",
                    Causes = "Schimmels of bacteriën, vaak bij nat weer of slechte luchtcirculatie.",
                    Solutions = "Verwijder aangetaste bladeren, verbeter luchtcirculatie, vermijd natte bladeren, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1402,
                    Name = "Powdery Mildew",
                    Description = "Fungal disease causing white, powdery coating on leaves and shoots.",
                    Symptoms = "Witte poederachtige aanslag op bladeren en jonge scheuten.",
                    Causes = "Schimmelsporen, vaak bij vochtig weer en slechte luchtcirculatie.",
                    Solutions = "Verbeter luchtcirculatie, verwijder aangetaste delen, gebruik eventueel fungicide.",
                    Severity = "Medium",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1403,
                    Name = "Root Rot",
                    Description = "Fungal disease causing root decay, especially in poorly drained or waterlogged soil.",
                    Symptoms = "Gele bladeren, verwelking, plant sterft af, bruine of rotte wortels.",
                    Causes = "Overbewatering, slechte drainage, zware grond.",
                    Solutions = "Plant in goed doorlatende grond, vermijd overbewatering, verwijder aangetaste planten.",
                    Severity = "High",
                    Category = "Disease"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1404,
                    Name = "Aphids (Bladluizen)",
                    Description = "Small sap-sucking insects that can cause distorted growth and sticky residue.",
                    Symptoms = "Kleine insecten op jonge scheuten, plakkerige honingdauw, misvormde bladeren.",
                    Causes = "Bladluizen, vooral in het voorjaar.",
                    Solutions = "Spoel af met water, gebruik natuurlijke vijanden (lieveheersbeestjes), eventueel insecticide.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1405,
                    Name = "Scale Insects (Schildluizen)",
                    Description = "Sap-sucking pests causing yellowing, leaf drop, and sticky residue.",
                    Symptoms = "Bruine of witte bultjes op stengels en bladeren, plakkerige honingdauw, gele bladeren.",
                    Causes = "Infestatie door schildluizen.",
                    Solutions = "Verwijder met de hand, gebruik horticulturele olie of insecticide.",
                    Severity = "Low",
                    Category = "Pest"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1406,
                    Name = "Brown Leaf Tips",
                    Description = "Leaf tips turn brown, often due to water stress or improper watering.",
                    Symptoms = "Bruine bladpunten, bladval.",
                    Causes = "Te veel of te weinig water, droogtestress.",
                    Solutions = "Controleer bodemvocht, pas watergift aan, zorg voor gelijkmatige vochtigheid.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1407,
                    Name = "Leggy Growth or Leaf Scorch",
                    Description = "Weak, elongated growth or scorched leaves due to improper light or water.",
                    Symptoms = "Slappe, lange stengels, verbrande bladeren, verminderde groei.",
                    Causes = "Onvoldoende of te veel licht, waterstress.",
                    Solutions = "Pas lichtomstandigheden aan, geef gelijkmatig water, snoei indien nodig.",
                    Severity = "Low",
                    Category = "Cultural"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1408,
                    Name = "Chlorosis (Leaf Yellowing)",
                    Description = "Yellowing leaves, often due to nutrient deficiency or unsuitable soil pH.",
                    Symptoms = "Gele bladeren, soms slechte groei.",
                    Causes = "Voedingsgebrek (vooral ijzer), te kalkrijke grond.",
                    Solutions = "Voeg meststof toe, verbeter bodemstructuur, gebruik turf of heidegrond indien nodig.",
                    Severity = "Medium",
                    Category = "Nutrient"
                });

                ListProblems.Add(new PlantProblem
                {
                    Id = 1409,
                    Name = "Wind Damage",
                    Description = "Leaves become torn, brown, or dry due to strong wind exposure.",
                    Symptoms = "Beschadigde, bruine of droge bladeren, vooral aan de windzijde.",
                    Causes = "Sterke wind, vooral in open of kustgebieden.",
                    Solutions = "Plant op een beschutte plek of gebruik windschermen.",
                    Severity = "Low",
                    Category = "Environmental"
                });
            }


            //return list
            return ListProblems;

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
