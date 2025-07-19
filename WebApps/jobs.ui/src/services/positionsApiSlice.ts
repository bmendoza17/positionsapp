import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react"

type PositionStatus = 'draft' | 'open' | 'closed' | 'archived';

type Position = {
    id: number;
    title: string;
    description: string;
    location: string;
    status: PositionStatus;
    Recruiter: string;
    Department: string;
    Budget: number;
    ClosingDate: string;
};

type PositionsApiResponse = {
    positions: Position[];
};

export const positionsApiSlice = createApi({
  baseQuery: fetchBaseQuery({ baseUrl: "https://hikruapi-fbdshfg7hrbmeuh6.canadacentral-01.azurewebsites.net/api" }),
  reducerPath: "positionsApi",
  tagTypes: ["Positions"],
  endpoints: (builder) => ({
    getPositions: builder.query<PositionsApiResponse, void>({
      query: () => "positions",
      providesTags: (_result: PositionsApiResponse | undefined, _error: unknown, _arg: void) => [{ type: "Positions" }],
    }),
  }),
});

export const { useGetPositionsQuery } = positionsApiSlice;
