// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    $(".tech-desc").hide();
    $(".tech").mouseover(function () {
        $(this).children(".tech-desc").show();
    });
    $(".tech").mouseout(function () {
        $(this).children(".tech-desc").hide();
    });


    // elastic grid
    $("#tech-grid").elastic_grid({
        'showAllText': 'All',
        'filterEffect': 'popup', // moveup, scaleup, fallperspective, fly, flip, helix , popup
        'hoverDirection': true,
        'hoverDelay': 0,
        'hoverInverse': false,
        'expandingSpeed': 500,
        'expandingHeight': 500,
        'items':
            [
                {
                    'title': 'IBM',
                    'description': 'International Business Machines Corporation(IBM) is an American multinational technology company headquartered in Armonk, New York, United States, with operations in over 170 countries.',
                    'thumbnail': ['/images/oibm.jpg'],
                    'large': ['/images/oibm.jpg'],
                    'img_title': ['IBM'],
                    'button_list':
                        [
                            { 'title': 'AI', 'url': 'https://www.ibm.com/watson/', 'new_window': true },
                            { 'title': 'IoT', 'url': 'https://www.ibm.com/blogs/internet-of-things/industry-4-0/', 'new_window': true },
                            { 'title': 'Cognitive Services', 'url': 'https://www.ibm.com/services/artificial-intelligence', 'new_window': true },
                            { 'title': 'Cloud Computing', 'url': 'https://www.ibm.com/cloud/', 'new_window': true }
                        ],
                    'tags': ['AI', "IoT", "Cognitive Services", "Cloud Computing"]
                },
                {
                    'title': 'Microsoft',
                    'description': 'Microsoft Corporation is an American multinational technology company with headquarters in Redmond, Washington. It develops, manufactures, licenses, supports and sells computer software, consumer electronics, personal computers, and related services.',
                    'thumbnail': ['/images/omicrosoft.jpg'],
                    'large': ['/images/omicrosoft.jpg'],
                    'img_title': ['microsoft'],
                    'button_list':
                        [
                            { 'title': 'AI', 'url': 'https://www.microsoft.com/en-us/ai/default.aspx', 'new_window': true },
                            { 'title': 'IoT', 'url': 'https://www.microsoft.com/en-au/internet-of-things/', 'new_window': true },
                            { 'title': 'Cognitive Services', 'url': 'https://azure.microsoft.com/en-au/services/cognitive-services/', 'new_window': true },
                            { 'title': 'Cloud Computing', 'url': 'https://azure.microsoft.com/en-au/', 'new_window': true }
                        ],
                    'tags': ['AI', "IoT", "Cognitive Services", "Cloud Computing"]
                },
                {
                    'title': 'CSIRO',
                    'description': 'The Commonwealth Scientific and Industrial Research Organisation (CSIRO) is an independent Australian federal government agency responsible for scientific research. Its chief role is to improve the economic and social performance of industry for the benefit of the community.',
                    'thumbnail': ['/images/ocsiro.jpg'],
                    'large': ['/images/ocsiro.jpg'],
                    'img_title': ['CSIRO'],
                    'button_list':
                        [
                            { 'title': 'AI', 'url': 'https://data61.csiro.au/en/Our-Work/AI-and-Machine-Learning', 'new_window': true },
                            { 'title': 'Blockchains', 'url': 'https://www.data61.csiro.au/en/our-work/safety-and-security/secure-systems-and-platforms/blockchain', 'new_window': true }
                        ],
                    'tags': ['AI', 'Blockchains']
                },
                {
                    'title': 'Amazon',
                    'description': 'Amazon.com is an American electronic commerce and cloud computing company based in Seattle, Washington, that was founded by Jeff Bezos on July 5, 1994. The tech giant is the largest Internet retailer in the world as measured by revenue and market capitalization, and second largest after Alibaba Group in terms of total sales. </p>',
                    'thumbnail': ['/images/oamazon.jpg'],
                    'large': ['/images/oamazon.jpg'],
                    'img_title': ['Amazon'],
                    'button_list':
                        [
                            { 'title': 'AI', 'url': 'https://aws.amazon.com/machine-learning/ai-lex-polly-rekognition/', 'new_window': true },
                            { 'title': 'IoT', 'url': 'https://aws.amazon.com/iot/?sc_channel=PS&sc_campaign=acquisition_AU&sc_publisher=google&sc_medium=iot_nb&sc_content=iot_e&sc_detail=iot&sc_category=iot&sc_segment=154387165862&sc_matchtype=e&sc_country=AU&s_kwcid=AL!4422!3!154387165862!e!!g!!iot&ef_id=WmksLwAAAHVHXlHa:20180805102347:s', 'new_window': true },
                            { 'title': 'Cloud Computing', 'url': 'https://aws.amazon.com/', 'new_window': true }
                        ],
                    'tags': ['AI', "IoT", "Cloud Computing"]
                },
                {
                    'title': 'CIO',
                    'description': 'CIO magazine (also known as CIO.com) was founded in 1987. The magazine title refers to the job title Chief information officer. Readership includes other computer-related executives and technology decision makers.',
                    'thumbnail': ['/images/cio.png'],
                    'large': ['/images/cio.png'],
                    'img_title': ['CIO'],
                    'button_list':
                        [
                            { 'title': 'IoT', 'url': 'https://www.cio.com.au/article/641518/feds-launch-ai-iot-projects/', 'new_window': true }
                        ],
                    'tags': ["IoT"]
                },
                {
                    'title': 'Google',
                    'description': 'Google LLC is an American multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, search engine, cloud computing, software, and hardware.',
                    'thumbnail': ['/images/ogoogle.jpg'],
                    'large': ['/images/ogoogle.jpg'],
                    'img_title': ['Google'],
                    'button_list':
                        [
                            { 'title': 'Cloud Computing', 'url': 'https://cloud.google.com/vision/', 'new_window': true },
                            { 'title': 'Cognitive Services', 'url': 'https://cloud.google.com/solutions/iot/', 'new_window': true }
                        ],
                    'tags': ["Cloud Computing", "Cognitive Services"]
                },
                {
                    'title': 'Forbes',
                    'description': 'Forbes (/fɔːrbz/) is an American family-controlled business magazine. Published bi-weekly, it features original articles on finance, industry, investing, and marketing topics. Forbes also reports on related subjects such as technology, communications, science, politics, and law. ',
                    'thumbnail': ['/images/forbes.jpg'],
                    'large': ['/images/forbes.jpg'],
                    'img_title': ['Forbes'],
                    'button_list':
                        [
                            { 'title': 'Robotics', 'url': 'https://www.forbes.com/sites/jimlawton/2018/03/20/the-role-of-robots-in-industry-4-0/#69de1dca706b', 'new_window': true },
                            { 'title': 'Blockchains', 'url': 'https://www.forbes.com/sites/andrewrossow/2018/04/11/bringing-blockchain-into-industry-4-0/', 'new_window': true },
                            { 'title': 'Cognitive Services', 'url': 'https://www.forbes.com/sites/bernardmarr/2016/03/23/what-everyone-should-know-about-cognitive-computing/#62c3c5885088', 'new_window': true }
                        ],
                    'tags': ["Robotics", 'Blockchains', "Cognitive Services"]
                },
                {
                    'title': 'ZDNet',
                    'description': 'ZDNet is a business technology news website published by CBS Interactive, along with TechRepublic. The brand was founded on April 1, 1991, as a general interest technology portal from Ziff Davis and evolved into an enterprise IT-focused online publication owned by CNET Networks.',
                    'thumbnail': ['/images/zdnet.png'],
                    'large': ['/images/zdnet.png'],
                    'img_title': ['ZDNet'],
                    'button_list':
                        [
                            { 'title': 'Robotics', 'url': 'https://www.zdnet.com/article/robotics-and-industry-4-0/', 'new_window': true }

                        ],
                    'tags': ['Robotics']
                },
                {
                    'title': 'I-Scoop robots cobots',
                    'description': 'i-SCOOP provides publications, educational resources, training and hands-on consulting regarding integrated marketing, digi',
                    'thumbnail': ['/images/iscoop.jpg'],
                    'large': ['/images/iscoop.jpg'],
                    'img_title': ['I-Scoop robots cobots'],
                    'button_list':
                        [
                            { 'title': 'Robotics', 'url': 'https://www.i-scoop.eu/robots-cobots-logistics-4-0/', 'new_window': true }
                        ],
                    'tags': ["Robotics"]
                },
                {
                    'title': 'Automation World',
                    'description': 'Launched in 2003 by Summit Media Group, Inc., Automation World is a monthly publication which covers the latest developments in the automation field. Each issue contains articles in the following departments: Operations & Engineering Skills, Managers & Executives Skills, IT & Networking Skills. ',
                    'thumbnail': ['/images/automationworld.png'],
                    'large': ['/images/automationworld.png'],
                    'img_title': ['Automation World'],
                    'button_list':
                        [
                            { 'title': 'Robotics', 'url': 'https://www.automationworld.com/industry-40-here-are-you-ready', 'new_window': true }
                        ],
                    'tags': ["Robotics"]
                },
                {
                    'title': 'Blockchain',
                    'description': 'A blockchain, originally block chain, is a growing list of records, called blocks, which are linked using cryptography. Each block contains a cryptographic hash of the previous block, a timestamp, and transaction data (generally represented as a merkle tree root hash).',
                    'thumbnail': ['/images/bc.jpg'],
                    'large': ['/images/bc.jpg'],
                    'img_title': ['Blockchain'],
                    'button_list':
                        [
                            { 'title': 'Blockchains', 'url': 'https://www.blockchain.com/', 'new_window': true }

                        ],
                    'tags': ['Blockchains']
                },
                {
                    'title': 'PC Magazine',
                    'description': 'PC Magazine (shortened as PCMag) is an American computer magazine published by Ziff Davis. A print edition was published from 1982 to January 2009. Publication of online editions started in late 1994 and continues to this day.',
                    'thumbnail': ['/images/pcmag.png'],
                    'large': ['/images/pcmag.png'],
                    'img_title': ['PC Magazine'],
                    'button_list':
                        [
                            { 'title': 'Blockchains', 'url': 'https://au.pcmag.com/amazon-web-services/46389/feature/blockchain-the-invisible-technology-thats-changing-the-world', 'new_window': true }

                        ],
                    'tags': ['Blockchains']
                }
            ]
    });

    // map



});

