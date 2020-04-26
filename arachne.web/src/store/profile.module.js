import UserService from "@/common/api.service";
import {FETCH_PROFILE} from "@/store/actions.type";
import { SET_PROFILE, SET_ERROR } from "./mutation.type";

const state = {
    errors: {},
    profile: {}
};

const getters = {
    profile(state) {
        return state.profile;
    }
};

const actions = {
    [FETCH_PROFILE](context, payload) {
        return UserService.get("users", payload)
            .then(({data}) => {
                context.commit(SET_PROFILE, data);
                return data;
            })
            .catch((response) => {
                // #todo SET_ERROR cannot work in multiple states
                 context.commit(SET_ERROR, response.data.errors)
            });
    }
};

const mutations = {
    [SET_ERROR] (state, error) {
        state.errors = error
    },
    [SET_PROFILE](state, profile) {
        state.profile = profile;
        state.errors = {};
    }
};

export default {
    state,
    actions,
    mutations,
    getters
};
