#!/bin/bash

PARAMS="{ \
    \"apiUrl\": \"http://localhost:5000/haalcentraal/api\", \
    \"logFileToAssert\": \"./test-data/logs/bewoning-informatie-service.json\", \
    \"oAuth\": { \
        \"enable\": false \
    } \
}"

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie-summary.txt \
                -f summary \
                features/docs \
                --tags "not @integratie" \
                --tags "not @skip-verify"

npx cucumber-js -f json:./test-reports/cucumber-js/bewoning/test-result.json \
                -f summary:./test-reports/cucumber-js/bewoning/test-result-summary.txt \
                -f summary \
                features \
                --tags "not @stap-documentatie" \
                --tags "not @skip-verify" \
                --world-parameters "$PARAMS"