var locations = [
    { lat: 33.995, lng: - 118.511 }// google,
    , { lat: 41.114, lng: -73.786 }   // ibm
    , { lat: 47.642, lng: -122.138 } // microsoft
    , { lat: -17.666, lng: 126.152 } // dep
    , { lat: -37.906, lng: 145.096 } // csio
    , { lat: 47.61548, lng: -122.341 } // amazon
];

var infos = [
    {
        "name": "google",
        "pic": "/images/ogoogle.jpg",
        "desc": " Google LLC is an American multinational technology company that specializes in Internet-related services and products, which include online advertising technologies, search engine, cloud computing, software, and hardware.",
        "link": "https://www.google.com"
    },
    {
        "name": "ibm",
        "pic": "/images/ibm.jpeg",
        "desc": "International Business Machines Corporation (IBM) is an American multinational technology company headquartered in Armonk, New York, United States, with operations in over 170 countries.",
        "link": "https://www.ibm.com/us-en/?lnk=fcc"
    },
    {
        "name": "microsoft",
        "pic": "/images/omicrosoft.jpg",
        "desc": "Microsoft Corporation is an American multinational technology company with headquarters in Redmond, Washington. It develops, manufactures, licenses, supports and sells computer software, consumer electronics, personal computers, and related services.",
        "link": "https://www.microsoft.com/"
    },
    {
        "name": "The Department of Industry, Innovation and Science",
        "pic": "/images/odep.jpg",
        "desc": "The Department of Industry, Innovation and Science is a department of the Australian Government responsible for consolidating the Government’s efforts to drive economic growth, productivity and competitiveness by bringing together industry, energy, resources and science.",
        "link": "https://www.industry.gov.au/"
    },
    {
        "name": "csiro",
        "pic": "/images/ocsiro.jpg",
        "desc": "The Commonwealth Scientific and Industrial Research Organisation (CSIRO) is an independent Australian federal government agency responsible for scientific research. Its chief role is to improve the economic and social performance of industry for the benefit of the community.",
        "link": "https://www.csiro.au/"
    },
    {
        "name": "amazon",
        "pic": "/images/oamazon.jpg",
        "desc": "Amazon.com is an American electronic commerce and cloud computing company based in Seattle, Washington, that was founded by Jeff Bezos on July 5, 1994. The tech giant is the largest Internet retailer in the world as measured by revenue and market capitalization, and second largest after Alibaba Group in terms of total sales. ",
        "link": "https://www.amazon.com/"
    }
];

