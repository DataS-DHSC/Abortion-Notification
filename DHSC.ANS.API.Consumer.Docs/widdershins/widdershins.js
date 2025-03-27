const widdershins = require('widdershins');
const fs = require('fs');
const path = require('path');

// Ensure we have the correct number of arguments
if (process.argv.length < 4) {
    console.error('Usage: node widdershins.js <input-json-path> <output-markdown-path>');
    process.exit(1);
}

// Read input and output paths from command line arguments
const inputPath = process.argv[2];
const outputPath = process.argv[3];

let options = {
    user_templates: "C:/_src/DHSC/Abortion-Notification/DHSC.ANS.API.Consumer.Docs/widdershins/templates",
    templateCallback: templateCallBack,
    language_tabs: [{ 'javascript': 'JavaScript' }, { 'python': 'Python' }],
    language_tabs: [
        { "shell": "Shell" },
        { "javascript": "JavaScript" },
        { "python": "Python" },
        { "ruby": "Ruby" },
        { "go": "Go" }
    ],
    "sample": true,
    "omitHeader": true,
    codeSamples: true
};

const apiDefinition = JSON.parse(fs.readFileSync(path.resolve(inputPath), 'utf8'));

widdershins.convert(apiDefinition, options)
    .then(markdownOutput => {
        fs.writeFileSync(path.resolve(outputPath), markdownOutput, 'utf8');
        console.log("Documentation successfully generated at:", outputPath);
    })
    .catch(err => {
        console.error("An error occurred:", err);
    });

function templateCallBack(templateName, stage, data) {
    if (stage === 'pre' && templateName === 'main') {
        // Traverse through the schema and look for x-restrictions
        if (data.components && data.components.schemas) {
            Object.values(data.components.schemas).forEach(schema => {
                if (schema.properties) {
                    Object.entries(schema.properties).forEach(([propName, propValue]) => {
                        if (propValue['x-restrictions']) {
                            propValue.restrictions = propValue['x-restrictions']
                        }
                    })
                }
            })
        }
    }
    return data;
}