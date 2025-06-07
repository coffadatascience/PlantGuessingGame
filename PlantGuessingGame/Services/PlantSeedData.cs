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
                    ImagePath = diskLocationImages + "Appelboom_Malus_domestica_Base01.jpeg",
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

                // Lonicera nitida 'Maigrün'
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
                    // New plant care properties:
                    Light = "Full sun to partial shade; best flowering with at least 6 hours of sunlight daily and shelter from strong winds.",
                    Water = "Water deeply every 7–10 days during dry spells, especially in the first year. Keep soil moist but never soggy. Once established, water only during prolonged drought.",
                    Soil = "Fertile, humus-rich, moist but well-drained soil with a slightly acidic to neutral pH (6.0–7.0). Avoid planting in heavy, waterlogged, or compacted soils.",
                    FertilizationMethod = "Apply a balanced fertilizer in early spring and again after flowering if needed. Avoid over-fertilizing; mature peonies generally need little feeding.",
                    TrimmingInstructions = "Cut back stems after flowering to ground level in late autumn. Remove dead foliage in early spring.",
                    TrimmingPeriod = "Late autumn and early spring",
                    TemperatureRangeMinimum = -30,
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