var finalInfos = [];

var infowindow = [];

function getInfos() {
    finalInfos = [];
    var infoTemplate = '<div><h3>#name#</h3><div><img src="#pic#"><p>#desc#</p></div></div>';
    for (let i = 0; i < infos.length; i++) {
        finalInfos.push("<div style='width:400px;'><h5>" + infos[i].name + '</h5><div class="map-info-detail" style="display:flex;"><img class="map-info-img" width="100" height="100" src="' + infos[i].pic + '"><div class="map-info-text" style="padding:0;height:100px;">' + '<div style="margin:0;padding:0 5px 5px 5px;box-sizing:border-box;width:300px;height:85px;overflow:hidden;text-overflow:ellipsis;">' + infos[i].desc + '</div>' + '<a style="padding-left:5px;" href="' + infos[i].link + '">home page</a>' + "</div></div></div>");
    }
    return finalInfos;
}
function initmap() {
    getInfos();
    var initCenter = { lat: -25.344, lng: 131.036 };
    var map = new google.maps.Map(document.getElementById('map'), { zoom: 4, center: initCenter });
    var labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    var markers = [];

    for (let i = 0; i < locations.length; i++) {
        let tempMarker = new google.maps.Marker({ position: locations[i], map: map, label: labels[i % labels.length] });

        markers.push(tempMarker);

        attachSecretMessage(tempMarker, i, finalInfos[i]);
    }
    var markerCluster = new MarkerClusterer(map, markers,
        { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });

    setVeiwPort(markers, map);
}

function attachSecretMessage(marker, number, formatted_address) {
    infowindow.push(
        new google.maps.InfoWindow({
            content: formatted_address,
            //size: new google.maps.Size(50, 50)
        })
    );
    google.maps.event.addListener(marker, 'click', function () {
        for (var j = 0; j < infowindow.length; j++) {
            infowindow[j].close();
        }
        infowindow[number].open(map, this);
    });
}

function setVeiwPort(markers, gmap) {
    var bounds = new google.maps.LatLngBounds();

    for (var i = 0; i < markers.length; i++) {
        bounds.extend(markers[i].getPosition());
    }
    gmap.fitBounds(bounds);
}
