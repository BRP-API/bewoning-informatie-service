#!/bin/bash

PARAMS="{ \
    \"apiUrl\": \"http://localhost:5000/haalcentraal/api\", \
    \"logFileToAssert\": \"./test-data/logs/bewoning-informatie-service.json\", \
    \"oAuth\": { \
        \"enable\": false \
    } \
}"

EXIT_CODE=0

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-zonder-dependency-integratie-summary.txt \
                -f summary \
                features/docs \
                -p UnitTest \
                > /dev/null
if [[ $? -ne 0 ]]; then EXIT_CODE=1; fi

npx cucumber-js -f json:./test-reports/cucumber-js/step-definitions/test-result-integratie.json \
                -f summary:./test-reports/cucumber-js/step-definitions/test-result-integratie-summary.txt \
                -f summary \
                features/docs \
                -p Integratie \
                > /dev/null
if [[ $? -ne 0 ]]; then EXIT_CODE=1; fi

npx cucumber-js -f json:./test-reports/cucumber-js/bewoning/test-result-geboortedatum.json \
                -f summary:./test-reports/cucumber-js/bewoning/test-result-geboortedatum-summary.txt \
                -f summary \
                features/geboortedatum \
                --tags "not @stap-documentatie" \
                --tags "not @skip-verify" \
                --world-parameters "$PARAMS" \
                > /dev/null
if [[ $? -ne 0 ]]; then EXIT_CODE=1; fi

npx cucumber-js -f json:./test-reports/cucumber-js/bewoning/test-result-naam.json \
                -f summary:./test-reports/cucumber-js/bewoning/test-result-naam-summary.txt \
                -f summary \
                features/naam \
                --tags "not @stap-documentatie" \
                --tags "not @skip-verify" \
                --world-parameters "$PARAMS" \
                > /dev/null
if [[ $? -ne 0 ]]; then EXIT_CODE=1; fi

npx cucumber-js -f json:./test-reports/cucumber-js/bewoning/test-result-raadpleeg-bewoning-met-periode.json \
                -f summary:./test-reports/cucumber-js/bewoning/test-result-raadpleeg-bewoning-met-periode-summary.txt \
                -f summary \
                features/raadpleeg-bewoning-met-periode \
                --tags "not @stap-documentatie" \
                --tags "not @skip-verify" \
                --world-parameters "$PARAMS" \
                > /dev/null
if [[ $? -ne 0 ]]; then EXIT_CODE=1; fi

npx cucumber-js -f json:./test-reports/cucumber-js/bewoning/test-result-raadpleeg-bewoning-op-peildatum.json \
                -f summary:./test-reports/cucumber-js/bewoning/test-result-raadpleeg-bewoning-op-peildatum-summary.txt \
                -f summary \
                features/raadpleeg-bewoning-op-peildatum \
                --tags "not @stap-documentatie" \
                --tags "not @skip-verify" \
                --world-parameters "$PARAMS" \
                > /dev/null
if [[ $? -ne 0 ]]; then EXIT_CODE=1; fi

# Exit with error code if any command failed
exit $EXIT_CODE